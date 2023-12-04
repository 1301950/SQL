using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace WindowsFormsApp1
{

	public partial class Form1 : Form
	{
		public enum Task
		{
			toc = 1,
			process,
		}

		public List<Uri> lst_chapterurl = new List<Uri>();
		public List<string> lst_title = new List<string>();
		public Task CurrentTask;
		public int CurrentChapter;
		public string Title;
		public string Author;
		public string baseurl = "";

		public StringBuilder sb;
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			webBrowser1.ScriptErrorsSuppressed = true;
			webBrowser1.DocumentCompleted += WebBrowser1_DocumentCompleted;
			
		}

		private void WebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		{
			var str = webBrowser1.DocumentText;
			var doc = new HtmlAgilityPack.HtmlDocument();
			doc.LoadHtml(str);

			if (CurrentTask == Task.toc)
			{
				var chapters = doc.DocumentNode.SelectNodes("//li[@class='c3']/a").ToList();
				lst_chapterurl = chapters.Select(c => new Uri(baseurl + c.Attributes[0].Value)).ToList();
				CurrentChapter = 0;
				webBrowser1.Navigate(lst_chapterurl[CurrentChapter++]);
				CurrentTask = Task.process;
			}
			else
			{
				try
				{
					var node = doc.DocumentNode.SelectNodes("//h1[@class='title1']").FirstOrDefault();
					var title = node.InnerText.Replace("\n", "").Replace("\t", "");
					if (!lst_title.Contains(title))
					{
						lst_title.Add(title);
						Console.WriteLine($"lst_title:  {title} [{CurrentChapter}]");
						node = doc.DocumentNode.SelectNodes("//div[@id='content']").FirstOrDefault();
						var story = node.InnerHtml.Replace("<p>", "<br>").Replace("</p>", "<br>");

						sb.AppendLine("<h2 class='chapters'>" + title + "</h2><br>" + story + "<br><br>");
					}
					if (CurrentChapter >= lst_chapterurl.Count)
					{
						var sw = new System.IO.StreamWriter(Title + ".html", false, encoding: Encoding.Unicode);
						sw.WriteLine(sb.ToString() + "</body></html>");
						sw.Close();
					}
					else
					{
						webBrowser1.Navigate(lst_chapterurl[CurrentChapter++]);
					}

				}
				catch (Exception ex)
				{
					Console.WriteLine("error: " + ex.ToString());
				}
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			
			sb = new StringBuilder("<html>");
			lst_title = new List<string>();
			CurrentChapter = 0;
			CurrentTask = Task.toc;
			baseurl = textBox1.Text;
			var uri = new Uri(baseurl);
			baseurl = "https://" + uri.Host;
			if (!baseurl.EndsWith("/")) baseurl += "/";

			webBrowser1.Navigate(textBox1.Text);
		}

		private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
		{

		}
	}
}
