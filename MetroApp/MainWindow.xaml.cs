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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MetroApp.DB;
using MetroApp.ClassHelper;

namespace MetroApp
{
    public partial class MainWindow : Window
    {
        List<string> listMap = new List<string>() { "Москва", "Мидлбург", "Лайт Сити (Город Света)", "Капитолий", "Оруэлл" };

        public MainWindow()
        {
            InitializeComponent();

            cmbMap.ItemsSource = listMap;
            cmbMap.SelectedIndex = 0;

            dpDate.SelectedDate = DateTime.Now;

            mainFrame.Content = new Pages.MainPage();
        }

        private void cmbMap_SelectionChanged(object sender, SelectionChangedEventArgs e) // глобальный фильтр по картам
        {
            
        }

        private void Editor_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Content = new Pages.EditorPage();
            ActivityTitle.Text = Editor.Content.ToString();
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Content = new Pages.MainPage();
            ActivityTitle.Text = Menu.Content.ToString();
        }
    }
}