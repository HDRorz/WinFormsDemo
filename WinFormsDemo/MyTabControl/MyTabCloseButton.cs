using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
            label = new Label();
            label.Text = "×";
            this.SuspendLayout();
            // 
            // MyTabCloseButton
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Font = new System.Drawing.Font("黑体", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "MyTabCloseButton";
            this.Size = new System.Drawing.Size(8, 815);
            this.MouseHover += MyTabCloseButton_MouseHover;
            this.MouseLeave += MyTabCloseButton_MouseLeave;
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
