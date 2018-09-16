using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsDemo.MyTabControl
{
    public class MyTabControl : UserControl
    {

        #region control

        private TableLayoutPanel tableLayoutPanel;

        private MyTabPageBox TabPageBox;

        private MyTabNav TabNav;
        #endregion


        public MyTabControl()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            tableLayoutPanel = new TableLayoutPanel();
            TabPageBox = new MyTabPageBox(this);
            TabPageBox.Dock = DockStyle.Fill;
            TabNav = new MyTabNav(this);
            TabNav.Dock = DockStyle.Fill;
            this.SuspendLayout();
            // tableLayoutPanel
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.tableLayoutPanel.Dock = DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(TabNav, 0, 0);
            this.tableLayoutPanel.Controls.Add(TabPageBox, 0, 1);
            this.Controls.Add(this.tableLayoutPanel);
            this.ResumeLayout(false);
        }

        private void MyTabControl_Click(object sender, EventArgs e)
        {
            this.OnClick(EventArgs.Empty);
        }

        public void AddPage()
        {
            string header = Guid.NewGuid().ToString("N");
            var panel = new Panel();
            var label = new Label();
            label.Text = header;
            panel.Controls.Add(label);
            //var page = new MyTabPage(this, header, panel);
            //var navItem = new MyTabNavItem(this, page);
            AddPage(header, panel);
        }

        public void AddPage(string header, Control content)
        {
            var page = new MyTabPage(this, header, content);
            var navItem = new MyTabNavItem(this, page);
            TabNav.AddTabNavItem(navItem);
            TabPageBox.ActiveTabPage(page);
        }

        public void AcitveTabNavItem(MyTabNavItem item)
        {
            TabNav.ActiveTabNavItem(item);
        }

        public void ActiveTabPage(MyTabPage tabPage)
        {
            TabPageBox.ActiveTabPage(tabPage);
        }

        public void CloseTabPage(MyTabNavItem item)
        {
            
        }

    }
}
