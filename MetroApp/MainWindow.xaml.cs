using System;
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

        public MainWindow()
        {
            InitializeComponent();
            mainFrame.Content = new MainPage();
            ActivityTitle.Text = Menu.Content.ToString();
        }

        private void Editor_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Content = new EditorPage();
            ActivityTitle.Text = Editor.Content.ToString();
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Content = new MainPage();
            ActivityTitle.Text = Menu.Content.ToString();
        }

        private void btnLineList_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Content = new LineListPage();
            ActivityTitle.Text = btnLineList.Content.ToString() + " метро";
        }

        private void btnAboutUs_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Content = new AboutUsPage();
            ActivityTitle.Text = btnAboutUs.Content.ToString();
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            SignInWindow signInWindow = new SignInWindow();
            this.Opacity = 0.2;
            signInWindow.ShowDialog();
            this.Opacity = 1;
        }
    }
}