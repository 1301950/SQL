using ImageProcessor;
using ImageProcessor.Imaging.Formats;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Media.Ocr;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public string GetNewPath(string path, string foldername)
		{
            var newfolder = Path.Combine(Path.GetDirectoryName(path), foldername);
            if (!Directory.Exists(newfolder)) Directory.CreateDirectory(newfolder);
            var newfilename = Path.Combine(Path.GetDirectoryName(path), foldername, Path.GetFileName(path));
            return newfilename;
        }
        public bool processing = false;
        public Form1()
        {
            /*var im = new ImageMagick.MagickImage(@"E:\workpic\start\test50798.jpg");
            var sub = new ImageMagick.MagickImage(@"D:\workpic\cerb.jpg");
            var res = im.SubImageSearch(sub);*/
            //cropjpg(@"W:\found\kl50017-334-790.jpg");
            GetNewPath(@"w:\kl50913.jpg", @"processed");
            InitializeComponent();
            ocr(@"W:\found\processed\kl52018-470-745.jpg", @"Y:\kl50529.jpg");
            //TestImage(@"w:\kl50002.jpg", new string[] { @"d:\workpic\witch.jpg" });

            //timer1.Start();
        }

        public bool IsSpecial(string text)
		{
            var idx = text.IndexOf(tb_templatefile.Text);
            if (idx > 0)
			{
                var i = 0;
                while (idx-- > 0)
                {
                    if (int.TryParse(text.ElementAt(idx).ToString(), out i))
					{
                        if (i > 2) return true;
                        return false;
					}
                }
			}
            return false;
		}

        public void MoveFile(string src, string dest)
        {
            if (File.Exists(dest))
			{
                File.Delete(src);
			}
			else
			{
                File.Move(src, dest);
			}
		}

        public string cropjpg(string filepath)
		{
            var fnParts = Path.GetFileNameWithoutExtension(filepath).Split('-');
            var path = Path.GetDirectoryName(filepath);
            var tmppath = path + "\\tmp.jpg";
            var x = int.Parse(fnParts[1]);
            var y = int.Parse(fnParts[2]);

            byte[] photoBytes = File.ReadAllBytes(filepath);
            // Format is automatically detected though can be changed.
            ISupportedImageFormat format = new JpegFormat { Quality = 70 };
            Size size = new Size(150, 0);
            using (MemoryStream inStream = new MemoryStream(photoBytes))
            {
                MemoryStream outStream = new MemoryStream();
                                // Initialize the ImageFactory using the overload to preserve EXIF metadata.
                using (ImageFactory imageFactory = new ImageFactory(preserveExifData: true))
                {
                    // Load, resize, set the format and quality and save an image.
                    if (x - 150 < 0) x = 0;
                    else x = x - 150;
                    imageFactory.Load(inStream)
                                .Crop(new Rectangle(x, y, 150, 150))
                                .Save(tmppath);
                    //.Save(outStream);

                }
            }
            return tmppath;

        }

        public async Task ocr(string filePath, string newfilename)
		{
            
            var engine = OcrEngine.TryCreateFromLanguage(new Windows.Globalization.Language("en-US"));

            //var inputstream = cropjpg(filePath).AsRandomAccessStream(); ;
            var tmppath = cropjpg(filePath);

            var file = await Windows.Storage.StorageFile.GetFileFromPathAsync(tmppath);
            var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
            //var stream = inputstream;
            var decoder = await Windows.Graphics.Imaging.BitmapDecoder.CreateAsync(stream);
            var softwareBitmap = await decoder.GetSoftwareBitmapAsync();
            var ocrResult = await engine.RecognizeAsync(softwareBitmap);

            if (IsSpecial(ocrResult.Text))
			{
                Console.WriteLine(ocrResult.Text);
                MoveFile(filePath, GetNewPath(filePath, "special"));
            }
            else
                MoveFile(filePath, GetNewPath(filePath, "processed"));
            
        }

        public void TestImage(string inputfile, string[] templatefiles)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            d.ShowDialog();
            tb_inputfile.Text = d.FileName;
        }

        private void btn_process_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private async void Process()
        {
            processing = true;
            string[] lst = null;
            do
            {
                lst = GetFiles();
                if (lst.Length > 0)
                {
                    var f = lst[0];

                    if (cmb_oddoreven.SelectedIndex != 0 && lst.Length > 1)
                    {
                        var fn = Path.GetFileNameWithoutExtension(f);
                        var odd = true;
                        if (int.Parse(fn[fn.Length - 1].ToString()) % 2 == 0) odd = false;

                        if (cmb_oddoreven.SelectedIndex == 1)   // odd
                        {
                            if (!odd) f = lst[1];
                        }
                        else
                        {
                            if (odd) f = lst[1];
                        }
                    }

                    var arr = tb_templatefile.Text.Split(',');
                    //TestImage(f, arr);
                    await ocr(f, f);
                    System.Threading.Thread.Sleep(1000);
                }
            } while (lst.Length > 0);
            processing = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            d.Multiselect = true;
            d.ShowDialog();
            tb_templatefile.Text = string.Join(",", d.FileNames);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            TestImage(tb_inputfile.Text + "\\test" + numericUpDown1.Value + ".jpg", tb_templatefile.Text.Split(','));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!processing)
            {
                var lst = GetFiles();
                if (lst.Length > 0) Process();
            }
            statusStrip1.Text = DateTime.Now.ToLongTimeString() + ":" + processing.ToString();
            timer1.Start();
        }

        private string[] GetFiles()
        {
            var lst = Directory.GetFiles(tb_inputfile.Text);
            return lst.Where(e => Path.GetFileName(e).StartsWith(txt_fileprefix.Text)).ToArray();
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void txt_threshold_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
