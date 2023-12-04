using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Microsoft.Office.Interop.Word;


namespace ConsoleApp1
{
    public class kba
	{
        public string title { get; set; }
        public string body { get; set; }
    }
	class Program
	{


		static void Main(string[] args)
		{
            string result = Path.GetTempPath();
            /*Document doc = application.Documents.Open("t:\\t1.doc", ReadOnly: true);
            
            //More "complete" but worse HTML
            //doc.SaveAs(result + "temp.html", WdSaveFormat.wdFormatHTML);
            doc.SaveAs(result + "temp.html", WdSaveFormat.wdFormatFilteredHTML);
            doc.Close();

            // Close Word
            application.Quit();
            */
            // Now, clean up Word's HTML using Html Agility Pack
            HtmlAgilityPack.HtmlDocument mangledHTML = new HtmlAgilityPack.HtmlDocument();
            mangledHTML.Load(result + "temp.html");

            var c = mangledHTML.DocumentNode.FirstChild.FirstChild;
            var root = mangledHTML.DocumentNode.SelectSingleNode("//div[@class='WordSection1']");
            var lst_topics = new List<kba>();

            for (var i = 0; i < root.ChildNodes.Count; i++)
            {
                var n = root.ChildNodes[i];
                if (n.InnerHtml.ToLower().IndexOf("background:lime") > 0)
				{
                    var t = n;
                    var kb = new kba();
                    var titles = n.Descendants().Where(e => e.Attributes["style"] != null && e.Attributes["style"].Value.Contains("background:lime")).ToList();

                    kb.title = string.Join("", titles.Select(e => e.InnerText).ToArray());
                    if (n.ChildNodes.Count > 1)
                    {
                        if (n.ChildNodes[1].FirstChild != null)
                        {

                            var res = "";
                            i++;
                            while (root.ChildNodes[i].InnerHtml.ToLower().IndexOf("tableofcontents") < 0)
							{
                                res += root.ChildNodes[i++].InnerHtml;
							}
                            kb.body = res;
                            lst_topics.Add(kb);
                        }
                    } else if (n.ChildNodes.Count == 1)
                    {
                        if (n.FirstChild.FirstChild != null)
                        {
                            var res = "";
                            i++;
                            while (root.ChildNodes[i].InnerHtml.ToLower().IndexOf("tableofcontents") < 0)
                            {
                                res += root.ChildNodes[i++].InnerHtml;
                            }
                            kb.body = res;
                            lst_topics.Add(kb);
                        }
                    }

                }
            }
            var nodes = mangledHTML.DocumentNode.SelectNodes("//div[@class='WordSection1']");
            var count = nodes.Count;
            
            foreach (var n in nodes)
			{
                var node = n;
                var p = node.ParentNode.ParentNode;
                var next = p.NextSibling.NextSibling;
                next = next.FirstChild;
                var text = next.InnerText;
			}
            //Uncomment to see results so far
            //Process.Start("notepad.exe", result + "temp.html");

            

            mangledHTML.Save(result + "newtemp.html");

            // Remove standalone CRLF 
            
        }
	}
}
