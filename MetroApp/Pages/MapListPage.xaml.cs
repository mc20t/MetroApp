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
using MetroApp.ClassHelper;
using MetroApp.DB;

namespace MetroApp.Pages
{
    public partial class MapListPage : Page
    {
        List<string> listSort = new List<string>() { "По умолчанию", "По названию" };

        public MapListPage()
        {
            InitializeComponent();
            lvTable.ItemsSource = AppData.Context.Map.ToList();
            cmbSort.ItemsSource = listSort;
            cmbSort.SelectedIndex = 0;
            Filter();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }

        private void lvTable_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var GetMap = new Map();
            if (lvTable.SelectedItem is Map)
            {
                GetMap = lvTable.SelectedItem as Map;
                NavigationService.Navigate(new MapInfoPage(GetMap));
            }
        }

        private void cmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        public void Filter()
        {
            List<Map> MapList = new List<Map>();
            MapList = AppData.Context.Map.ToList();
            MapList = MapList.Where(i => i.Name.ToLower().Contains(txtSearch.Text.ToLower()) || i.ID.ToString().ToLower().Contains(txtSearch.Text.ToLower())).ToList();
            if (cmbSort.SelectedIndex == 0) MapList = MapList.OrderBy(i => i.ID).ToList();
            else if (cmbSort.SelectedIndex == 1) MapList = MapList.OrderBy(i => i.Name).ToList();
            else MapList = MapList.OrderBy(i => i.ID).ToList();
            lvTable.ItemsSource = MapList;
        }
    }
}
