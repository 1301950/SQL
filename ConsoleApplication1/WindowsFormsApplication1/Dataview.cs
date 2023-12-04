using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Dataview : Form
    {
        public string url;
        public Dataview()
        {
            InitializeComponent();
            
        }

        public void SetData(DataTable ds)
        {
            subview.DataSource = ds;
        }

        public void SetData(List<KeyValuePair<string, string>> d, string title)
        {
            subview.DataSource = d;
            lbl_title.Text = title;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (subview.SelectedRows.Count > 0)
            {
                url = subview.SelectedRows[0].Cells[0].Value.ToString();
            }
            this.Close();
        }
    }
}
