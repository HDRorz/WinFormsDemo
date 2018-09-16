using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsDemo
{
    public partial class TabControlForm : Form
    {
        private MyTabControl.MyTabControl MyTabControl = null;

        public TabControlForm()
        {
            InitializeComponent();

            Init();
        }

        private void Init()
        {
            MyTabControl = new MyTabControl.MyTabControl();
            MyTabControl.Dock = DockStyle.Fill;
            MyTabControl.Enabled = true;
            MyTabControl.Name = "MyTabControl";
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.Controls.Add(MyTabControl, 0, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            MyTabControl.Show();

            MyTabControl.Click += MyTabControl_Click;
            MyTabControl.MouseClick += MyTabControl_MouseClick;
        }

        private void MyTabControl_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void MyTabControl_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyTabControl.AddPage();
        }
    }
}
