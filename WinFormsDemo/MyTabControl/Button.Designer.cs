using System.Drawing;
using System.Windows.Forms;

namespace WinFormsDemo.MyTabControl
{
    partial class Button
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            //components = new System.ComponentModel.Container();
            flowLayoutPanel = new FlowLayoutPanel();
            label1 = new Label();
            tabCloseButton = new MyTabCloseButton();
            // label1
            this.label1.Margin = new Padding(0);
            this.label1.MinimumSize = new Size(60, 12);
            // tabCloseButton
            this.tabCloseButton.Margin = new Padding(10, 2, 0, 2);
            this.Size = new Size(8, 8);
            // flowLayoutPanel
            this.flowLayoutPanel.Margin = new Padding(10);
            this.Controls.Add(label1);
            this.Controls.Add(tabCloseButton);
            //MyTabNavItem
            this.SuspendLayout();
            this.Font = new Font("微软雅黑", 12, GraphicsUnit.Pixel);
            this.Controls.Add(flowLayoutPanel);
            this.ResumeLayout();
        }

        #endregion


        #region controls

        private FlowLayoutPanel flowLayoutPanel = null;
        private Label label1 = null;
        private MyTabCloseButton tabCloseButton = null;

        #endregion
    }
}
