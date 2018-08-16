using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsDemo.MyTabControl
{
    public class MyTabNavItem : UserControl
    {
        public MyTabControl TabControl { get; private set; } = null;
        public MyTabPage TabPage { get; private set; } = null;

        private string header = "";
        public string Header
        {
            get
            {
                return header;
            }
            set
            {
                header = value;
                this.label1.Text = header;
            }
        }

        private bool isActived = false;
        public bool IsActived
        {
            get
            {
                return isActived;
            }
            set
            {
                isActived = value;
                MyTabNavItem_ActivedChanged(this, new EventArgs());
            }
        }

        #region controls

        private FlowLayoutPanel flowLayoutPanel;
        private Label label1;
        private MyTabCloseButton tabCloseButton;
        
        #endregion

        public MyTabNavItem(MyTabControl tabControl, MyTabPage tabPage)
        {
            this.TabControl = tabControl ?? throw new ArgumentNullException();
            this.TabPage = tabPage ?? throw new ArgumentNullException();
            InitializeComponent();
            this.header = TabPage.Header;
            this.label1.Refresh();
        }

        private void InitializeComponent()
        {
            flowLayoutPanel = new FlowLayoutPanel();
            label1 = new Label();
            tabCloseButton = new MyTabCloseButton();
            // label1
            this.label1.Margin = new Padding(0);
            this.label1.MinimumSize = new Size(60, 12);
            this.label1.Text = "载入中";
            // tabCloseButton
            this.tabCloseButton.Margin = new Padding(10, 2, 0, 2);
            this.tabCloseButton.Size = new Size(8, 8);
            this.tabCloseButton.Click += MyTabCloseButton_Click;
            // flowLayoutPanel
            this.flowLayoutPanel.Dock = DockStyle.Fill;
            this.flowLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
            this.flowLayoutPanel.WrapContents = false;
            this.flowLayoutPanel.Margin = new Padding(10);
            this.flowLayoutPanel.Controls.Add(label1);
            this.flowLayoutPanel.Controls.Add(tabCloseButton);
            //MyTabNavItem
            this.SuspendLayout();
            this.Font = new Font("微软雅黑", 12, GraphicsUnit.Pixel);
            this.BorderStyle = BorderStyle.None;
            this.Controls.Add(flowLayoutPanel);
            this.Click += MyTabNavItem_Click;
            this.ResumeLayout(false);
        }

        private void MyTabNavItem_Click(object sender, EventArgs e)
        {
            TabControl.AcitveTabNavItem(this);
        }

        private void MyTabCloseButton_Click(object sender, EventArgs e)
        {
            TabControl.CloseTabPage(this);
        }

        private void MyTabNavItem_ActivedChanged(object sender, EventArgs e)
        {
            if (this.IsActived)
            {
                this.BorderStyle = BorderStyle.FixedSingle;
            }
            else
            {
                this.BorderStyle = BorderStyle.None;
            }
        }

    }
}
