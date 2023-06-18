using System;
using System.IO;
using System.Drawing;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Windows.Forms;
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
using MetroApp.DB;
using MetroApp.ClassHelper;
using MetroApp.Pages;
using MetroApp.Windows;

namespace MetroApp
{
    public partial class MainWindow : Window
    {
        public bool admin;

        public MainWindow()
        {
            InitializeComponent();
            mainFrame.Content = new MainPage();
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Content = new MainPage();
        }

        private void btnAboutUs_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Content = new AboutUsPage();
        }

        private void btnEditor_Click(object sender, RoutedEventArgs e)
        {
            SignUpWindow signUpWindow = new SignUpWindow();
            ManagerPage managerPage = new ManagerPage();

            string pathPsswrd = "C:/qwerty/psswrd.txt";
            string pathValid = "C:/qwerty/valid.txt";
            string checkPsswrd;
            string checkValid;

            using (StreamReader readerP = new StreamReader(pathPsswrd)) checkPsswrd = readerP.Read().ToString();
            using (StreamReader readerV = new StreamReader(pathValid)) checkValid = readerV.Read().ToString();

            if (checkPsswrd != checkValid)
            {
                this.Opacity = 0.2;
                signUpWindow.ShowDialog();
                this.Opacity = 1;
                using (StreamReader readerP = new StreamReader(pathPsswrd)) checkPsswrd = readerP.Read().ToString();
                using (StreamReader readerV = new StreamReader(pathValid)) checkValid = readerV.Read().ToString();
                if (checkPsswrd == checkValid)
                {
                    mainFrame.Content = new ManagerPage();
                }
            }
            else
            {
                mainFrame.Content = new ManagerPage();
            }
        }

        private void btnMapList_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Content = new MapListPage();
        }

        private void btnStatistic_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Content = new StationStatPage();
        }
    }
}