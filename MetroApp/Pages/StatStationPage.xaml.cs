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

namespace MetroApp.Pages
{
    public partial class StatStationPage : Page
    {
        List<FUNC_ToState_Result> FUNC_ToState_List = new List<FUNC_ToState_Result>();
        List<FUNC_ToDepthType_Result> FUNC_ToDepthType_List = new List<FUNC_ToDepthType_Result>();
        List<FUNC_ToHousingCost_Result> FUNC_ToHousingCost_List = new List<FUNC_ToHousingCost_Result>();
        List<FUNC_ToTrafficType_Result> FUNC_ToTrafficType_List = new List<FUNC_ToTrafficType_Result>();
        List<FUNC_ToPeculiarity_Result> FUNC_ToPeculiarity_List = new List<FUNC_ToPeculiarity_Result>();
        List<FUNC_ToArea_Result> FUNC_ToArea_List = new List<FUNC_ToArea_Result>();
        List<FUNC_ToDistrict_Result> FUNC_ToDistrict_List = new List<FUNC_ToDistrict_Result>();
        List<FUNC_ToCity_Result> FUNC_ToCity_List = new List<FUNC_ToCity_Result>();
        List<FUNC_ToMap_Result> FUNC_ToMap_List = new List<FUNC_ToMap_Result>();
        List<FUNC_ToLocation_Result> FUNC_ToLocation_List = new List<FUNC_ToLocation_Result>();
        List<FUNC_ToConstruction_Result> FUNC_ToConstruction_List = new List<FUNC_ToConstruction_Result>();
        List<FUNC_ToFloor_Result> FUNC_ToFloor_List = new List<FUNC_ToFloor_Result>();
        List<FUNC_ToPillar_Result> FUNC_ToPillar_List = new List<FUNC_ToPillar_Result>();
        List<FUNC_ToSpan_Result> FUNC_ToSpan_List = new List<FUNC_ToSpan_Result>();
        List<FUNC_ToPlatform_Result> FUNC_ToPlatform_List = new List<FUNC_ToPlatform_Result>();

        public StatStationPage(string table, byte item, string name)
        {
            InitializeComponent();

            if (table == "State")
            {
                FUNC_ToState_List = AppData.Context.FUNC_ToState(item).ToList();
                lvTable.ItemsSource = FUNC_ToState_List;
                Title += "Государства";
                tbTitle.Text = name;
            }
            else if (table == "DepthType")
            {
                FUNC_ToDepthType_List = AppData.Context.FUNC_ToDepthType(item).ToList();
                lvTable.ItemsSource = FUNC_ToDepthType_List;
                Title += "Диапозон глубины";
                tbTitle.Text = name;
            }
            else if (table == "HousingCost")
            {
                FUNC_ToHousingCost_List = AppData.Context.FUNC_ToHousingCost(item).ToList();
                lvTable.ItemsSource = FUNC_ToHousingCost_List;
                Title += "Ценовой диапозон";
                tbTitle.Text = name;
            }
            else if (table == "TrafficType")
            {
                FUNC_ToTrafficType_List = AppData.Context.FUNC_ToTrafficType(item).ToList();
                lvTable.ItemsSource = FUNC_ToTrafficType_List;
                Title += "Диапозон загруженности";
                tbTitle.Text = name;
            }
            else if (table == "Peculiarity")
            {
                FUNC_ToPeculiarity_List = AppData.Context.FUNC_ToPeculiarity(item).ToList();
                lvTable.ItemsSource = FUNC_ToPeculiarity_List;
                Title += "Особенности";
                tbTitle.Text = name;
            }
            else if (table == "Area")
            {
                FUNC_ToArea_List = AppData.Context.FUNC_ToArea(item).ToList();
                lvTable.ItemsSource = FUNC_ToArea_List;
                Title += "Районы";
                tbTitle.Text = name;
            }
            else if (table == "District")
            {
                FUNC_ToDistrict_List = AppData.Context.FUNC_ToDistrict(item).ToList();
                lvTable.ItemsSource = FUNC_ToDistrict_List;
                Title += "Округи";
                tbTitle.Text = name;
            }
            else if (table == "City")
            {
                FUNC_ToCity_List = AppData.Context.FUNC_ToCity(item).ToList();
                lvTable.ItemsSource = FUNC_ToCity_List;
                Title += "Города";
                tbTitle.Text = name;
            }
            else if (table == "Map")
            {
                FUNC_ToMap_List = AppData.Context.FUNC_ToMap(item).ToList();
                lvTable.ItemsSource = FUNC_ToMap_List;
                Title += "Карты";
                tbTitle.Text = name;
            }
            else if (table == "Construction")
            {
                FUNC_ToConstruction_List = AppData.Context.FUNC_ToConstruction(item).ToList();
                lvTable.ItemsSource = FUNC_ToConstruction_List;
                Title += "Конструкция";
                tbTitle.Text = name;
            }
            else if (table == "Floor")
            {
                FUNC_ToFloor_List = AppData.Context.FUNC_ToFloor(item).ToList();
                lvTable.ItemsSource = FUNC_ToFloor_List;
                Title += "Перекрытия";
                tbTitle.Text = name;
            }
            else if (table == "Location")
            {
                FUNC_ToLocation_List = AppData.Context.FUNC_ToLocation(item).ToList();
                lvTable.ItemsSource = FUNC_ToLocation_List;
                Title += "Расположение";
                tbTitle.Text = name;
            }
            else if (table == "Pillar")
            {
                FUNC_ToPillar_List = AppData.Context.FUNC_ToPillar(item).ToList();
                lvTable.ItemsSource = FUNC_ToPillar_List;
                Title += "Опоры";
                tbTitle.Text = name;
            }
            else if (table == "Span")
            {
                FUNC_ToSpan_List = AppData.Context.FUNC_ToSpan(item).ToList();
                lvTable.ItemsSource = FUNC_ToSpan_List;
                Title += "Пролёты";
                tbTitle.Text = name;
            }
            else if (table == "Platform")
            {
                FUNC_ToPlatform_List = AppData.Context.FUNC_ToPlatform(item).ToList();
                lvTable.ItemsSource = FUNC_ToPlatform_List;
                Title += "Платформы";
                tbTitle.Text = name;
            }

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StationStatPage());
        }

        private void lvTable_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new StationInfoPage());
        }
    }
}
