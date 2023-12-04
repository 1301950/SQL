namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.dg_data = new System.Windows.Forms.DataGridView();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.dg_tables = new System.Windows.Forms.DataGridView();
			this.label2 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.button3 = new System.Windows.Forms.Button();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.button4 = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cb_firsttime = new System.Windows.Forms.CheckBox();
			this.txt_tagcopy_dest = new System.Windows.Forms.TextBox();
			this.txt_tagcopy_src = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.button5 = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.btn_list_directors = new System.Windows.Forms.Button();
			this.txt_keyword = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.txt_localpath = new System.Windows.Forms.TextBox();
			this.txt_javid = new System.Windows.Forms.TextBox();
			this.txt_movieID = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.cb_updatecast = new System.Windows.Forms.CheckBox();
			this.button10 = new System.Windows.Forms.Button();
			this.button8 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.button9 = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.txt_tags = new System.Windows.Forms.TextBox();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.webBrowser1 = new System.Windows.Forms.WebBrowser();
			((System.ComponentModel.ISupportInitialize)(this.dg_data)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dg_tables)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// dg_data
			// 
			this.dg_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dg_data.Location = new System.Drawing.Point(12, 138);
			this.dg_data.Name = "dg_data";
			this.dg_data.Size = new System.Drawing.Size(904, 405);
			this.dg_data.TabIndex = 0;
			this.dg_data.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
			this.dg_data.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
			// 
			// textBox1
			// 
			this.textBox1.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox1.Location = new System.Drawing.Point(86, 16);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(691, 116);
			this.textBox1.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(23, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(57, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Command:";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(783, 14);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 50);
			this.button1.TabIndex = 3;
			this.button1.Text = "Execute Select";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// dg_tables
			// 
			this.dg_tables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dg_tables.Location = new System.Drawing.Point(931, 304);
			this.dg_tables.Name = "dg_tables";
			this.dg_tables.Size = new System.Drawing.Size(904, 239);
			this.dg_tables.TabIndex = 0;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(1796, 26);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(39, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Tables";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(783, 70);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 3;
			this.button2.Text = "sfrom";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.btn_sfrom_click);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1602, 24);
			this.menuStrip1.TabIndex = 4;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openDatabaseToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// openDatabaseToolStripMenuItem
			// 
			this.openDatabaseToolStripMenuItem.Name = "openDatabaseToolStripMenuItem";
			this.openDatabaseToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
			this.openDatabaseToolStripMenuItem.Text = "&Open Database";
			this.openDatabaseToolStripMenuItem.Click += new System.EventHandler(this.openDatabaseToolStripMenuItem_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(864, 16);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 3;
			this.button3.Text = "Update";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.btn_change_click);
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(1162, 18);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(90, 17);
			this.checkBox1.TabIndex = 5;
			this.checkBox1.Text = "New Window";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(945, 16);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(75, 23);
			this.button4.TabIndex = 3;
			this.button4.Text = "Execute";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.btn_execute_click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.cb_firsttime);
			this.groupBox1.Controls.Add(this.txt_tagcopy_dest);
			this.groupBox1.Controls.Add(this.txt_tagcopy_src);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.button5);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Location = new System.Drawing.Point(931, 46);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(261, 114);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Copy Tags";
			// 
			// cb_firsttime
			// 
			this.cb_firsttime.AutoSize = true;
			this.cb_firsttime.Location = new System.Drawing.Point(44, 80);
			this.cb_firsttime.Name = "cb_firsttime";
			this.cb_firsttime.Size = new System.Drawing.Size(71, 17);
			this.cb_firsttime.TabIndex = 4;
			this.cb_firsttime.Text = "First Time";
			this.cb_firsttime.UseVisualStyleBackColor = true;
			// 
			// txt_tagcopy_dest
			// 
			this.txt_tagcopy_dest.Location = new System.Drawing.Point(57, 50);
			this.txt_tagcopy_dest.Name = "txt_tagcopy_dest";
			this.txt_tagcopy_dest.Size = new System.Drawing.Size(100, 20);
			this.txt_tagcopy_dest.TabIndex = 0;
			// 
			// txt_tagcopy_src
			// 
			this.txt_tagcopy_src.Location = new System.Drawing.Point(57, 24);
			this.txt_tagcopy_src.Name = "txt_tagcopy_src";
			this.txt_tagcopy_src.Size = new System.Drawing.Size(100, 20);
			this.txt_tagcopy_src.TabIndex = 0;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 50);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(32, 13);
			this.label4.TabIndex = 2;
			this.label4.Text = "New:";
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(163, 24);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(75, 23);
			this.button5.TabIndex = 3;
			this.button5.Text = "Copy";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.btn_copy_click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 29);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(33, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "From:";
			// 
			// btn_list_directors
			// 
			this.btn_list_directors.Location = new System.Drawing.Point(864, 549);
			this.btn_list_directors.Name = "btn_list_directors";
			this.btn_list_directors.Size = new System.Drawing.Size(75, 37);
			this.btn_list_directors.TabIndex = 3;
			this.btn_list_directors.Text = "List Movies";
			this.btn_list_directors.UseVisualStyleBackColor = true;
			this.btn_list_directors.Click += new System.EventHandler(this.btn_list_directors_click);
			// 
			// txt_keyword
			// 
			this.txt_keyword.Location = new System.Drawing.Point(735, 549);
			this.txt_keyword.Name = "txt_keyword";
			this.txt_keyword.Size = new System.Drawing.Size(100, 20);
			this.txt_keyword.TabIndex = 0;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(676, 552);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(51, 13);
			this.label5.TabIndex = 2;
			this.label5.Text = "Keyword:";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.txt_localpath);
			this.groupBox2.Controls.Add(this.txt_javid);
			this.groupBox2.Controls.Add(this.txt_movieID);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.cb_updatecast);
			this.groupBox2.Controls.Add(this.button10);
			this.groupBox2.Controls.Add(this.button8);
			this.groupBox2.Controls.Add(this.button7);
			this.groupBox2.Controls.Add(this.button6);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Location = new System.Drawing.Point(1208, 46);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(319, 173);
			this.groupBox2.TabIndex = 6;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Process Movie";
			// 
			// txt_localpath
			// 
			this.txt_localpath.Location = new System.Drawing.Point(57, 105);
			this.txt_localpath.Name = "txt_localpath";
			this.txt_localpath.Size = new System.Drawing.Size(100, 20);
			this.txt_localpath.TabIndex = 0;
			// 
			// txt_javid
			// 
			this.txt_javid.Location = new System.Drawing.Point(57, 50);
			this.txt_javid.Name = "txt_javid";
			this.txt_javid.Size = new System.Drawing.Size(100, 20);
			this.txt_javid.TabIndex = 0;
			// 
			// txt_movieID
			// 
			this.txt_movieID.Location = new System.Drawing.Point(57, 24);
			this.txt_movieID.Name = "txt_movieID";
			this.txt_movieID.Size = new System.Drawing.Size(100, 20);
			this.txt_movieID.TabIndex = 0;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(6, 110);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(56, 13);
			this.label9.TabIndex = 2;
			this.label9.Text = "local path:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 50);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(40, 13);
			this.label6.TabIndex = 2;
			this.label6.Text = "JAVID:";
			// 
			// cb_updatecast
			// 
			this.cb_updatecast.AutoSize = true;
			this.cb_updatecast.Checked = true;
			this.cb_updatecast.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cb_updatecast.Location = new System.Drawing.Point(57, 76);
			this.cb_updatecast.Name = "cb_updatecast";
			this.cb_updatecast.Size = new System.Drawing.Size(85, 17);
			this.cb_updatecast.TabIndex = 5;
			this.cb_updatecast.Text = "Update Cast";
			this.cb_updatecast.UseVisualStyleBackColor = true;
			// 
			// button10
			// 
			this.button10.Location = new System.Drawing.Point(163, 105);
			this.button10.Name = "button10";
			this.button10.Size = new System.Drawing.Size(112, 23);
			this.button10.TabIndex = 3;
			this.button10.Text = "Update Poster Local";
			this.button10.UseVisualStyleBackColor = true;
			this.button10.Click += new System.EventHandler(this.btn_updateposter_local);
			// 
			// button8
			// 
			this.button8.Location = new System.Drawing.Point(163, 76);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(139, 23);
			this.button8.TabIndex = 3;
			this.button8.Text = "Update Poster (PLEX)";
			this.button8.UseVisualStyleBackColor = true;
			this.button8.Click += new System.EventHandler(this.btn_updateposter);
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(163, 48);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(75, 23);
			this.button7.TabIndex = 3;
			this.button7.Text = "Quick";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.btn_quick_click);
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(163, 24);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(75, 23);
			this.button6.TabIndex = 3;
			this.button6.Text = "Process";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.btn_processmovie_click);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(6, 29);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(21, 13);
			this.label7.TabIndex = 2;
			this.label7.Text = "ID:";
			// 
			// button9
			// 
			this.button9.Location = new System.Drawing.Point(1117, 549);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(75, 37);
			this.button9.TabIndex = 3;
			this.button9.Text = "Add Tags";
			this.button9.UseVisualStyleBackColor = true;
			this.button9.Click += new System.EventHandler(this.btn_addtags_click);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(952, 561);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(31, 13);
			this.label8.TabIndex = 2;
			this.label8.Text = "Tags";
			// 
			// txt_tags
			// 
			this.txt_tags.Location = new System.Drawing.Point(1011, 558);
			this.txt_tags.Name = "txt_tags";
			this.txt_tags.Size = new System.Drawing.Size(100, 20);
			this.txt_tags.TabIndex = 0;
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
            "update poster",
            "update director",
            "update by path",
            "update poster by tag"});
			this.comboBox1.Location = new System.Drawing.Point(784, 100);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(141, 21);
			this.comboBox1.TabIndex = 7;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// webBrowser1
			// 
			this.webBrowser1.Location = new System.Drawing.Point(931, 181);
			this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
			this.webBrowser1.Name = "webBrowser1";
			this.webBrowser1.Size = new System.Drawing.Size(643, 405);
			this.webBrowser1.TabIndex = 8;
			this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1602, 598);
			this.Controls.Add(this.webBrowser1);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.txt_tags);
			this.Controls.Add(this.txt_keyword);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.button9);
			this.Controls.Add(this.btn_list_directors);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.dg_tables);
			this.Controls.Add(this.dg_data);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.dg_data)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dg_tables)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dg_data;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dg_tables;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openDatabaseToolStripMenuItem;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_tagcopy_dest;
        private System.Windows.Forms.TextBox txt_tagcopy_src;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_list_directors;
        private System.Windows.Forms.TextBox txt_keyword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt_javid;
        private System.Windows.Forms.TextBox txt_movieID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox cb_updatecast;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_tags;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.TextBox txt_localpath;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.CheckBox cb_firsttime;
    }
}

