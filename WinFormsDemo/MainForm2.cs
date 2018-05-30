using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsDemo
{
    public partial class MainForm2 : Form
    {
        private string _ShareData;
        public string ShareData
        {
            get
            {
                return _ShareData;
            }
            set
            {
                _ShareData = value;
                ShareData_Changed();
            }
        }

        //替代DateTable用于DateGridView的DateSource，可以引发事件使DateGridView更新
        private BindingList<Worker.Result> Results = new BindingList<Worker.Result>();

        public MainForm2()
        {
            InitializeComponent();

            Init();
        }

        private void Init()
        {
            dataGridView1.DataSource = Results;
        }

        private void Input_Button_Click(object sender, EventArgs e)
        {
            Input_Button.Enabled = false;
            Start_Button.Enabled = false;

            var newForm = new DataInputForm();
            //show传入父窗口，可以让子窗口的owner属性是父窗口
            newForm.Show(this);
            newForm.FormClosed += DataInputForm_FormClosed;
        }

        private void DataInputForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Input_Button.Enabled = true;
            Start_Button.Enabled = true;
        }

        private void Start_Button_Click(object sender, EventArgs e)
        {
            Start_Button.Enabled = false;
            Input_Button.Enabled = false;
            progressBar1.Visible = true;
            progressBar1.Value = 0;

            backgroundWorker1.RunWorkerAsync();
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < Results.Count; i++)
            {
                Results[i].RandomValue = Worker.DoSth(Results[i].Key);
                //每行更新绑定
                Results.ResetItem(i);
                //调整进度
                backgroundWorker1.ReportProgress((i + 1) * 100 / Results.Count);
            }
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Visible = false;
            Start_Button.Enabled = true;
            Input_Button.Enabled = true;
        }

        private void BackgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void ShareData_Changed()
        {
            var keys = ShareData.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Select(str => str.Trim());
            while (Results.Count > 0)
            {
                Results.RemoveAt(0);
            }
            keys.All(item => { Results.Add(new Worker.Result() { Key = item }); return true; });
            //全部更新绑定
            Results.ResetBindings();
        }

        private void AsyncExceptionHandle(AggregateException ex)
        {
            MessageBox.Show(string.Join(Environment.NewLine, ex.InnerExceptions), ex.ToString());
        }
    }
}
