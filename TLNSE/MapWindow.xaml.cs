using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TLNSE
{
    /// <summary>
    /// Interaction logic for MapWindow.xaml
    /// </summary>
    public partial class MapWindow : Window
    {
        int FUCKINGCLOSENOW = 0;

        int[] arrMap = { 770, 771, 772, 773, 774, 775, 776, 777, 778, 779, 780, 781, 782, 783, 784, 785, 786, 787, 788, 789, 790, 791, 792, 793, 794, 795, 796, 797, 798, 799, 800, 801, 802, 803, 804, 805, 806 };

        public MapWindow()
        {
            InitializeComponent();

            this.Closing += Window_Closing;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (FUCKINGCLOSENOW == 0)
            {
                e.Cancel = true;
                this.Visibility = Visibility.Hidden;
            }
        }

        public void CloseForReal()
        {
            FUCKINGCLOSENOW = 1;
            this.Close();
        }

        public void CheckArray(string[] arrLine)
        {
            foreach (int linea in arrMap)
            {
                string illo = "_" + linea;
                CheckBox check = Grillao.FindName(illo) as CheckBox;

                if (arrLine[linea - 1] == "0")
                {
                    check.IsChecked = false;
                }
                else if (arrLine[linea - 1] == "1")
                {
                    check.IsChecked = true;
                }
            }
        }

        public void ArrayWrite(string[] arrLine)
        {
            //Map
            foreach (int linea in arrMap)
            {
                string illo = "_" + linea;
                //CheckBox cb = illo as CheckBox;
                CheckBox check = Grillao.FindName(illo) as CheckBox;

                if (check.IsChecked == true)
                {
                    arrLine[linea - 1] = "1";
                }
                else if (check.IsChecked == false)
                {
                    arrLine[linea - 1] = "0";
                }
            }
        }
    }
}
