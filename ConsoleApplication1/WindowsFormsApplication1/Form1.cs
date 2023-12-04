using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Xml;
using System.Text.RegularExpressions;
using System.IO;
using System.Data.SQLite;
using System.Data.SQLite.Linq;
using Microsoft.Win32;

namespace WindowsFormsApplication1
{

    public partial class Form1 : Form
    {
		
        public class DataClass
        {
            public string url;
            public string javid;
            public string thumbpath;
            public string userartpath;
        }

        List<KeyValuePair<long, string>> lst_directors;
        SQLiteConnection conn;
        SQLiteDataAdapter adapter;
        DataSet ds;

        enum GlobalFunc { processmovie, processThumb }
        GlobalFunc CurrentStage;
        Dictionary<int, DataClass> JobList = new Dictionary<int, DataClass>();

        public Form1()
        {
            RegistryKey RegKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Internet Explorer\Main", true);
            RegKey.SetValue("Display Inline Images", "no");

            InitializeComponent();
            TryConnect();
            Init();
            /*var title = "";
            var posterrl = "";
            QueryJavLibrary("scop-177", out title, out posterrl);*/
        }

        private void Init()
        {
            lst_directors = new List<KeyValuePair<long, string>>();
            var dt = RetrieveTable("select tag, id from tags where tag_type = 4");
            if (dt != null)
                lst_directors = dt.AsEnumerable().Select(dr => new KeyValuePair<long, string>(dr.Field<Int64>("id"), dr.Field<string>("tag"))).ToList();
            dg_tables.DataSource = dt;
        }

        public static string extractcover(string content)
        {
            var start = content.IndexOf("video_jacket_img");
            if (start < 0) return null;
            var end = content.IndexOf(">", start);
            if (end < 0) return null;
            var jpgurl = content.Substring(start, end - start);
            var res = jpgurl.Split('"');
            if (res.Count() > 2)
            {
                var result = res[2];
                if (result.StartsWith("//")) return "http://" + result.Substring(2);
                return res[2];
            }
            return "";
        }



        public List<string> QueryJavLibrary(string keyword, string inUrl, out string titledata, out string posterurl)
        {
		
            titledata = null;
            posterurl = null;
            var url = inUrl;

            if (string.IsNullOrEmpty(inUrl))
                url = "http://www.javlibrary.com/en/vl_searchbyid.php?keyword=" + keyword;
            else
                url = "http://www.javlibrary.com/en/" + inUrl;
            webBrowser1.ScriptErrorsSuppressed = true;
            webBrowser1.Navigate(url);

            return new List<string>();

        }


        public List<string> GetQueryJavLibrary(string content, out string titledata, out string posterurl, out string outUrl)
        {
            var lst = new List<string>();
            titledata = null;
            posterurl = null;
            outUrl = null;

            var titlecontent = "";
            if (content.IndexOf("Checking your browser before accessing") > 0) return lst;
            var result = getextractcast(content, out titlecontent);

            posterurl = extractcover(content);
            var xdoc = new XmlDocument();
            if (result == null)
            {
                
                var start = content.IndexOf("<div class=\"videothumblist\">");
                var end = content.IndexOf("<!-- end of videothumblist -->");
                result = content.Substring(start, end - start);
                result = result.Replace("&Amp;", "&amp;");
                //result = System.Net.WebUtility.HtmlDecode(result);

                try
                {
                    xdoc.Load(new System.IO.StringReader(result));
                }
                catch (Exception e)
                {
                    return new List<string>();
                }

                var videos = xdoc.FirstChild.FirstChild.ChildNodes.Cast<XmlNode>()
                    .Where(xn => xn.FirstChild != null)
                    .Select(xn =>
                    {
                        var videonode = xn.FirstChild;
                        var title = videonode.Attributes.Cast<XmlAttribute>().Where(a => a.Name == "title").FirstOrDefault().Value;
                        var href = videonode.Attributes.Cast<XmlAttribute>().Where(a => a.Name == "href").FirstOrDefault().Value;
                        return new KeyValuePair<string, string>(href, title);
                    }).ToList();

				if (videos.Count == 2)
				{
					outUrl = videos[0].Key;
				}
				else
				{
					var dv = new Dataview();
					dv.SetData(videos, "");
					dv.ShowDialog();
					outUrl = dv.url;
				}
                if (videos.Count() == 0) return new List<string>();
                return null;
                //result = extractcast("http://www.javlibrary.com/en/" + videos[0].Key, out content, out titlecontent);
                //posterurl = extractcover(content);
            }
            
            if (result == null) return lst;
            xdoc.Load(new System.IO.StringReader(result));

            foreach (XmlNode node in xdoc.FirstChild.FirstChild.FirstChild.ChildNodes[1].ChildNodes)
            {
                lst.Add(node.FirstChild.FirstChild.InnerText);
                var alias = node.SelectNodes("span[@class='alias']");
                foreach (XmlNode n in alias)
                {
                    lst.Add(n.InnerText);
                }
            }
            titlecontent = titlecontent.Replace("&", "&amp;");
            xdoc.Load(new System.IO.StringReader(titlecontent));
            titledata = xdoc.FirstChild.FirstChild.FirstChild.FirstChild.Value;
            return lst;
        }

        private void FindDirector(string s)
        {
            //var s = "select * from tags where tag in ({0})";

        }

        private void GetTables()
        {
            FillTable("SELECT * FROM sqlite_master where type='table'", dg_tables);
        }

        private void ExecuteQuery(string s)
        {
            if (conn.State != ConnectionState.Open) conn.Open();
            var cmd = new SQLiteCommand(s, conn);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
        }
        private DataTable RetrieveTable(string command)
        {
            var ds = RetrieveDataset(command);
            if (ds != null && ds.Tables.Count > 0) return ds.Tables[0];
            return null;
        }

        private DataSet RetrieveDataset(string command)
        {
            if (conn.State != ConnectionState.Open) conn.Open();
            adapter = new SQLiteDataAdapter(command, conn);
            ds = new DataSet();
            try
            {
                adapter.Fill(ds);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
            return ds;
        }



        private void FillTable(string command, DataGridView dgv = null)
        {
            var ds = RetrieveTable(command);

            if (checkBox1.Checked)
            {
                var f = new Dataview();
                f.Show();
                f.SetData(ds);
            }
            else
            {
                if (dgv == null) dgv = dg_data;
                try
                {
                    dgv.DataSource = ds;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            FillTable(textBox1.Text);
        }

        private void btn_sfrom_click(object sender, EventArgs e)
        {
            var str_command = "select * from " + textBox1.Text;
            FillTable(str_command);
        }

        private void openDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TryConnect();
        }

        private void TryConnect()
        {
            var d = new OpenFileDialog();
            var res = d.ShowDialog();
            var fn = d.FileName;
            string connString = String.Format("Data Source={0};New=False;Version=3;Synchronous=Full;", fn);
            //conn = new Finisar.SQLite.SQLiteConnection(connString);
            conn = new SQLiteConnection(connString);
            try
            {
                conn.Open();

                GetTables();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var s = "";
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var s = "";
        }

        private void btn_change_click(object sender, EventArgs e)
        {
            var changed = ds.HasChanges();
            try
            {
                adapter.Update(ds, textBox1.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_execute_click(object sender, EventArgs e)
        {
            try
            {
                ExecuteQuery(textBox1.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_copy_click(object sender, EventArgs e)
        {
            var src = txt_tagcopy_src.Text;
            var dest = txt_tagcopy_dest.Text;

            var cmd = @"
insert into taggings (metadata_item_id, tag_id)
select {1}, tags.id from taggings 
inner join tags on taggings.tag_id = tags.id 
where taggings.metadata_item_id= {0}
and tag_type = 4
";
            cmd = string.Format(cmd, src, dest);
            ExecuteQuery(cmd);
        }

        private void btn_list_directors_click(object sender, EventArgs e)
        {
            /*var selected = dg_data.Rows.Cast<DataGridViewRow>().Where(r => r.Selected).FirstOrDefault();
            var id = (dg_data.DataSource as DataTable).Rows[selected.Index]["id"];*/
            var cmd =
                @"
select media_item_id, file, item.id as metadataid, tags.tag from media_parts m
inner join media_items mi on m.media_item_id = mi.id
inner join metadata_items item on mi.metadata_item_id = item.id
left outer join taggings t on item.id = t.metadata_item_id 
left outer join tags on tags.id = t.tag_id
where file like '%{0}%'
";
            cmd = string.Format(cmd, txt_keyword.Text);
            FillTable(cmd);
        }

        private void HookupDirectorWIthID(List<string> directors, string movieid)
        {
            var lst_newids = new List<Int64>();
            foreach (var d in directors)
            {
                var cmd = "insert into tags (tag, tag_type) values ('{0}', 4);select max(id) from tags limit 1;";
                cmd = string.Format(cmd, d);
                var dt = RetrieveTable(cmd);
                if (dt != null)
                {
                    var newid = dt.Rows[0].Field<Int64>("max(id)");
                    lst_newids.Add(newid);
                    cmd = "insert into taggings(metadata_item_id, tag_id) values({1}, {0})";
                    cmd = string.Format(cmd, newid, movieid);
                    ExecuteQuery(cmd);

                }

            }
            LockDirector(movieid);
            Init();
        }

        private void HookupExistingDirectorWIthID(List<long> directors_ids, string movieid)
        {
            var lst_newids = new List<string>();
            foreach (var newid in directors_ids)
            {
                var cmd = $"select metadata_item_id, tag_id from taggings where metadata_item_id = { movieid } and tag_id = {newid}";
                var dt = RetrieveTable(cmd);
                if (dt.Rows.Count == 0)
                {
                    cmd = "insert into taggings(metadata_item_id, tag_id) values({1}, {0})";
                    cmd = string.Format(cmd, newid, movieid);
                    ExecuteQuery(cmd);
                }
            }
            LockDirector(movieid);
        }

        private void LockDirector(string movieid)
        {
            var cmd = $"update metadata_items set user_fields = 'lockedFields=1|17' where id ={movieid}";
            ExecuteQuery(cmd);
        }

        public void UpdateItemCover(string itemid, string posterurl)
        {
            var dt = RetrieveTable(string.Format("select tag, id from metadata_items where id = {0}", itemid));

        }

        private void UpdateItemTitle(string title, string itemid)
        {
            title = title.Replace("'", "''");
            var cmd = "update metadata_items set title = '{0}' where id ={1}";
            cmd = string.Format(cmd, title, itemid);
            ExecuteQuery(cmd);
        }

        private void btn_processmovie_click(object sender, EventArgs e)
        {
            CurrentStage = GlobalFunc.processmovie;
            ProcessMovie();

            
            //var lst = QueryJavLibrary(txt_javid.Text, out title, out posterurl);

        }

        private void processmovie_click(List<string> lst, string title, string posterurl)
        {
            if (cb_updatecast.Checked)
            {
                var missing = lst.Where(d => !lst_directors.Exists(ed => string.Equals(ed.Value, d))).ToList();
                var exists = lst_directors.Where(ed => lst.Contains(ed.Value)).Select(ed => ed.Key).ToList();
                HookupDirectorWIthID(missing, txt_movieID.Text);
                HookupExistingDirectorWIthID(exists, txt_movieID.Text);
            }
            if (!string.IsNullOrEmpty(title))
                UpdateItemTitle(title, txt_movieID.Text);
        }

        private void ProcessMovie()
        {
            var title = "";
            var posterurl = "";
			if (JobList.Count > 0)
			{
				var j = JobList.FirstOrDefault();

				if (string.IsNullOrEmpty(j.Value.url))
				{
					var javid = JobList.FirstOrDefault().Value.javid.ToString();
					var lst = QueryJavLibrary(javid, null, out title, out posterurl);
				}
				else
				{
					QueryJavLibrary(null, j.Value.url, out title, out posterurl);
				}

			}

        }

        private void btn_addtags_click(object sender, EventArgs e)
        {
            var lst = txt_tags.Text.Split('|').ToList();
            foreach (DataGridViewRow dr in dg_data.Rows)
            {
                if (dr.Selected && dr.DataBoundItem != null)
                {
                    var movieid = (dr.DataBoundItem as DataRowView)["metadataid"] as long?;

                    var missing = lst.Where(d => !lst_directors.Exists(ed => string.Equals(ed.Value, d))).ToList();
                    var exists = lst_directors.Where(ed => lst.Contains(ed.Value)).Select(ed => ed.Key).ToList();
                    HookupDirectorWIthID(missing, movieid.Value.ToString());
                    HookupExistingDirectorWIthID(exists, movieid.Value.ToString());
                }
            }

        }

        private string GetTitle(string title)
        {
            title = title.Replace(" ", "");
            var arr = title.Split(' ');
            var res = arr[0];
            res = RemoveUntilNumbers(res);

            var rx = new Regex(@"\d+");
            if (rx.IsMatch(res)) return res;
            if (arr.Length < 2) return res;
            res = arr[0] + arr[1];
            return res;
        }

        private string RemoveUntilNumbers(string s)
        {
            try
            {
                int i = 0;
                for (i = 0; i < s.Length -1 ; i++)
                {
                    if (Char.IsDigit(s[i])) break;
                }
                var j = i;
                for (j = i; j < s.Length; j++)
                {
                    if (!Char.IsDigit(s[j])) break;
                }
                return s.Substring(0, j);
            }
            catch (Exception e)
            {
                return s;

            }
        }

        private void btn_quick_click(object sender, EventArgs e)
        {
            JobList.Clear();
            CurrentStage = GlobalFunc.processmovie ;
            foreach (DataGridViewRow dr in dg_data.SelectedRows)
            {
                var movieid = int.Parse(dr.Cells["itemid"].Value.ToString());
                var javid = GetTitle(dr.Cells["title_sort"].Value.ToString());
                if (!JobList.ContainsKey(movieid)) JobList.Add(movieid, new DataClass() { javid = javid });
            }
            ProcessMovie();
        }

        private void btn_updateposter(object sender, EventArgs e)
        {
            

            foreach (DataGridViewRow dr in dg_data.SelectedRows)
            {
                var movieid = dr.Cells["itemid"].Value.ToString();
                var javid = GetTitle(dr.Cells["title_sort"].Value.ToString());
                var thumbpath = dr.Cells["user_thumb_url"].Value.ToString();
                var userartpath = dr.Cells["user_art_url"].Value.ToString();
                if (thumbpath == null) continue;
                JobList.Add(int.Parse(movieid), new DataClass() { javid = javid, thumbpath = thumbpath, userartpath = userartpath });

            }
            doUpdatePoser();
        }

        private void doUpdatePoser()
        {
            var title = "";
            var posterurl = "";
            CurrentStage = GlobalFunc.processThumb;
            var j = JobList.FirstOrDefault();

            if (string.IsNullOrEmpty(j.Value.url))
            {
                var javid = JobList.FirstOrDefault().Value.javid.ToString();
                var lst = QueryJavLibrary(javid, null, out title, out posterurl);
            }
            else
            {
                QueryJavLibrary(null, j.Value.url, out title, out posterurl);
            }
        }

        private void btn_updateposter(string posterurl, string thumbpath, string userartpath, string javid)
        {
                var header = "media://";
                thumbpath = thumbpath.Substring(header.Length).Replace("/", "\\");
                userartpath = userartpath.Substring(header.Length).Replace("/", "\\");
                var baseURL = @"X:\Plex Media Server\Media\localhost\";
                thumbpath = baseURL + thumbpath;
                userartpath = baseURL + userartpath;
                var wc = new WebClient();
                if (System.IO.File.Exists(thumbpath) && posterurl != null)
                    wc.DownloadFile(posterurl, thumbpath);
                if (System.IO.File.Exists(userartpath) && posterurl != null)
                    wc.DownloadFile(posterurl, userartpath);
            return;
            var fn = Path.Combine(txt_localpath.Text, javid + ".jpg");
            if (!System.IO.File.Exists(fn) && posterurl != null)
                wc.DownloadFile(posterurl, fn);
        }

        private static string UpdateThumb(string guid)
        {
            var baseURL = @"X:\Plex Media Server\Metadata\Movies\";
            var sha = System.Security.Cryptography.SHA1.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(guid));
            var res = string.Join("", bytes.Select(b => b.ToString("x2")).ToList());
            res = res.Insert(1, "\\");
            var url = baseURL + res;
            return res;
        }

        private void btn_updateposter_local(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_localpath.Text)) return;
            var files = System.IO.Directory.GetFiles(txt_localpath.Text, "*.mp4");
            foreach (var f in files)
            {
                var javid = GetTitle(Path.GetFileNameWithoutExtension(f));
                var title = "";
                var posterurl = "";

                QueryJavLibrary(javid, null, out title, out posterurl);
                var wc = new WebClient();
                var fn = Path.Combine(txt_localpath.Text, javid + ".jpg");
                if (!System.IO.File.Exists(fn) && posterurl != null)
                    wc.DownloadFile(posterurl, fn);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var queries = new Dictionary<int, string>() { {
                    0, @"select item.*, item.id as itemid, item.title, item.user_thumb_url, item.user_art_url from 
metadata_items item
where library_section_id = 14
order by item.added_at desc
LIMIT 2000" },
            { 1, @"select tags.id, tags.tag, item.id as itemid, item.title, item.title_sort, t.id as tagid, item.id as metadataid from 
metadata_items item
left outer join taggings t on item.id = t.metadata_item_id 
left outer join tags on tags.id = t.tag_id
where library_section_id = 14
order by item.added_at desc
LIMIT 2000
"},
				{3, @"select item.*, item.id as itemid, item.title, item.user_thumb_url, item.user_art_url from 
metadata_items item
left outer join taggings t on item.id = t.metadata_item_id 
left outer join tags on tags.id = t.tag_id
where library_section_id = 14
and tags.id = 37182
"

				},
                {2,
                @"select part.file, item.id as metadataid from 
media_items mi 
inner join media_parts part on part.media_item_id = mi.id
inner join metadata_items item on mi.metadata_item_id = item.id
where part.file like '%Cristal Caitlin%'"
                }
            };
            var idx = (sender as ComboBox).SelectedIndex;
            textBox1.Text = queries[idx];
        }

        

        private void ProcessContent()
        {
            string titledata = null;
            string posterurl = null;
            string outUrl = null;

            var test = webBrowser1.DocumentText;
            if (!cb_firsttime.Checked) webBrowser1.Document.OpenNew(false);

            string titlecontent = "";
            var lst = GetQueryJavLibrary(test, out titledata, out posterurl, out outUrl);

            if (CurrentStage == GlobalFunc.processmovie)
            {
                if (JobList.Count > 0)
                {
                    var job = JobList.FirstOrDefault();

                    if (string.IsNullOrEmpty(outUrl))
                    {
                        processmovie(lst, job.Key.ToString(), titledata);
                        JobList.Remove(job.Key);
                    }
                    else
                    {
                        job.Value.url = outUrl;
                    } 
                    
                    if (JobList.Count > 0) ProcessMovie();
                }
            }
            else
            {
                if (JobList.Count > 0)
                {
                    var job = JobList.FirstOrDefault();
                    if (string.IsNullOrEmpty(outUrl))
                    {
                        btn_updateposter(posterurl, job.Value.thumbpath, job.Value.userartpath, job.Value.javid);
                        JobList.Remove(job.Key);
                    }
                    else
                    {
                        job.Value.url = outUrl;
                    }
                    if (JobList.Count > 0) doUpdatePoser();
                }
            }
        }

        private void processmovie(List<string> lst, string movieid, string title)
        {
            if (cb_updatecast.Checked && lst != null && lst.Count > 0)
            {
                var missing = lst.Where(d => !lst_directors.Exists(ed => string.Equals(ed.Value, d))).ToList();
                var exists = lst_directors.Where(ed => lst.Contains(ed.Value)).Select(ed => ed.Key).ToList();
                HookupDirectorWIthID(missing, movieid);
                HookupExistingDirectorWIthID(exists, movieid);
            }
            if (!string.IsNullOrEmpty(title))
                UpdateItemTitle(title, movieid);
        }

        public static string getextractcast(string content, out string titlecontent)
        {
            var castcontent = "";
            titlecontent = null;
            
            var start = content.IndexOf("<div id=\"video_cast\" class=\"item\">");
            var end = content.IndexOf("<!-- end of video_cast -->");
            if (start < 0 || end < 0)
            {
                return null;
            }
            castcontent = content.Substring(start, end - start);

            start = content.IndexOf("<div id=\"video_jacket\">");
            end = content.IndexOf("<!-- end of video_jacket -->");
            titlecontent = content.Substring(start, end - start);

            start = content.IndexOf("<div id=\"video_title\">");
            end = content.IndexOf("<!-- end of video_title -->");
            titlecontent = content.Substring(start, end - start);

            return castcontent;
        }

        private void webBrowser1_Navigated(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            ProcessContent();
        }
    }
}
