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
using MetroApp.Pages.EditPages;

namespace MetroApp.Pages
{
    public partial class EditorPage : Page
    {
        public EditorPage()
        {
            InitializeComponent();
        }

        private void MapBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditorListPage("Карты"));
        }

        private void CityBtn_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void DistrictBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AreaBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void StationAreaBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void StationPhotoBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PhotoAngleBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditorListPage("Ракурсы"));
        }

        private void HallPhotoBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditorListPage("Помещения"));
        }

        private void TrainSeriesBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditorListPage("Серии поездов"));
        }

        private void TrainBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TrainLineBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DepotLineBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DepotBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditorListPage("Депо"));
        }

        private void LineObjectBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LineHistoryBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void StationObjectBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void StationHistoryBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TransferObjectBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TransferHistoryBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TransferTypeBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditorListPage("Типы пересадкок"));
        }

        private void LocationBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ConstructionBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditorListPage("Конструкции"));
        }

        private void PillarBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SpanBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditorListPage("Пролёты"));
        }

        private void FloorBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditorListPage("Перекрытия"));
        }

        private void StructComplexBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void StatusBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DepthTypeBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PeculiarityBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditorListPage("Особенности"));
        }

        private void PeculiarityStationBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PlatformBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditorListPage("Платформы"));
        }

        private void TrafficTypeBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TrafficDescrBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditorListPage("Пассажирпоток (описание)"));
        }

        private void HousingCostBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DecadeBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void StateBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
