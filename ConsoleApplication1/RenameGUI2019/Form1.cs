using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Goheer.EXIF;
using System.Collections;
using System.IO;
using System.Web.UI;

namespace RenameGUI2019
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.statusStrip1.Text = "";
			this.processDirectory(this.textBox1.Text);
			this.statusStrip1.Text = "Finished";
		}

		private void button1_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog dialog = new FolderBrowserDialog();
			if (dialog.ShowDialog() != DialogResult.Cancel)
			{
				this.textBox1.Text = dialog.SelectedPath;
			}
		}

		private DateTime getDatetimeFromExif(string f)
		{
			EXIFextractor er2;
			DateTime dateTime;
			Encoding aSCII = Encoding.ASCII;
			IEnumerator enumerator = (new EXIFextractor(f, "", "")).GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					var s = (Pair)enumerator.Current;

					if (s.First == "Date Time")
					{
						string str_datetime = s.Second.ToString();
						char[] chrArray = new char[] { ' ' };
						string date = str_datetime.Split(chrArray)[0].Replace(':', '/');
						char[] chrArray1 = new char[] { ' ' };
						string time = str_datetime.Split(chrArray1)[1];
						er2 = null;
						dateTime = DateTime.Parse(string.Concat(date, " ", time));
						return dateTime;
					}
				}
				er2 = null;
				return DateTime.Now;
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			return dateTime;
		}

		private void processDirectory(string directory)
		{
			string[] files = Directory.GetFiles(directory);
			for (int i = 0; i < (int)files.Length; i++)
			{
				string f = files[i];
				var fi = new FileInfo(f);
				
				string ext = fi.Extension;
				if (ext.ToLower() == ".jpg")
				{
					string dir = Path.GetDirectoryName(f);
					DateTime s = this.getDatetimeFromExif(f);
					string newFileName = this.renameIfExist(f, dir, s, ext);
					File.Move(f, newFileName);
					var oldf = Path.GetFileNameWithoutExtension(f);
					var newf = Path.GetFileNameWithoutExtension(newFileName);

					var oldnef = Path.Combine(dir, oldf) + "." + txt_raw.Text;
					var newnef = Path.Combine(dir, newf) + "." + txt_raw.Text;
					if (File.Exists(oldnef))
						File.Move(oldnef, newnef);

				}
			}
		}

		private string renameIfExist(string f, string dir, DateTime s, string ext)
		{
			int count = 0;
			string newFileName = string.Concat(Path.Combine(dir, s.ToString("yyyyMMdd_HHmmss")), ext);
			if (f == newFileName)
			{
				return newFileName;
			}
			while (File.Exists(Path.Combine(dir, newFileName)))
			{
				newFileName = string.Format("{0}_{1}{2}", s.ToString("yyyyMMdd_HHmmss"), count, ext);
				newFileName = Path.Combine(dir, newFileName);
				count++;
			}
			return newFileName;
		}
	}
}
