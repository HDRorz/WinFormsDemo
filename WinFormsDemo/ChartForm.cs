using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsDemo
{
    public partial class ChartForm : Form
    {

        private List<KeyValuePair<int, int>> data = new List<KeyValuePair<int, int>>()
        {
            new KeyValuePair<int, int>(1,10),
            new KeyValuePair<int, int>(2,6),
            new KeyValuePair<int, int>(3,1),
            new KeyValuePair<int, int>(4,-4),
            new KeyValuePair<int, int>(5,8),
            new KeyValuePair<int, int>(6,0),
            new KeyValuePair<int, int>(7,2),
            new KeyValuePair<int, int>(8,-7),
            new KeyValuePair<int, int>(9,-3),
            new KeyValuePair<int, int>(10,5),
            new KeyValuePair<int, int>(11,8),
            new KeyValuePair<int, int>(12,2),

        };


        public ChartForm()
        {
            InitializeComponent();

            Init();
        }

        public void Init()
        {
            chart1.Series[0].Name = "数据1";
            chart1.Series[0].LegendText = "月份";
            chart1.Series[0].Points.DataBindXY(data.Select(item => item.Key).ToList(), data.Select(item => item.Value).ToList());
            chart1.ChartAreas.FirstOrDefault().AxisX.IsStartedFromZero = false;
            chart1.ChartAreas.FirstOrDefault().AxisX.Minimum = data.Min(item => item.Key);
            chart1.ChartAreas.FirstOrDefault().AxisX.Maximum = data.Max(item => item.Key);
            //var x = chart1.ChartAreas.FirstOrDefault().Axes.FirstOrDefault(item => item.GetPosition(0) == 0);

            //chart1.ChartAreas.FirstOrDefault().Axes.FirstOrDefault(item => item.Crossing == 0).LineWidth = 2;
            chart1.Invalidate();
        }
    }
}
