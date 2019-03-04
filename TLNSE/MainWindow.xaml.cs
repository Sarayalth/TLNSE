using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TLNSE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public string[] arrLine = new string[5];
        public string[] arrLine;
        string chosenFile = "ttttt";
        int init = new int();

        MapWindow win2 = new MapWindow();


        public MainWindow()
        {
            InitializeComponent();
            //string[] arrLine = File.ReadAllLines(chosenFile);
            this.Closing += Window_Closing;


            buttOpen.Click += ButtonOpenFile;
            buttClose.Click += ButtonSaveFile;
            MapButton.Click += MapWindowOpen;
            //croqueta.Click += Test;

            x.TextChanged += ArrayWrite;
            y.TextChanged += ArrayWrite;

            Amethyst.TextChanged += ArrayWrite;
            Aquamarine.TextChanged += ArrayWrite;
            Topaz.TextChanged += ArrayWrite;
            Ruby.TextChanged += ArrayWrite;
            Sapphire.TextChanged += ArrayWrite;
            Emerald.TextChanged += ArrayWrite;
            Diamond.TextChanged += ArrayWrite;
            Exp.TextChanged += ArrayWrite;
            Gold.TextChanged += ArrayWrite;

            Meiling.Checked += ArrayWrite;
            Meiling.Unchecked += ArrayWrite;
            Intro.Checked += ArrayWrite;
            Intro.Unchecked += ArrayWrite;
            NitoriRobot.Checked += ArrayWrite;
            NitoriRobot.Unchecked += ArrayWrite;
            HiedaNoAkyuu.Checked += ArrayWrite;
            HiedaNoAkyuu.Unchecked += ArrayWrite;
            AkyuuCall.Checked += ArrayWrite;
            AkyuuCall.Unchecked += ArrayWrite;
            FirstUseWatch.Checked += ArrayWrite;
            FirstUseWatch.Unchecked += ArrayWrite;
            WaterWalk.Checked += ArrayWrite;
            WaterWalk.Unchecked += ArrayWrite;
            FirstDrink.Checked += ArrayWrite;
            FirstDrink.Unchecked += ArrayWrite;
            NitoriCall.Checked += ArrayWrite;
            NitoriCall.Unchecked += ArrayWrite;

            init = 0;
            test.Click += TestButton;
        }
        public void TestButton(object sender, RoutedEventArgs e)
        {
            int start = 770;
            int end = 806;
            int current = start;
            int[] intArr = new int[40];

            while (current != end)
            {
                current = current+1;
                intArr[init] = current;
                init++;
            }

            test2.Text = string.Join(", ", intArr);
        }

        public void MapWindowOpen(object sender, RoutedEventArgs e)
        {
            win2.CheckArray(arrLine);

            win2.ShowDialog();

            win2.ArrayWrite(arrLine);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            win2.CloseForReal();
        }

        public void ArrayWrite(object sender, RoutedEventArgs e)
        {
            if (init == 1)
            {
                //Meiling
                if (Meiling.IsChecked == true)
                {
                    arrLine[205 - 1] = "1";
                }
                else if (Meiling.IsChecked == false)
                {
                    arrLine[205 - 1] = "0";
                }

                //Intro
                if (Intro.IsChecked == true)
                {
                    arrLine[203 - 1] = "1";
                }
                else if (Intro.IsChecked == false)
                {
                    arrLine[203 - 1] = "0";
                }

                //Nitori Robot
                if (NitoriRobot.IsChecked == true)
                {
                    arrLine[202 - 1] = "1";
                }
                else if (NitoriRobot.IsChecked == false)
                {
                    arrLine[202 - 1] = "0";
                }

                //Hieda no Akyuu
                if (HiedaNoAkyuu.IsChecked == true)
                {
                    arrLine[201 - 1] = "1";
                }
                else if (HiedaNoAkyuu.IsChecked == false)
                {
                    arrLine[201 - 1] = "0";
                }

                //Akyuu's Call
                if (AkyuuCall.IsChecked == true)
                {
                    arrLine[206 - 1] = "1";
                }
                else if (AkyuuCall.IsChecked == false)
                {
                    arrLine[206 - 1] = "0";
                }

                //First Use Watch
                if (FirstUseWatch.IsChecked == true)
                {
                    arrLine[208 - 1] = "1";
                }
                else if (FirstUseWatch.IsChecked == false)
                {
                    arrLine[208 - 1] = "0";
                }

                //Water Walk
                if (WaterWalk.IsChecked == true)
                {
                    arrLine[209 - 1] = "1";
                }
                else if (WaterWalk.IsChecked == false)
                {
                    arrLine[209 - 1] = "0";
                }

                //First Drink
                if (FirstDrink.IsChecked == true)
                {
                    arrLine[211 - 1] = "1";
                }
                else if (FirstDrink.IsChecked == false)
                {
                    arrLine[211 - 1] = "0";
                }

                //Nitori Call
                if (NitoriCall.IsChecked == true)
                {
                    arrLine[213 - 1] = "1";
                }
                else if (NitoriCall.IsChecked == false)
                {
                    arrLine[213 - 1] = "0";
                }

                arrLine[101 - 1] = x.Text;
                arrLine[102 - 1] = y.Text;
                arrLine[111 - 1] = Amethyst.Text;
                arrLine[112 - 1] = Aquamarine.Text;
                arrLine[113 - 1] = Topaz.Text;
                arrLine[114 - 1] = Ruby.Text;
                arrLine[115 - 1] = Sapphire.Text;
                arrLine[116 - 1] = Emerald.Text;
                arrLine[117 - 1] = Diamond.Text;
                arrLine[107 - 1] = Exp.Text;
                arrLine[119 - 1] = Gold.Text;
            }
        }

        public void ButtonOpenFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            chosenFile = "";

            dlg.Title = "Select a sav file";
            dlg.InitialDirectory = Environment.SpecialFolder.Personal + @"\AppData\Local\touhou_luna_nights";
            dlg.FileName = "Choose a file..";
            dlg.Filter = "sav|*.sav|All Files|*.*";

            if (dlg.ShowDialog() != DialogResult == true)
            {
                chosenFile = dlg.FileName;
                int i = 0;
                arrLine = File.ReadAllLines(chosenFile);
                foreach (string linea in arrLine)
                {
                    byte[] data = Convert.FromBase64String(linea);
                    string decodedString = Encoding.UTF8.GetString(data);
                    arrLine[i++] = decodedString;
                }
                Check(arrLine);
            }
            buttOpen.IsEnabled = false;
            buttClose.IsEnabled = true;
            MapButton.IsEnabled = true;

            x.IsEnabled = true;
            y.IsEnabled = true;

            Meiling.IsEnabled = true;

            Intro.IsEnabled = true;
            NitoriRobot.IsEnabled = true;
            HiedaNoAkyuu.IsEnabled = true;
            AkyuuCall.IsEnabled = true;
            FirstUseWatch.IsEnabled = true;
            WaterWalk.IsEnabled = true;
            FirstDrink.IsEnabled = true;
            NitoriCall.IsEnabled = true;

            Amethyst.IsEnabled = true;
            Aquamarine.IsEnabled = true;
            Topaz.IsEnabled = true;
            Ruby.IsEnabled = true;
            Sapphire.IsEnabled = true;
            Emerald.IsEnabled = true;
            Diamond.IsEnabled = true;
            Exp.IsEnabled = true;
            Gold.IsEnabled = true;

            init = 1;
        }

        public void Check(string[] arrLine)
        {
            //Coordinates
            x.Text = arrLine[101 - 1];
            y.Text = arrLine[102 - 1];

            //Gems
            Amethyst.Text = arrLine[111 - 1];
            Aquamarine.Text = arrLine[112 - 1];
            Topaz.Text = arrLine[113 - 1];
            Ruby.Text = arrLine[114 - 1];
            Sapphire.Text = arrLine[115 - 1];
            Emerald.Text = arrLine[116 - 1];
            Diamond.Text = arrLine[117 - 1];

            //Exp and Gold
            Exp.Text = arrLine[107 - 1];
            Gold.Text = arrLine[119 - 1];
            
            //Meiling
            if (arrLine[205-1] == "0")
            {
                Meiling.IsChecked = false;
            }
            else if (arrLine[205-1] == "1")
            {
                Meiling.IsChecked = true;
            }

            //Intro
            if (arrLine[203 - 1] == "0")
            {
                Intro.IsChecked = false;
            }
            else if (arrLine[203 - 1] == "1")
            {
                Intro.IsChecked = true;
            }

            //Nitori Robot
            if (arrLine[202 - 1] == "0")
            {
                NitoriRobot.IsChecked = false;
            }
            else if (arrLine[202 - 1] == "1")
            {
                NitoriRobot.IsChecked = true;
            }

            //Hieda no Akyuu
            if (arrLine[201 - 1] == "0")
            {
                HiedaNoAkyuu.IsChecked = false;
            }
            else if (arrLine[201 - 1] == "1")
            {
                HiedaNoAkyuu.IsChecked = true;
            }

            //Akyuu's Call
            if (arrLine[206 - 1] == "0")
            {
                AkyuuCall.IsChecked = false;
            }
            else if (arrLine[206 - 1] == "1")
            {
                AkyuuCall.IsChecked = true;
            }

            //First Use Watch
            if (arrLine[208 - 1] == "0")
            {
                FirstUseWatch.IsChecked = false;
            }
            else if (arrLine[208 - 1] == "1")
            {
                FirstUseWatch.IsChecked = true;
            }

            //Water Walk
            if (arrLine[209 - 1] == "0")
            {
                WaterWalk.IsChecked = false;
            }
            else if (arrLine[209 - 1] == "1")
            {
                WaterWalk.IsChecked = true;
            }

            //First Drink
            if (arrLine[211 - 1] == "0")
            {
                FirstDrink.IsChecked = false;
            }
            else if (arrLine[211 - 1] == "1")
            {
                FirstDrink.IsChecked = true;
            }

            //Nitori Call
            if (arrLine[213 - 1] == "0")
            {
                NitoriCall.IsChecked = false;
            }
            else if (arrLine[213 - 1] == "1")
            {
                NitoriCall.IsChecked = true;
            }
        }

        public void ButtonSaveFile(object sender, RoutedEventArgs e)
        {
            string[] arrLineSave = new string[arrLine.Length]; 
            Array.Copy(arrLine, arrLineSave, arrLine.Length);
            int i = 0;
            foreach (string linea in arrLineSave)
            {
                byte[] toEncodeAsBytes = Encoding.UTF8.GetBytes(linea);
                string data = Convert.ToBase64String(toEncodeAsBytes);
                arrLineSave[i++] = data;
            }
            File.WriteAllLines(chosenFile, arrLineSave);
            Array.Clear(arrLineSave, 0, arrLineSave.Length);
        }
    }    
}
