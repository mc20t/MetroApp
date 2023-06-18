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
using System.Drawing;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using MetroApp.Pages;

namespace MetroApp.Pages
{
    public partial class MapInfoPage : Page
    {
        byte global;
        BitmapImage bitmapImage = new BitmapImage();
        List<FUNC_LineHistoryMap_Result> FUNC_LineHistoryMap_list = new List<FUNC_LineHistoryMap_Result>();
        List<string> listSort = new List<string>() { "По умолчанию", "По номеру линии", "По названию линии", "По аббревиатуре",
                                                     "По состоянию", "По дате последних изменений", "По длине линии",
                                                     "По времени в пути", "По количеству станций", "По дате откр. посл. станции",
                                                     "По сред. раст. между станц.", "По сред. глубине стан.", "По кол. откр. стан. за год" };
        public MapInfoPage(Map GetMap)
        {
            InitializeComponent();
            global = GetMap.ID;

            bitmapImage.BeginInit();
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
            bitmapImage.UriSource = new Uri(@GetMap.Logo);
            bitmapImage.EndInit();
            imgMapLogo.Source = bitmapImage;

            tbMapName.Text = GetMap.Name;
            Title += GetMap.Name;
            //cmbMap.ItemsSource = "";

            //SelectSQL selectSQL = new SelectSQL();
            //var queryListCodeRequest = "select * from [dbo].[Map]";
            //selectSQL.loadElementToComboBox(queryListCodeRequest, "Name", cmbMap);

            //cmbMap.SelectedIndex = 0;
            dpDate.SelectedDate = DateTime.Now;

            cmbSort.ItemsSource = listSort;
            cmbSort.SelectedIndex = 0;
            Filter();
        }

        public void Filter()
        {
            FUNC_LineHistoryMap_list = AppData.Context.FUNC_LineHistoryMap((DateTime)dpDate.SelectedDate, global).ToList();
            FUNC_LineHistoryMap_list = FUNC_LineHistoryMap_list.Where(i => i.LineColor.ToLower().Contains(txtSearch.Text.ToLower()) ||
                                                                      i.LineNumber.ToString().ToLower().Contains(txtSearch.Text.ToLower()) ||
                                                                      i.LineAbbreviation.ToString().ToLower().Contains(txtSearch.Text.ToLower()) ||
                                                                      i.LineName.ToString().ToLower().Contains(txtSearch.Text.ToLower()) ||
                                                                      i.StatusColor.ToString().ToLower().Contains(txtSearch.Text.ToLower()) ||
                                                                      i.LineStatus.ToString().ToLower().Contains(txtSearch.Text.ToLower()) ||
                                                                      i.LastModDate.ToString().ToLower().Contains(txtSearch.Text.ToLower()) ||
                                                                      i.LineLength.ToString().ToLower().Contains(txtSearch.Text.ToLower()) ||
                                                                      i.TravelTime.ToString().ToLower().Contains(txtSearch.Text.ToLower()) ||
                                                                      i.CountStations.ToString().ToLower().Contains(txtSearch.Text.ToLower()) ||
                                                                      i.LastStationsOpenDate.ToString().ToLower().Contains(txtSearch.Text.ToLower()) ||
                                                                      i.AvgDistBetwStations.ToString().ToLower().Contains(txtSearch.Text.ToLower()) ||
                                                                      i.AvgStationsDepth.ToString().ToLower().Contains(txtSearch.Text.ToLower()) ||
                                                                      i.CountStationsOpenYear.ToString().ToLower().Contains(txtSearch.Text.ToLower())).ToList();
            if (cmbSort.SelectedIndex == 0) FUNC_LineHistoryMap_list = FUNC_LineHistoryMap_list.OrderByDescending(i => i.LastModDate).ToList();
            else if (cmbSort.SelectedIndex == 1) FUNC_LineHistoryMap_list = FUNC_LineHistoryMap_list.OrderBy(i => i.LineNumber).ToList();
            else if (cmbSort.SelectedIndex == 2) FUNC_LineHistoryMap_list = FUNC_LineHistoryMap_list.OrderBy(i => i.LineName).ToList();
            else if (cmbSort.SelectedIndex == 3) FUNC_LineHistoryMap_list = FUNC_LineHistoryMap_list.OrderBy(i => i.LineAbbreviation).ToList();
            else if (cmbSort.SelectedIndex == 4) FUNC_LineHistoryMap_list = FUNC_LineHistoryMap_list.OrderBy(i => i.LineStatus).ToList();
            else if (cmbSort.SelectedIndex == 5) FUNC_LineHistoryMap_list = FUNC_LineHistoryMap_list.OrderBy(i => i.LastModDate).ToList();
            else if (cmbSort.SelectedIndex == 6) FUNC_LineHistoryMap_list = FUNC_LineHistoryMap_list.OrderBy(i => i.LineLength).ToList();
            else if (cmbSort.SelectedIndex == 7) FUNC_LineHistoryMap_list = FUNC_LineHistoryMap_list.OrderBy(i => i.TravelTime).ToList();
            else if (cmbSort.SelectedIndex == 8) FUNC_LineHistoryMap_list = FUNC_LineHistoryMap_list.OrderBy(i => i.CountStations).ToList();
            else if (cmbSort.SelectedIndex == 9) FUNC_LineHistoryMap_list = FUNC_LineHistoryMap_list.OrderBy(i => i.LastStationsOpenDate).ToList();
            else if (cmbSort.SelectedIndex == 10) FUNC_LineHistoryMap_list = FUNC_LineHistoryMap_list.OrderBy(i => i.AvgDistBetwStations).ToList();
            else if (cmbSort.SelectedIndex == 11) FUNC_LineHistoryMap_list = FUNC_LineHistoryMap_list.OrderBy(i => i.AvgStationsDepth).ToList();
            else if (cmbSort.SelectedIndex == 12) FUNC_LineHistoryMap_list = FUNC_LineHistoryMap_list.OrderBy(i => i.CountStationsOpenYear).ToList();
            else FUNC_LineHistoryMap_list = FUNC_LineHistoryMap_list.OrderByDescending(i => i.LastStationsOpenDate).ToList();

            lvTable.ItemsSource = FUNC_LineHistoryMap_list;
        }

        private void lvTable_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new LineInfoPage());
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }

        private void cmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void dpDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }
    }
}
