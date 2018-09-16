using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsDemo.MyTabControl
{
    public class MyTabCloseButton : UserControl
    {
        private Label label;

        public MyTabCloseButton()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.label = new Label();
            this.SuspendLayout();
            // label
            this.label.Dock = DockStyle.None;
            this.label.Location = new Point(2, 1);
            this.label.Size = new Size(10, 10);
            this.label.Text = "×";
            this.label.TextAlign = ContentAlignment.MiddleCenter;
            this.label.MouseHover += MyTabCloseButton_MouseHover;
            this.label.MouseLeave += MyTabCloseButton_MouseLeave;
            this.label.Click += (sender, e) => this.OnClick(e);
            // 
            // MyTabCloseButton
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Font = new System.Drawing.Font("黑体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ForeColor = System.Drawing.Color.Black;
            this.Size = new System.Drawing.Size(12, 12);
            this.Controls.Add(this.label);
            this.ResumeLayout(false);

        }

        private void MyTabCloseButton_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.Transparent;
        }

        private void MyTabCloseButton_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(200, 200, 200);
        }
    }
}
