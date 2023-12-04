using Emgu.CV;
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

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public bool processing = false;
        public Form1()
        {
            /*var im = new ImageMagick.MagickImage(@"E:\workpic\start\test50798.jpg");
            var sub = new ImageMagick.MagickImage(@"D:\workpic\cerb.jpg");
            var res = im.SubImageSearch(sub);*/
            ocr();
            InitializeComponent();
            TestImage(@"E:\workpic\test50002.jpg", new string[] { @"d:\workpic\witch.jpg" });

            //timer1.Start();
        }

        public async void ocr()
		{
            var engine = OcrEngine.TryCreateFromLanguage(new Windows.Globalization.Language("en-US"));

            string filePath = @"C:\work\small.jpg";
            var file = await Windows.Storage.StorageFile.GetFileFromPathAsync(filePath);
            var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
            var decoder = await Windows.Graphics.Imaging.BitmapDecoder.CreateAsync(stream);
            var softwareBitmap = await decoder.GetSoftwareBitmapAsync();
            var ocrResult = await engine.RecognizeAsync(softwareBitmap);
            Console.WriteLine(ocrResult.Text);
        }

        public void TestImage(string inputfile, string[] templatefiles)
        {
            if (!inputfile.EndsWith(".jpg"))
            {
                File.Delete(inputfile);
                return;
            }
            if (!System.IO.File.Exists(inputfile)) return;
            try
            {
                using (var img = CvInvoke.Imread(inputfile))
                {
                    var found = false;
                    foreach (var templatefile in templatefiles)
                    {
                        using (var template = CvInvoke.Imread(templatefile))
                        {
                            using (var mat = new Mat())
                            {
                                var threshold = double.Parse(txt_threshold1.Text);           // 0.22 for ymir
                                if (templatefile.IndexOf("wood") > 0) threshold = 0.005;
                                if (templatefile.IndexOf("barb") > 0) threshold = 0.3;
                                if (templatefile.IndexOf("redflag") > 0) threshold = 0.1;
                                if (templatefile.IndexOf("craw") > 0) threshold = 0.02;
                                if (templatefile.IndexOf("turtle") > 0) threshold = 0.1;
                                if (templatefile.IndexOf("ghi") > 0) threshold = 0.1;


                                CvInvoke.MatchTemplate(img, template, mat, Emgu.CV.CvEnum.TemplateMatchingType.SqdiffNormed);

                                double minval = 0.0;
                                double maxval = 0.0;
                                var minloc = new Point(0, 0);
                                var maxloc = new Point(0, 0);
                                CvInvoke.MinMaxLoc(mat, ref minval, ref maxval, ref minloc, ref maxloc);

                                /*Rectangle r = new Rectangle(minloc, template.Size);
                                CvInvoke.Rectangle(img, r, new Emgu.CV.Structure.MCvScalar(255, 0, 0), 3);
                                pictureBox1.Image = img.ToBitmap();*/
                                if (minval < threshold)
                                {
                                    Debug.WriteLine(minval + ":" + maxval + ":" + inputfile);
                                    File.Move(inputfile, tb_inputfile.Text + @"\found\" + Path.GetFileName(inputfile), true);
                                    found = true;
                                }
                            }
                        }
                    }
                    if (!found) File.Delete(inputfile);

                }
            }
            catch (Exception e)
            {

            }
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

        private void Process()
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
                    TestImage(f, arr);
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
