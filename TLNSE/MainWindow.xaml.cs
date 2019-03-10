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
        public string[] arrLine;
        string chosenFile = "ttttt";
        int init = new int();

        int[] arrCheck = { 205, 203, 202, 201, 206, 208, 209, 211, 213 };
        int[] arrText = { 101, 102, 111, 112, 113, 114, 115, 116, 117, 107, 119 };

        MapWindow win2 = new MapWindow();


        public MainWindow()
        {
            InitializeComponent();
            this.Closing += Window_Closing;

            buttOpen.Click += ButtonOpenFile;
            buttClose.Click += ButtonSaveFile;
            MapButton.Click += MapWindowOpen;
            
            foreach (int linea in arrCheck)
            {
                string illo = "_" + linea;
                CheckBox check = GridMain.FindName(illo) as CheckBox;
                check.Checked += ArrayWrite;
                check.Unchecked += ArrayWrite;
            }
            foreach (int linea in arrText)
            {
                string illo = "_" + linea;
                TextBox check = GridMain.FindName(illo) as TextBox;
                check.TextChanged += ArrayWrite;
            }

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
                foreach (int linea in arrCheck)
                {
                    string illo = "_" + linea;
                    CheckBox check = GridMain.FindName(illo) as CheckBox;
                    if (check.IsChecked == true)
                    {
                        arrLine[linea - 1] = "1";
                    }
                    else if (check.IsChecked == false)
                    {
                        arrLine[linea - 1] = "0";
                    }
                }
                foreach (int linea in arrText)
                {
                    string illo = "_" + linea;
                    TextBox check = GridMain.FindName(illo) as TextBox;
                    arrLine[linea - 1] = check.Text;
                }
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

            foreach (int linea in arrCheck)
            {
                string illo = "_" + linea;
                CheckBox check = GridMain.FindName(illo) as CheckBox;
                check.IsEnabled = true;
            }
            foreach (int linea in arrText)
            {
                string illo = "_" + linea;
                TextBox check = GridMain.FindName(illo) as TextBox;
                check.IsEnabled = true;
            }

            init = 1;
        }

        public void Check(string[] arrLine)
        {
            foreach (int linea in arrCheck)
            {
                string illo = "_" + linea;
                CheckBox check = GridMain.FindName(illo) as CheckBox;
                if (arrLine[linea - 1] == "0")
                {
                    check.IsChecked = false;
                }
                else if (arrLine[linea - 1] == "1")
                {
                    check.IsChecked = true;
                }
            }
            foreach (int linea in arrText)
            {
                string illo = "_" + linea;
                TextBox check = GridMain.FindName(illo) as TextBox;
                check.Text = arrLine[linea - 1];
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
