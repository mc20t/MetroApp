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
    public partial class StationStatPage : Page
    {
        List<VW_StateCountStations> StateList = new List<VW_StateCountStations>();
        List<VW_DepthTypeCountStations> DepthTypeList = new List<VW_DepthTypeCountStations>();
        List<VW_HousingCostCountStations> HousingCostList = new List<VW_HousingCostCountStations>();
        List<VW_TrafficTypeCountStations> TrafficTypeList = new List<VW_TrafficTypeCountStations>();
        List<VW_PeculiarityCountStations> PeculiarityList = new List<VW_PeculiarityCountStations>();
        List<VW_AreaCountStations> AreaList = new List<VW_AreaCountStations>();
        List<VW_DistrictCountStations> DistrictList = new List<VW_DistrictCountStations>();
        List<VW_CityCountStations> CityList = new List<VW_CityCountStations>();
        List<VW_MapCountStations> MapList = new List<VW_MapCountStations>();
        List<VW_ConstructionCountStations> ConstructionList = new List<VW_ConstructionCountStations>();
        List<VW_FloorCountStations> FloorList = new List<VW_FloorCountStations>();
        List<VW_LocationCountStations> LocationList = new List<VW_LocationCountStations>();
        List<VW_PillarCountStations> PillarList = new List<VW_PillarCountStations>();
        List<VW_SpanCountStations> SpanList = new List<VW_SpanCountStations>();
        List<VW_PlatformCountStations> PlatformList = new List<VW_PlatformCountStations>();

        public StationStatPage()
        {
            InitializeComponent();

            StateList = AppData.Context.VW_StateCountStations.ToList();
            DepthTypeList = AppData.Context.VW_DepthTypeCountStations.ToList();
            HousingCostList = AppData.Context.VW_HousingCostCountStations.ToList();
            TrafficTypeList = AppData.Context.VW_TrafficTypeCountStations.ToList();
            PeculiarityList = AppData.Context.VW_PeculiarityCountStations.ToList();
            AreaList = AppData.Context.VW_AreaCountStations.ToList();
            DistrictList = AppData.Context.VW_DistrictCountStations.ToList();
            CityList = AppData.Context.VW_CityCountStations.ToList();
            MapList = AppData.Context.VW_MapCountStations.ToList();
            ConstructionList = AppData.Context.VW_ConstructionCountStations.ToList();
            FloorList = AppData.Context.VW_FloorCountStations.ToList();
            LocationList = AppData.Context.VW_LocationCountStations.ToList();
            PillarList = AppData.Context.VW_PillarCountStations.ToList();
            SpanList = AppData.Context.VW_SpanCountStations.ToList();
            PlatformList = AppData.Context.VW_PlatformCountStations.ToList();

            StateList = StateList.OrderByDescending(i => i.CountStations).ToList();
            DepthTypeList = DepthTypeList.OrderByDescending(i => i.CountStations).ToList();
            HousingCostList = HousingCostList.OrderByDescending(i => i.CountStations).ToList();
            TrafficTypeList = TrafficTypeList.OrderByDescending(i => i.CountStations).ToList();
            PeculiarityList = PeculiarityList.OrderByDescending(i => i.CountStations).ToList();
            AreaList = AreaList.OrderByDescending(i => i.CountStations).ToList();
            DistrictList = DistrictList.OrderByDescending(i => i.CountStations).ToList();
            CityList = CityList.OrderByDescending(i => i.CountStations).ToList();
            MapList = MapList.OrderByDescending(i => i.CountStations).ToList();
            ConstructionList = ConstructionList.OrderByDescending(i => i.CountStations).ToList();
            FloorList = FloorList.OrderByDescending(i => i.CountStations).ToList();
            LocationList = LocationList.OrderByDescending(i => i.CountStations).ToList();
            PillarList = PillarList.OrderByDescending(i => i.CountStations).ToList();
            SpanList = SpanList.OrderByDescending(i => i.CountStations).ToList();
            PlatformList = PlatformList.OrderByDescending(i => i.CountStations).ToList();

            lvState.ItemsSource = StateList;
            lvDepthType.ItemsSource = DepthTypeList;
            lvHousingCost.ItemsSource = HousingCostList;
            lvTrafficType.ItemsSource = TrafficTypeList;
            lvPeculiarity.ItemsSource = PeculiarityList;
            lvArea.ItemsSource = AreaList;
            lvDistrict.ItemsSource = DistrictList;
            lvCity.ItemsSource = CityList;
            lvMap.ItemsSource = MapList;
            lvConstruction.ItemsSource = ConstructionList;
            lvFloor.ItemsSource = FloorList;
            lvLocation.ItemsSource = LocationList;
            lvPillar.ItemsSource = PillarList;
            lvSpan.ItemsSource = SpanList;
            lvPlatform.ItemsSource = PlatformList;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }

        private void lvState_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (lvState.SelectedItem is VW_StateCountStations)
            {
                var GetItem = new VW_StateCountStations();
                GetItem = lvState.SelectedItem as VW_StateCountStations;
                NavigationService.Navigate(new StatStationPage("State", GetItem.ID, GetItem.StateName));
            }
        }

        private void lvDepthType_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (lvDepthType.SelectedItem is VW_DepthTypeCountStations)
            {
                var GetItem = new VW_DepthTypeCountStations();
                GetItem = lvDepthType.SelectedItem as VW_DepthTypeCountStations;
                NavigationService.Navigate(new StatStationPage("DepthType", GetItem.ID, $"от {GetItem.Minimum}м до {GetItem.Maximum}м"));
            }
        }

        private void lvHousingCost_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (lvHousingCost.SelectedItem is VW_HousingCostCountStations)
            {
                var GetItem = new VW_HousingCostCountStations();
                GetItem = lvHousingCost.SelectedItem as VW_HousingCostCountStations;
                NavigationService.Navigate(new StatStationPage("HousingCost", GetItem.ID, $"от {GetItem.Minimum} (тыс. руб./м2) до {GetItem.Maximum} (тыс. руб./м2)"));
            }
        }

        private void lvTrafficType_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (lvTrafficType.SelectedItem is VW_TrafficTypeCountStations)
            {
                var GetItem = new VW_TrafficTypeCountStations();
                GetItem = lvTrafficType.SelectedItem as VW_TrafficTypeCountStations;
                NavigationService.Navigate(new StatStationPage("TrafficType", GetItem.ID, $"от {GetItem.Minimum} (тыс. чел./сут.) до {GetItem.Maximum} (тыс. чел./сут.)"));
            }
        }

        private void lvPeculiarity_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (lvPeculiarity.SelectedItem is VW_PeculiarityCountStations)
            {
                var GetItem = new VW_PeculiarityCountStations();
                GetItem = lvPeculiarity.SelectedItem as VW_PeculiarityCountStations;
                NavigationService.Navigate(new StatStationPage("Peculiarity", GetItem.ID, GetItem.Peculiarity));
            }
        }

        private void lvArea_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (lvArea.SelectedItem is VW_AreaCountStations)
            {
                var GetItem = new VW_AreaCountStations();
                GetItem = lvArea.SelectedItem as VW_AreaCountStations;
                NavigationService.Navigate(new StatStationPage("Area", (byte)GetItem.ID, GetItem.Area));
            }
        }

        private void lvDistrict_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (lvDistrict.SelectedItem is VW_DistrictCountStations)
            {
                var GetItem = new VW_DistrictCountStations();
                GetItem = lvDistrict.SelectedItem as VW_DistrictCountStations;
                NavigationService.Navigate(new StatStationPage("District", (byte)GetItem.ID, GetItem.District));
            }
        }

        private void lvCity_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (lvCity.SelectedItem is VW_CityCountStations)
            {
                var GetItem = new VW_CityCountStations();
                GetItem = lvCity.SelectedItem as VW_CityCountStations;
                NavigationService.Navigate(new StatStationPage("City", GetItem.ID, GetItem.City));
            }
        }

        private void lvMap_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (lvMap.SelectedItem is VW_MapCountStations)
            {
                var GetItem = new VW_MapCountStations();
                GetItem = lvMap.SelectedItem as VW_MapCountStations;
                NavigationService.Navigate(new StatStationPage("Map", GetItem.ID, GetItem.Map));
            }
        }

        private void lvConstruction_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (lvConstruction.SelectedItem is VW_ConstructionCountStations)
            {
                var GetItem = new VW_ConstructionCountStations();
                GetItem = lvConstruction.SelectedItem as VW_ConstructionCountStations;
                NavigationService.Navigate(new StatStationPage("Construction", GetItem.ID, GetItem.Construction));
            }
        }

        private void lvFloor_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (lvFloor.SelectedItem is VW_FloorCountStations)
            {
                var GetItem = new VW_FloorCountStations();
                GetItem = lvFloor.SelectedItem as VW_FloorCountStations;
                NavigationService.Navigate(new StatStationPage("Floor", GetItem.ID, GetItem.Floor));
            }
        }

        private void lvLocation_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (lvLocation.SelectedItem is VW_LocationCountStations)
            {
                var GetItem = new VW_LocationCountStations();
                GetItem = lvLocation.SelectedItem as VW_LocationCountStations;
                NavigationService.Navigate(new StatStationPage("Location", GetItem.ID, GetItem.Location));
            }
        }

        private void lvPillar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (lvPillar.SelectedItem is VW_PillarCountStations)
            {
                var GetItem = new VW_PillarCountStations();
                GetItem = lvPillar.SelectedItem as VW_PillarCountStations;
                NavigationService.Navigate(new StatStationPage("Pillar", GetItem.ID, GetItem.Pillar));
            }
        }

        private void lvSpan_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (lvSpan.SelectedItem is VW_SpanCountStations)
            {
                var GetItem = new VW_SpanCountStations();
                GetItem = lvSpan.SelectedItem as VW_SpanCountStations;
                NavigationService.Navigate(new StatStationPage("Span", GetItem.ID, GetItem.Span));
            }
        }

        private void lvPlatform_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (lvPlatform.SelectedItem is VW_PlatformCountStations)
            {
                var GetItem = new VW_PlatformCountStations();
                GetItem = lvPlatform.SelectedItem as VW_PlatformCountStations;
                NavigationService.Navigate(new StatStationPage("Platform", GetItem.ID, $"Береговых: {GetItem.Unilateral}, островных: {GetItem.Bilateral}"));
            }
        }
    }
}