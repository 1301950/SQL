using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Emgu.CV;

namespace ConsoleApplication1
{
    class Program
    {
        private static void Merge()
        {
            File.Copy("CDS_Licence.docx", "CDS_Licence_gen.docx", true);
            var bytes = File.ReadAllBytes("CDS_Licence.docx");
            var memorystream = new System.IO.MemoryStream();
            memorystream.Write(bytes, 0, bytes.Length);

            using (WordprocessingDocument docGenerated = WordprocessingDocument.Open(memorystream, true))
            {
                docGenerated.ChangeDocumentType(WordprocessingDocumentType.Document);
                /*
                foreach (FieldCode field in docGenerated.MainDocumentPart.RootElement.Descendants<FieldCode>())
                {
                    string strFieldName = field.Text.Replace("MERGEFIELD", string.Empty).Replace("\\* MERGEFORMAT", string.Empty).Trim();
                    var fieldNameStart = strFieldName;
                    var fieldname = strFieldName.Trim();
                    var fieldValue = fieldname;


                    foreach (Run run in docGenerated.MainDocumentPart.Document.Descendants<Run>())
                    {
                        foreach (Text txtFromRun in run.Descendants<Text>().Where(a => a.Text == "«" + fieldname + "»"))
                        {
                            if (!string.IsNullOrEmpty(fieldValue))
                            {
                                txtFromRun.Text = "nv" + fieldValue;
                            }
                            else if (string.IsNullOrEmpty(fieldValue))
                            {
                                if (field.Parent != null)
                                    field.Remove();
                            }
                        }
                    }
                }
                */
                var bookmarks = docGenerated.MainDocumentPart.Document.Body.Descendants<BookmarkStart>();
                var firstBook = from n in bookmarks where n.Name == "SubActData" select n;
                var elem = firstBook.First().Parent;
                while (!(elem is DocumentFormat.OpenXml.Wordprocessing.Table))
                    elem = elem.Parent;
                var table = elem; //found
                var oldRow = elem.Elements<DocumentFormat.OpenXml.Wordprocessing.TableRow>().Last();

                var lst_table_toberemoved = new List<OpenXmlElement>();
                for (var bmidx = 0; bmidx < bookmarks.Count(); bmidx++)
                {
                    var book = bookmarks.ToList()[bmidx];
                    if (book.Name == "SubActData")
                    {
                    }
                }
                docGenerated.MainDocumentPart.Document.Save();
            }
            File.WriteAllBytes("CDS_Licence_gen.docx", memorystream.ToArray());
        }
        static void Main(string[] args)
        {
            var src = CvInvoke.Imread("d:\\workpic\\test1.jpg", ImreadModes.Color);

        }

        private static ProcessStartInfo getpsi(string fn, string arg)
        {
            var psi = new ProcessStartInfo("atom", arg);
            psi.CreateNoWindow = false;
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            return psi;
        }

        private static void ProcessFanart()
        {

            var files = Directory.GetFiles(@"W:\mp4\Lexi Belle", "*.jpg", SearchOption.AllDirectories);
            files.ToList().ForEach(f =>
            {
                var path = Path.GetDirectoryName(f);
                var fn = Path.GetFileNameWithoutExtension(f);

                if (!fn.EndsWith("-fanart"))
                {
                    var ext = Path.GetExtension(f);
                    var newfn = Path.Combine(path, fn + "-fanart" + ext);
                    File.Move(f, newfn);
                    System.Threading.Thread.Sleep(300);
                }
            });
        }
        private static string RemoveUntilNumbers(string s)
        {
            try
            {
                int i = 0;
                for (i = s.Length - 1; i >= 0; i--)
                {
                    if (Char.IsDigit(s[i])) break;
                }
                return s.Substring(0, i + 1);
            } catch (Exception e)
            {
                return s;

            }
        }

    }
}
