using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logilingua_Reborn
{
    class ViewManager
    {
        private static Form1 mainView;
        private static GraphView graphView;

        public static void ChangeToGraph(Form1 mainViewI)
        {
            mainView = mainViewI;
            mainView.Hide();
            if (graphView == null)
            {
                graphView = new GraphView();
            }
            graphView.Show();
            graphView.SetUp();
        }
        public static void ChangeToMainViewFromGraph()
        {
            graphView.Hide();
            mainView.Show();
        }
    }
}
