using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logilingua_Reborn
{
    public partial class GraphView : Form
    {
        public GraphView()
        {
            InitializeComponent();
        }
        public void SetUp()
        {
            chart1.Series["Points"].Points.AddXY(12,12);
            chart1.Series["Points"].Points[0].Label = "Test";
            chart1.Series["Points"].Points.AddXY(12, 15);
            chart1.Series["Points"].Points[1].Label = "Test1";
            chart1.Series["Points"].Points.AddXY(32, 20);
            chart1.Series["Points"].Points[2].Label = "Test2";
            GraphPlotting mamaPlottting = new GraphPlotting("mama");
        }
        private void GoBackButton_Click(object sender, EventArgs e)
        {
            ViewManager.ChangeToMainViewFromGraph();
        }

        private void GraphView_FormClosing(object sender, FormClosingEventArgs e)
        {
            ViewManager.ChangeToMainViewFromGraph();
        }
    }
}
