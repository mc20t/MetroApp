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
    public partial class EditorListPage : Page
    {
        List<string> listSortIDName = new List<string>() { "По умолчанию", "По названию" };
        List<string> listSortIDTxtTxt = new List<string>() { "По умолчанию", "По названию", "По аббревиатуре" };
        List<string> listSortIDNameCode = new List<string>() { "По умолчанию", "По названию", "По коду" };
        List<string> listSortIDIntInt = new List<string>() { "По умолчанию", "По береговой", "По островной" };

        GridView gvCont = new GridView();
        GridViewColumn gvc1 = new GridViewColumn();
        GridViewColumn gvc2 = new GridViewColumn();
        GridViewColumn gvc3 = new GridViewColumn();

        string global;
        string[] addupd = new string[] { "", "" };
        string[] add = new string[] { "", "" };

        public EditorListPage(string x)
        {
            InitializeComponent();
            global = x;
            Title += x;
            TitleText.Text = x;

            if (x == "Карты")
            {
                GvcIdTxtTxt();
                lvTable.ItemsSource = AppData.Context.Map.ToList();
                Filter();
            }
            else if (x == "Ракурсы")
            {
                GvcIdTxt();
                lvTable.ItemsSource = AppData.Context.PhotoAngle.ToList();
                Filter();
            }
            else if (x == "Помещения")
            {
                GvcIdTxt();
                lvTable.ItemsSource = AppData.Context.HallPhoto.ToList();
                Filter();
            }
            else if (x == "Серии поездов")
            {
                GvcIdTxt();
                lvTable.ItemsSource = AppData.Context.TrainSeries.ToList();
                Filter();
            }
            else if (x == "Типы пересадкок")
            {
                GvcIdTxt();
                lvTable.ItemsSource = AppData.Context.TransferType.ToList();
                Filter();
            }
            else if (x == "Пассажирпоток (описание)")
            {
                GvcIdTxt();
                lvTable.ItemsSource = AppData.Context.TrafficDescription.ToList();
                Filter();
            }
            else if (x == "Депо")
            {
                GvcIdTxtTxt();
                lvTable.ItemsSource = AppData.Context.Depot.ToList();
                Filter();
            }
            else if (x == "Конструкции")
            {
                GvcIdTxtTxt();
                lvTable.ItemsSource = AppData.Context.Construction.ToList();
                Filter();
            }
            else if (x == "Пролёты")
            {
                GvcIdTxtTxt();
                lvTable.ItemsSource = AppData.Context.Span.ToList();
                Filter();
            }
            else if (x == "Перекрытия")
            {
                GvcIdTxtTxt();
                lvTable.ItemsSource = AppData.Context.Floor.ToList();
                Filter();
            }
            else if (x == "Особенности")
            {
                GvcIdTxtTxt();
                lvTable.ItemsSource = AppData.Context.Peculiarity.ToList();
                Filter();
            }
            else if (x == "Платформы")
            {
                GvcIdTxtTxt();
                lvTable.ItemsSource = AppData.Context.Platform.ToList();
                Filter();
            }

            else
            {
                MessageBox.Show("", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            cmbSort.SelectedIndex = 0;
        }

        public void GvcIdTxt()
        {
            gvc1.DisplayMemberBinding = new Binding("ID");
            gvc1.Header = "Номер";
            gvc1.Width = Double.NaN;
            gvCont.Columns.Add(gvc1);

            gvc2.DisplayMemberBinding = new Binding("Name");
            gvc2.Header = "Название";
            gvc2.Width = Double.NaN;
            gvCont.Columns.Add(gvc2);

            lvTable.View = gvCont;
            cmbSort.ItemsSource = listSortIDName;
        }

        public void GvcIdTxtTxt()
        {
            gvc1.DisplayMemberBinding = new Binding("ID");
            gvc1.Header = "Номер";
            gvc1.Width = Double.NaN;
            gvc2.Width = Double.NaN;
            gvc3.Width = Double.NaN;

            if (global == "Депо")
            {
                gvc2.DisplayMemberBinding = new Binding("Name");
                gvc2.Header = "Название";
                gvc3.DisplayMemberBinding = new Binding("Code");
                gvc3.Header = "Код";
                cmbSort.ItemsSource = listSortIDNameCode;
            }
            else if (global == "Карты")
            {
                gvc2.DisplayMemberBinding = new Binding("Name");
                gvc2.Header = "Название";
                gvc3.DisplayMemberBinding = new Binding("Logo");
                gvc3.Header = "Логотип";
                cmbSort.ItemsSource = listSortIDName;
            }
            else if (global == "Платформы")
            {
                gvc2.DisplayMemberBinding = new Binding("Unilateral");
                gvc2.Header = "Береговая";
                gvc3.DisplayMemberBinding = new Binding("Bilateral");
                gvc3.Header = "Островная";
                cmbSort.ItemsSource = listSortIDIntInt;
            }

            else
            {
                gvc2.DisplayMemberBinding = new Binding("Title");
                gvc2.Header = "Название";
                gvc3.DisplayMemberBinding = new Binding("Abbreviation");
                gvc3.Header = "Аббревиатура";
                cmbSort.ItemsSource = listSortIDTxtTxt;
            }

            gvCont.Columns.Add(gvc1);
            gvCont.Columns.Add(gvc2);
            gvCont.Columns.Add(gvc3);

            lvTable.View = gvCont;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ManagerPage());
        }

        private void lvTable_RightButtonUp(object sender, MouseButtonEventArgs e)
        {
            DeleteItem();
        }

        private void cmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "Для удаления объекта щёлкните по нему в таблице правой кнопкой мыши, или нажмите на него левой кнопкой, а затем Delete.\n\n" +
                "Для изменения дважды щёлкните левой кнопкой мыши по выбранному объекту.",
                "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void lvTable_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                DeleteItem();
            }
        }

        private void btnAddUpdate_Click(object sender, RoutedEventArgs e)
        {
            AddUpdateWindow AddUpdateWindow = new AddUpdateWindow(global, add);
            this.Opacity = 0.2;
            AddUpdateWindow.btnAddUpdate.Content = "Добавить";
            AddUpdateWindow.tbTitle.Text = "Добавление";
            AddUpdateWindow.Title = "Добавление";
            AddUpdateWindow.ShowDialog();
            Filter();
            this.Opacity = 1;
        }

        private void lvTable_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var editMap = new Map();
            var editPhotoAngle = new PhotoAngle();
            var editHallPhoto = new HallPhoto();
            var editTrainSeries = new TrainSeries();
            var editTransferType = new TransferType();
            var editTrafficDescription = new TrafficDescription();
            var editDepot = new Depot();
            var editConstruction = new Construction();
            var editSpan = new DB.Span();
            var editFloor = new Floor();
            var editPeculiarity = new Peculiarity();
            var editPlatform = new Platform();

            if (lvTable.SelectedItem is Map)
            {
                editMap = lvTable.SelectedItem as Map;
                addupd[0] = editMap.Name;
                addupd[1] = editMap.Logo;
            }
            else if (lvTable.SelectedItem is PhotoAngle)
            {
                editPhotoAngle = lvTable.SelectedItem as PhotoAngle;
                addupd[0] = editPhotoAngle.Name;
            }
            else if (lvTable.SelectedItem is HallPhoto)
            {
                editHallPhoto = lvTable.SelectedItem as HallPhoto;
                addupd[0] = editHallPhoto.Name;
            }
            else if (lvTable.SelectedItem is TrainSeries)
            {
                editTrainSeries = lvTable.SelectedItem as TrainSeries;
                addupd[0] = editTrainSeries.Name;
            }
            else if (lvTable.SelectedItem is TransferType)
            {
                editTransferType = lvTable.SelectedItem as TransferType;
                addupd[0] = editTransferType.Name;
            }
            else if (lvTable.SelectedItem is TrafficDescription)
            {
                editTrafficDescription = lvTable.SelectedItem as TrafficDescription;
                addupd[0] = editTrafficDescription.Name;
            }
            else if (lvTable.SelectedItem is Depot)
            {
                editDepot = lvTable.SelectedItem as Depot;
                addupd[0] = editDepot.Name;
                addupd[1] = editDepot.Code;
            }
            else if (lvTable.SelectedItem is Construction)
            {
                editConstruction = lvTable.SelectedItem as Construction;
                addupd[0] = editConstruction.Title;
                addupd[1] = editConstruction.Abbreviation;
            }
            else if (lvTable.SelectedItem is DB.Span)
            {
                editSpan = lvTable.SelectedItem as DB.Span;
                addupd[0] = editSpan.Title;
                addupd[1] = editSpan.Abbreviation;
            }
            else if (lvTable.SelectedItem is Floor)
            {
                editFloor = lvTable.SelectedItem as Floor;
                addupd[0] = editFloor.Title;
                addupd[1] = editFloor.Abbreviation;
            }
            else if (lvTable.SelectedItem is Peculiarity)
            {
                editPeculiarity = lvTable.SelectedItem as Peculiarity;
                addupd[0] = editPeculiarity.Title;
                addupd[1] = editPeculiarity.Abbreviation;
            }
            else if (lvTable.SelectedItem is Platform)
            {
                editPlatform = lvTable.SelectedItem as Platform;
                addupd[0] = editPlatform.Unilateral.ToString();
                addupd[1] = editPlatform.Bilateral.ToString();
            }

            else
            {
                MessageBox.Show("", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            AddUpdateWindow AddUpdateWindow = new AddUpdateWindow(global, addupd);
            this.Opacity = 0.2;
            AddUpdateWindow.btnAddUpdate.Content = "Изменить";
            AddUpdateWindow.tbTitle.Text = "Изменение";
            AddUpdateWindow.Title = "Изменение";
            AddUpdateWindow.ShowDialog();
            if (AddUpdateWindow.addubrReturn[0] != null)
            {
                if (lvTable.SelectedItem is PhotoAngle) editPhotoAngle.Name = AddUpdateWindow.addubrReturn[0];
                else if (lvTable.SelectedItem is HallPhoto) editHallPhoto.Name = AddUpdateWindow.addubrReturn[0];
                else if (lvTable.SelectedItem is TrainSeries) editTrainSeries.Name = AddUpdateWindow.addubrReturn[0];
                else if (lvTable.SelectedItem is TransferType) editTransferType.Name = AddUpdateWindow.addubrReturn[0];
                else if (lvTable.SelectedItem is TrafficDescription) editTrafficDescription.Name = AddUpdateWindow.addubrReturn[0];
                else if (lvTable.SelectedItem is Map)
                {
                    editMap.Name = AddUpdateWindow.addubrReturn[0];
                    editMap.Logo = AddUpdateWindow.addubrReturn[1];
                }
                else if (lvTable.SelectedItem is Depot)
                {
                    editDepot.Name = AddUpdateWindow.addubrReturn[0];
                    editDepot.Code = AddUpdateWindow.addubrReturn[1];
                }
                else if (lvTable.SelectedItem is DB.Span)
                {
                    editSpan.Title = AddUpdateWindow.addubrReturn[0];
                    editSpan.Abbreviation = AddUpdateWindow.addubrReturn[1];
                }
                else if (lvTable.SelectedItem is Construction)
                {
                    editConstruction.Title = AddUpdateWindow.addubrReturn[0];
                    editConstruction.Abbreviation = AddUpdateWindow.addubrReturn[1];
                }
                else if (lvTable.SelectedItem is Floor)
                {
                    editFloor.Title = AddUpdateWindow.addubrReturn[0];
                    editFloor.Abbreviation = AddUpdateWindow.addubrReturn[1];
                }
                else if (lvTable.SelectedItem is Peculiarity)
                {
                    editPeculiarity.Title = AddUpdateWindow.addubrReturn[0];
                    editPeculiarity.Abbreviation = AddUpdateWindow.addubrReturn[1];
                }
                else if (lvTable.SelectedItem is Platform)
                {
                    byte u = byte.Parse(AddUpdateWindow.addubrReturn[0]);
                    byte b = byte.Parse(AddUpdateWindow.addubrReturn[1]);
                    editPlatform.Unilateral = u;
                    editPlatform.Bilateral = b;
                }

                else
                {
                    MessageBox.Show("", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                MessageBox.Show("Успех!", "Данные объекта успешно изменены!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            AppData.Context.SaveChanges();
            this.Opacity = 1;
            Filter();
        }

        public void DeleteItem()
        {
            if (lvTable.SelectedItem is Map ||
                lvTable.SelectedItem is PhotoAngle ||
                lvTable.SelectedItem is HallPhoto ||
                lvTable.SelectedItem is Depot ||
                lvTable.SelectedItem is DB.Span ||
                lvTable.SelectedItem is Construction ||
                lvTable.SelectedItem is Floor ||
                lvTable.SelectedItem is Peculiarity ||
                lvTable.SelectedItem is TrafficDescription ||
                lvTable.SelectedItem is TrainSeries ||
                lvTable.SelectedItem is TransferType ||
                lvTable.SelectedItem is Platform &&
                lvTable.SelectedIndex != -1)
            {
                try
                {
                    var itemMap = lvTable.SelectedItem as Map;
                    var itemPhotoAngle = lvTable.SelectedItem as PhotoAngle;
                    var itemHallPhoto = lvTable.SelectedItem as HallPhoto;
                    var itemTrafficDescription = lvTable.SelectedItem as TrafficDescription;
                    var itemTrainSeries = lvTable.SelectedItem as TrainSeries;
                    var itemTransferType = lvTable.SelectedItem as TransferType;
                    var itemDepot = lvTable.SelectedItem as Depot;
                    var itemConstruction = lvTable.SelectedItem as Construction;
                    var itemSpan = lvTable.SelectedItem as DB.Span;
                    var itemFloor = lvTable.SelectedItem as Floor;
                    var itemPeculiarity = lvTable.SelectedItem as Peculiarity;
                    var itemPlatform = lvTable.SelectedItem as Platform;

                    var resultClick = MessageBox.Show("Вы уверены?", "Подтвердите удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (resultClick == MessageBoxResult.Yes)
                    {
                        if (lvTable.SelectedItem is Map) AppData.Context.Map.Remove(itemMap);
                        else if (lvTable.SelectedItem is PhotoAngle) AppData.Context.PhotoAngle.Remove(itemPhotoAngle);
                        else if (lvTable.SelectedItem is HallPhoto) AppData.Context.HallPhoto.Remove(itemHallPhoto);
                        else if (lvTable.SelectedItem is TrafficDescription) AppData.Context.TrafficDescription.Remove(itemTrafficDescription);
                        else if (lvTable.SelectedItem is TrainSeries) AppData.Context.TrainSeries.Remove(itemTrainSeries);
                        else if (lvTable.SelectedItem is TransferType) AppData.Context.TransferType.Remove(itemTransferType);
                        else if (lvTable.SelectedItem is Depot) AppData.Context.Depot.Remove(itemDepot);
                        else if (lvTable.SelectedItem is Construction) AppData.Context.Construction.Remove(itemConstruction);
                        else if (lvTable.SelectedItem is Floor) AppData.Context.Floor.Remove(itemFloor);
                        else if (lvTable.SelectedItem is Peculiarity) AppData.Context.Peculiarity.Remove(itemPeculiarity);
                        else if (lvTable.SelectedItem is DB.Span) AppData.Context.Span.Remove(itemSpan);
                        else if (lvTable.SelectedItem is Platform) AppData.Context.Platform.Remove(itemPlatform);

                        else
                        {
                            MessageBox.Show("", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Information);
                            return;
                        }
                        AppData.Context.SaveChanges();
                        Filter();
                        MessageBox.Show("Объект успешно удалён!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        public void Filter()
        {
            if (TitleText.Text == "Карты")
            {
                List<Map> MapList = new List<Map>();
                MapList = AppData.Context.Map.ToList();
                MapList = MapList.Where(i => i.Name.ToLower().Contains(txtSearch.Text.ToLower()) || i.ID.ToString().ToLower().Contains(txtSearch.Text.ToLower())).ToList();
                if (cmbSort.SelectedIndex == 0) MapList = MapList.OrderBy(i => i.ID).ToList();
                else if (cmbSort.SelectedIndex == 1) MapList = MapList.OrderBy(i => i.Name).ToList();
                else MapList = MapList.OrderBy(i => i.ID).ToList();
                lvTable.ItemsSource = MapList;
            }
            else if (TitleText.Text == "Ракурсы")
            {
                List<PhotoAngle> PhotoAngleList = new List<PhotoAngle>();
                PhotoAngleList = AppData.Context.PhotoAngle.ToList();
                PhotoAngleList = PhotoAngleList.Where(i => i.Name.ToLower().Contains(txtSearch.Text.ToLower()) || i.ID.ToString().ToLower().Contains(txtSearch.Text.ToLower())).ToList();
                if (cmbSort.SelectedIndex == 0) PhotoAngleList = PhotoAngleList.OrderBy(i => i.ID).ToList();
                else if (cmbSort.SelectedIndex == 1) PhotoAngleList = PhotoAngleList.OrderBy(i => i.Name).ToList();
                else PhotoAngleList = PhotoAngleList.OrderBy(i => i.ID).ToList();
                lvTable.ItemsSource = PhotoAngleList;
            }
            else if (TitleText.Text == "Помещения")
            {
                List<HallPhoto> HallPhotoList = new List<HallPhoto>();
                HallPhotoList = AppData.Context.HallPhoto.ToList();
                HallPhotoList = HallPhotoList.Where(i => i.Name.ToLower().Contains(txtSearch.Text.ToLower()) || i.ID.ToString().ToLower().Contains(txtSearch.Text.ToLower())).ToList();
                if (cmbSort.SelectedIndex == 0) HallPhotoList = HallPhotoList.OrderBy(i => i.ID).ToList();
                else if (cmbSort.SelectedIndex == 1) HallPhotoList = HallPhotoList.OrderBy(i => i.Name).ToList();
                else HallPhotoList = HallPhotoList.OrderBy(i => i.ID).ToList();
                lvTable.ItemsSource = HallPhotoList;
            }
            else if (TitleText.Text == "Серии поездов")
            {
                List<TrainSeries> TrainSeriesList = new List<TrainSeries>();
                TrainSeriesList = AppData.Context.TrainSeries.ToList();
                TrainSeriesList = TrainSeriesList.Where(i => i.Name.ToLower().Contains(txtSearch.Text.ToLower()) || i.ID.ToString().ToLower().Contains(txtSearch.Text.ToLower())).ToList();
                if (cmbSort.SelectedIndex == 0) TrainSeriesList = TrainSeriesList.OrderBy(i => i.ID).ToList();
                else if (cmbSort.SelectedIndex == 1) TrainSeriesList = TrainSeriesList.OrderBy(i => i.Name).ToList();
                else TrainSeriesList = TrainSeriesList.OrderBy(i => i.ID).ToList();
                lvTable.ItemsSource = TrainSeriesList;
            }
            else if (TitleText.Text == "Типы пересадкок")
            {
                List<TransferType> TransferTypeList = new List<TransferType>();
                TransferTypeList = AppData.Context.TransferType.ToList();
                TransferTypeList = TransferTypeList.Where(i => i.Name.ToLower().Contains(txtSearch.Text.ToLower()) || i.ID.ToString().ToLower().Contains(txtSearch.Text.ToLower())).ToList();
                if (cmbSort.SelectedIndex == 0) TransferTypeList = TransferTypeList.OrderBy(i => i.ID).ToList();
                else if (cmbSort.SelectedIndex == 1) TransferTypeList = TransferTypeList.OrderBy(i => i.Name).ToList();
                else TransferTypeList = TransferTypeList.OrderBy(i => i.ID).ToList();
                lvTable.ItemsSource = TransferTypeList;
            }
            else if (TitleText.Text == "Пассажирпоток (описание)")
            {
                List<TrafficDescription> TrafficDescriptionList = new List<TrafficDescription>();
                TrafficDescriptionList = AppData.Context.TrafficDescription.ToList();
                TrafficDescriptionList = TrafficDescriptionList.Where(i => i.Name.ToLower().Contains(txtSearch.Text.ToLower()) || i.ID.ToString().ToLower().Contains(txtSearch.Text.ToLower())).ToList();
                if (cmbSort.SelectedIndex == 0) TrafficDescriptionList = TrafficDescriptionList.OrderBy(i => i.ID).ToList();
                else if (cmbSort.SelectedIndex == 1) TrafficDescriptionList = TrafficDescriptionList.OrderBy(i => i.Name).ToList();
                else TrafficDescriptionList = TrafficDescriptionList.OrderBy(i => i.ID).ToList();
                lvTable.ItemsSource = TrafficDescriptionList;
            }
            if (TitleText.Text == "Депо")
            {
                List<Depot> DepotList = new List<Depot>();
                DepotList = AppData.Context.Depot.ToList();
                DepotList = DepotList.Where(i => i.Name.ToLower().Contains(txtSearch.Text.ToLower()) ||
                                                 i.ID.ToString().ToLower().Contains(txtSearch.Text.ToLower()) ||
                                                 i.Code.ToString().ToLower().Contains(txtSearch.Text.ToLower())).ToList();
                if (cmbSort.SelectedIndex == 0) DepotList = DepotList.OrderBy(i => i.ID).ToList();
                else if (cmbSort.SelectedIndex == 1) DepotList = DepotList.OrderBy(i => i.Name).ToList();
                else if (cmbSort.SelectedIndex == 2) DepotList = DepotList.OrderBy(i => i.Code).ToList();
                else DepotList = DepotList.OrderBy(i => i.ID).ToList();
                lvTable.ItemsSource = DepotList;
            }
            else if (TitleText.Text == "Конструкции")
            {
                List<Construction> ConstructionList = new List<Construction>();
                ConstructionList = AppData.Context.Construction.ToList();
                ConstructionList = ConstructionList.Where(i => i.Title.ToLower().Contains(txtSearch.Text.ToLower()) ||
                                                               i.ID.ToString().ToLower().Contains(txtSearch.Text.ToLower()) ||
                                                               i.Abbreviation.ToString().ToLower().Contains(txtSearch.Text.ToLower())).ToList();
                if (cmbSort.SelectedIndex == 0) ConstructionList = ConstructionList.OrderBy(i => i.ID).ToList();
                else if (cmbSort.SelectedIndex == 1) ConstructionList = ConstructionList.OrderBy(i => i.Title).ToList();
                else if (cmbSort.SelectedIndex == 2) ConstructionList = ConstructionList.OrderBy(i => i.Abbreviation).ToList();
                else ConstructionList = ConstructionList.OrderBy(i => i.ID).ToList();
                lvTable.ItemsSource = ConstructionList;
            }
            else if (TitleText.Text == "Пролёты")
            {
                List<DB.Span> SpanList = new List<DB.Span>();
                SpanList = AppData.Context.Span.ToList();
                SpanList = SpanList.Where(i => i.Title.ToLower().Contains(txtSearch.Text.ToLower()) ||
                                               i.ID.ToString().ToLower().Contains(txtSearch.Text.ToLower()) ||
                                               i.Abbreviation.ToString().ToLower().Contains(txtSearch.Text.ToLower())).ToList();
                if (cmbSort.SelectedIndex == 0) SpanList = SpanList.OrderBy(i => i.ID).ToList();
                else if (cmbSort.SelectedIndex == 1) SpanList = SpanList.OrderBy(i => i.Title).ToList();
                else if (cmbSort.SelectedIndex == 2) SpanList = SpanList.OrderBy(i => i.Abbreviation).ToList();
                else SpanList = SpanList.OrderBy(i => i.ID).ToList();
                lvTable.ItemsSource = SpanList;
            }
            else if (TitleText.Text == "Перекрытия")
            {
                List<Floor> FloorList = new List<Floor>();
                FloorList = AppData.Context.Floor.ToList();
                FloorList = FloorList.Where(i => i.Title.ToLower().Contains(txtSearch.Text.ToLower()) ||
                                                 i.ID.ToString().ToLower().Contains(txtSearch.Text.ToLower()) ||
                                                 i.Abbreviation.ToString().ToLower().Contains(txtSearch.Text.ToLower())).ToList();
                if (cmbSort.SelectedIndex == 0) FloorList = FloorList.OrderBy(i => i.ID).ToList();
                else if (cmbSort.SelectedIndex == 1) FloorList = FloorList.OrderBy(i => i.Title).ToList();
                else if (cmbSort.SelectedIndex == 2) FloorList = FloorList.OrderBy(i => i.Abbreviation).ToList();
                else FloorList = FloorList.OrderBy(i => i.ID).ToList();
                lvTable.ItemsSource = FloorList;
            }
            else if (TitleText.Text == "Особенности")
            {
                List<Peculiarity> PeculiarityList = new List<Peculiarity>();
                PeculiarityList = AppData.Context.Peculiarity.ToList();
                PeculiarityList = PeculiarityList.Where(i => i.Title.ToLower().Contains(txtSearch.Text.ToLower()) ||
                                                             i.ID.ToString().ToLower().Contains(txtSearch.Text.ToLower()) ||
                                                             i.Abbreviation.ToString().ToLower().Contains(txtSearch.Text.ToLower())).ToList();
                if (cmbSort.SelectedIndex == 0) PeculiarityList = PeculiarityList.OrderBy(i => i.ID).ToList();
                else if (cmbSort.SelectedIndex == 1) PeculiarityList = PeculiarityList.OrderBy(i => i.Title).ToList();
                else if (cmbSort.SelectedIndex == 2) PeculiarityList = PeculiarityList.OrderBy(i => i.Abbreviation).ToList();
                else PeculiarityList = PeculiarityList.OrderBy(i => i.ID).ToList();
                lvTable.ItemsSource = PeculiarityList;
            }
            else if (TitleText.Text == "Платформы")
            {
                List<Platform> PlatformList = new List<Platform>();
                PlatformList = AppData.Context.Platform.ToList();
                PlatformList = PlatformList.Where(i => i.Unilateral.ToString().ToLower().Contains(txtSearch.Text.ToLower()) ||
                                                             i.ID.ToString().ToLower().Contains(txtSearch.Text.ToLower()) ||
                                                             i.Bilateral.ToString().ToString().ToLower().Contains(txtSearch.Text.ToLower())).ToList();
                if (cmbSort.SelectedIndex == 0) PlatformList = PlatformList.OrderBy(i => i.ID).ToList();
                else if(cmbSort.SelectedIndex == 1) PlatformList = PlatformList.OrderBy(i => i.Unilateral.ToString()).ToList();
                else if(cmbSort.SelectedIndex == 2) PlatformList = PlatformList.OrderBy(i => i.Bilateral.ToString()).ToList();
                else PlatformList = PlatformList.OrderBy(i => i.ID).ToList();
                lvTable.ItemsSource = PlatformList;
            }

        }
    }
}