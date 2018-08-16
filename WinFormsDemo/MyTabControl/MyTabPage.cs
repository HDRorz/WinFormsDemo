using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsDemo.MyTabControl
{
    public class MyTabPage : UserControl
    {
        public MyTabControl TabControl { get; private set; } = null;
        public string Header { get; private set; } = "";

        private Control Content = null;

        public MyTabPage(MyTabControl tabControl, string header, Control content)
        {
            this.TabControl = tabControl ?? throw new ArgumentNullException();
            this.Header = header ?? throw new ArgumentNullException();
            this.Content = content ?? throw new ArgumentNullException();
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.BackColor = System.Drawing.Color.Transparent;
            this.AutoScroll = true;
            this.Controls.Add(Content);
            this.ResumeLayout(false);
        }
    }
}
