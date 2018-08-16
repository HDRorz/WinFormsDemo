using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsDemo.MyTabControl
{
    public class MyTabPageBox : UserControl
    {

        public MyTabControl TabControl { get; private set; } = null;
        public MyTabPage ActivedTabPage { get; private set; } = null;

        public MyTabPageBox(MyTabControl tabControl)
        {
            this.TabControl = tabControl ?? throw new ArgumentNullException();
            InitializeComponent();
        }

        private void InitializeComponent()
        {

        }

        public void ActiveTabPage(MyTabPage tabPage)
        {
            if (ActivedTabPage != null)
            {
                UnActiveTabPage(ActivedTabPage);
            }

            tabPage.Location = new System.Drawing.Point(this.Size.Width + 1, 0);
            tabPage.Size = this.Size;
            if (!this.Controls.Contains(tabPage))
            {
                this.Controls.Add(tabPage);
            }
            this.SuspendLayout();
            tabPage.Location = new System.Drawing.Point(0, 0);
            tabPage.Show();
            this.ResumeLayout(false);
            this.ActivedTabPage = tabPage;
        }

        public void UnActiveTabPage(MyTabPage tabPage)
        {
            this.SuspendLayout();
            tabPage.Location = new System.Drawing.Point(-this.Size.Width - 1, 0);
            this.ResumeLayout(false);
            this.ActivedTabPage = null;
        }

        public void RemoveTabPage(MyTabPage tabPage)
        {
            try
            {
                this.Controls.Remove(tabPage);
            }
            catch
            {

            }
        }

    }
}
