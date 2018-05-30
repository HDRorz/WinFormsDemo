using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Forms;

namespace WinFormsDemo
{
    public partial class DataInputForm : Form
    {
        public DataInputForm()
        {
            InitializeComponent();
        }

        private void Submit_Button_Click(object sender, EventArgs e)
        {
            //((MainForm)Owner).ShareData = textBox1.Text;
            SetShareData();

            MessageHelper.PostMessage(Owner, "", "", textBox1.Text);
            MessageHelper.SendMessage(Owner, "", "", textBox1.Text);

            this.Close();
        }

        private void SetShareData()
        {
            var formType = Owner.GetType();
            var pi = formType.GetProperty("ShareData");
            pi.SetValue(Owner, textBox1.Text);
        }
    }
}
