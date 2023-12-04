using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace ConsoleApp3
{
	class Program
	{

		private static void Process()
		{
			var files = System.IO.Directory.GetFiles(@"J:\mia pictures\Raw\", "*.nef", SearchOption.AllDirectories);
			foreach (var f in files)
			{
				var dirs = MetadataExtractor.ImageMetadataReader.ReadMetadata(f);
				foreach (var dir in dirs)
				{

					var tag = dir.Tags.Where(e => e.Name == "Date/Time").FirstOrDefault();
					if (tag != null)
					{
						var d = DateTime.ParseExact(tag.Description, "yyyy:MM:dd HH:mm:ss", null);
						var ds = d.ToString("yyyyMMdd_HHmmss");
						var fi = new System.IO.FileInfo(f);
						var newfilename = Path.Combine(fi.DirectoryName, ds + ".nef");
						var cnt = 0;
						while (File.Exists(newfilename))
						{
							newfilename = Path.Combine(fi.DirectoryName, ds + "_" + cnt++ + ".nef");
						}
						System.IO.File.Move(f, newfilename);
					}

				}
			}
		}
		static void Main(string[] args)
		{

			

			//var str = wc.DownloadString("https://m.xklxsw.com/book/255473/147731965.html");

		}
	}
}
