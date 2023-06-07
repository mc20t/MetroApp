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
    public partial class LineListPage : Page
    {
        List<FUNC_LineHistory_Result> FUNC_LineHistory_list = new List<FUNC_LineHistory_Result>();
        List<string> listSort = new List<string>() { "По умолчанию", "По номеру", "По названию линии", "По аббревиатуре",
                                                     "По дате последних изменений", "По длине линии", "По времени в пути",
                                                     "По состоянию", "По карте" };

        public LineListPage()
        {
            InitializeComponent();

            Title = "Линии метро";
            //cmbMap.ItemsSource = "";

            SelectSQL selectSQL = new SelectSQL();
            var queryListCodeRequest = "select * from [dbo].[Map]";
            selectSQL.loadElementToComboBox(queryListCodeRequest, "Name", cmbMap);

            cmbMap.SelectedIndex = 0;
            dpDate.SelectedDate = DateTime.Now;

            cmbSort.ItemsSource = listSort;
            cmbSort.SelectedIndex = 0;
            Filter();
        }

        public void Filter()
        {
            FUNC_LineHistory_list = AppData.Context.FUNC_LineHistory((DateTime)dpDate.SelectedDate).ToList();
            FUNC_LineHistory_list = FUNC_LineHistory_list.Where(i => i.LINE_NAME.ToLower().Contains(txtSearch.Text.ToLower()) ||
                                                                     i.LAST_MOD_DATE.ToString().ToLower().Contains(txtSearch.Text.ToLower()) ||
                                                                     i.LINE_LENGTH.ToString().ToLower().Contains(txtSearch.Text.ToLower()) ||
                                                                     i.TRAVEL_TIME.ToString().ToLower().Contains(txtSearch.Text.ToLower()) ||
                                                                     i.LINE_ABBR.ToString().ToLower().Contains(txtSearch.Text.ToLower()) ||
                                                                     i.LINE_NUMBER.ToString().ToLower().Contains(txtSearch.Text.ToLower()) ||
                                                                     i.MAP.ToString().ToLower().Contains(txtSearch.Text.ToLower())).ToList();
            if (cmbSort.SelectedIndex == 0)      FUNC_LineHistory_list = FUNC_LineHistory_list.OrderBy(i => i.LAST_MOD_DATE).ToList();
            else if (cmbSort.SelectedIndex == 1) FUNC_LineHistory_list = FUNC_LineHistory_list.OrderBy(i => i.LINE_NUMBER).ToList();
            else if (cmbSort.SelectedIndex == 2) FUNC_LineHistory_list = FUNC_LineHistory_list.OrderBy(i => i.LINE_NAME).ToList();
            else if (cmbSort.SelectedIndex == 3) FUNC_LineHistory_list = FUNC_LineHistory_list.OrderBy(i => i.LINE_ABBR).ToList();
            else if (cmbSort.SelectedIndex == 4) FUNC_LineHistory_list = FUNC_LineHistory_list.OrderBy(i => i.LAST_MOD_DATE).ToList();
            else if (cmbSort.SelectedIndex == 5) FUNC_LineHistory_list = FUNC_LineHistory_list.OrderBy(i => i.LINE_LENGTH).ToList();
            else if (cmbSort.SelectedIndex == 6) FUNC_LineHistory_list = FUNC_LineHistory_list.OrderBy(i => i.TRAVEL_TIME).ToList();
            else if (cmbSort.SelectedIndex == 7) FUNC_LineHistory_list = FUNC_LineHistory_list.OrderBy(i => i.LINE_STATUS).ToList();
            else if (cmbSort.SelectedIndex == 8) FUNC_LineHistory_list = FUNC_LineHistory_list.OrderBy(i => i.MAP).ToList();
            else                                 FUNC_LineHistory_list = FUNC_LineHistory_list.OrderBy(i => i.LAST_MOD_DATE).ToList();

            lvTable.ItemsSource = FUNC_LineHistory_list;
        }

        private void lvTable_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new StationInfoList());
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

        private void cmbMap_SelectionChanged(object sender, SelectionChangedEventArgs e) // фильтр по картам
        {
            //Filter();
        }

        private void dpDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e) // фильтр по дате
        {
            Filter();
        }
    }
}
