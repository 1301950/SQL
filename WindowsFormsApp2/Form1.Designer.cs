﻿
namespace WindowsFormsApp2
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.button1 = new System.Windows.Forms.Button();
			this.tb_templatefile = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.tb_inputfile = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btn_process = new System.Windows.Forms.Button();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.cmb_oddoreven = new System.Windows.Forms.ComboBox();
			this.button3 = new System.Windows.Forms.Button();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.txt_fileprefix = new System.Windows.Forms.TextBox();
			this.txt_threshold1 = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(57, 107);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(645, 1115);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(57, 10);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(64, 20);
			this.button1.TabIndex = 1;
			this.button1.Text = "open";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// tb_templatefile
			// 
			this.tb_templatefile.Location = new System.Drawing.Point(128, 10);
			this.tb_templatefile.Name = "tb_templatefile";
			this.tb_templatefile.Size = new System.Drawing.Size(304, 20);
			this.tb_templatefile.TabIndex = 2;
			this.tb_templatefile.Text = "ar";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(57, 48);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(64, 20);
			this.button2.TabIndex = 1;
			this.button2.Text = "open";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// tb_inputfile
			// 
			this.tb_inputfile.Location = new System.Drawing.Point(128, 47);
			this.tb_inputfile.Name = "tb_inputfile";
			this.tb_inputfile.Size = new System.Drawing.Size(304, 20);
			this.tb_inputfile.TabIndex = 2;
			this.tb_inputfile.Text = "w:\\found";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(436, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(47, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "template";
			// 
			// btn_process
			// 
			this.btn_process.Location = new System.Drawing.Point(436, 48);
			this.btn_process.Name = "btn_process";
			this.btn_process.Size = new System.Drawing.Size(64, 20);
			this.btn_process.TabIndex = 1;
			this.btn_process.Text = "Process";
			this.btn_process.UseVisualStyleBackColor = true;
			this.btn_process.Click += new System.EventHandler(this.btn_process_Click);
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(128, 73);
			this.numericUpDown1.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(303, 20);
			this.numericUpDown1.TabIndex = 4;
			this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
			// 
			// timer1
			// 
			this.timer1.Interval = 5000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// cmb_oddoreven
			// 
			this.cmb_oddoreven.FormattingEnabled = true;
			this.cmb_oddoreven.Items.AddRange(new object[] {
            "Both",
            "Odd",
            "Even"});
			this.cmb_oddoreven.Location = new System.Drawing.Point(553, 10);
			this.cmb_oddoreven.Name = "cmb_oddoreven";
			this.cmb_oddoreven.Size = new System.Drawing.Size(104, 21);
			this.cmb_oddoreven.TabIndex = 5;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(507, 48);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(64, 20);
			this.button3.TabIndex = 1;
			this.button3.Text = "Stop";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.btn_stop_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Location = new System.Drawing.Point(0, 185);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
			this.statusStrip1.Size = new System.Drawing.Size(729, 22);
			this.statusStrip1.TabIndex = 6;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// txt_fileprefix
			// 
			this.txt_fileprefix.Location = new System.Drawing.Point(438, 73);
			this.txt_fileprefix.Name = "txt_fileprefix";
			this.txt_fileprefix.Size = new System.Drawing.Size(78, 20);
			this.txt_fileprefix.TabIndex = 7;
			this.txt_fileprefix.Text = "kl";
			// 
			// txt_threshold1
			// 
			this.txt_threshold1.Location = new System.Drawing.Point(522, 73);
			this.txt_threshold1.Name = "txt_threshold1";
			this.txt_threshold1.Size = new System.Drawing.Size(78, 20);
			this.txt_threshold1.TabIndex = 7;
			this.txt_threshold1.Text = "0.19";
			this.txt_threshold1.TextChanged += new System.EventHandler(this.txt_threshold_TextChanged);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(729, 207);
			this.Controls.Add(this.txt_threshold1);
			this.Controls.Add(this.txt_fileprefix);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.cmb_oddoreven);
			this.Controls.Add(this.numericUpDown1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tb_inputfile);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.btn_process);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.tb_templatefile);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.pictureBox1);
			this.Name = "Form1";
			this.Text = "Text Search 20231204_1804";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox tb_templatefile;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.TextBox tb_inputfile;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btn_process;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.ComboBox cmb_oddoreven;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.TextBox txt_fileprefix;
		private System.Windows.Forms.TextBox txt_threshold1;
	}
}

