using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsDemo.MyTabControl
{
    public class MyTabNav : UserControl
    {
        public MyTabControl TabControl { get; private set; } = null;

        #region control

        private FlowLayoutPanel flowLayoutPanel;

        private List<MyTabNavItem> TabNavItems = new List<MyTabNavItem>();
        #endregion


        public MyTabNav(MyTabControl tabControl)
        {
            this.TabControl = tabControl ?? throw new ArgumentNullException();
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.flowLayoutPanel = new FlowLayoutPanel();
            // flowLayoutPanel
            this.flowLayoutPanel.Dock = DockStyle.Fill;
            this.flowLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
            this.flowLayoutPanel.HorizontalScroll.Visible = false;
            this.flowLayoutPanel.Margin = new Padding(0);
            this.flowLayoutPanel.WrapContents = false;
            this.SuspendLayout();
            this.Controls.Add(flowLayoutPanel);
            this.ResumeLayout(false);
        }

        private void MyTabNav_Click(object sender, EventArgs e)
        {

        }

        public void AddTabNavItem(MyTabNavItem item)
        {
            this.SuspendLayout();
            this.flowLayoutPanel.Controls.Add(item);
            this.ResumeLayout(false);
            this.TabNavItems.Add(item);
            this.ActiveTabNavItem(item);
        }

        public void RemoveTabNavItem(MyTabNavItem item)
        {
            MyTabNavItem nextItem = null;
            try
            {
                var index = this.flowLayoutPanel.Controls.IndexOf(item);
                this.flowLayoutPanel.Controls.Remove(item);
                this.TabNavItems.Remove(item);
                if (index > this.flowLayoutPanel.Controls.Count - 1)
                {
                    index = this.flowLayoutPanel.Controls.Count - 1;
                }
                nextItem = (MyTabNavItem)this.flowLayoutPanel.Controls[index];
            }
            catch
            {

            }
            if (nextItem != null)
            {
                TabControl.AcitveTabNavItem(nextItem);
            }
        }

        public void ActiveTabNavItem(MyTabNavItem item)
        {
            var old = this.TabNavItems.FirstOrDefault(nav => nav.IsActived == true);
            if (old == item)
            {
                return;
            }

            if (old != null)
            {
                old.IsActived = false;
            }
            item.IsActived = true;
        }
    }
}
