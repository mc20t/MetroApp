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

namespace MetroApp.Pages.EditPages
{
    public partial class IdNamePage : Page
    {
        List<Map> MapList = new List<Map>();
        List<PhotoAngle> PhotoAngleList = new List<PhotoAngle>();
        List<HallPhoto> HallPhotoList = new List<HallPhoto>();
        List<TrainSeries> TrainSeriesList = new List<TrainSeries>();
        List<TransferType> TransferTypeList = new List<TransferType>();
        List<TrafficDescription> TrafficDescriptionList = new List<TrafficDescription>();
        List<string> listSort = new List<string>() { "По умолчанию", "По названию" };

        public IdNamePage(string x)
        {
            InitializeComponent();
            cmbSort.ItemsSource = listSort;
            cmbSort.SelectedIndex = 0;
            Title += x;
            TitleText.Text = x;

            if (x == "Карты")
            {
                lvTable.ItemsSource = AppData.Context.Map.ToList();
                Filter();
            }
            else if (x == "Ракурсы")
            {
                lvTable.ItemsSource = AppData.Context.PhotoAngle.ToList();
                Filter();
            }
            else if (x == "Помещения")
            {
                lvTable.ItemsSource = AppData.Context.HallPhoto.ToList();
                Filter();
            }
            else if (x == "Серии поездов")
            {
                lvTable.ItemsSource = AppData.Context.TrainSeries.ToList();
                Filter();
            }
            else if (x == "Типы пересадкок")
            {
                lvTable.ItemsSource = AppData.Context.TransferType.ToList();
                Filter();
            }
            else if (x == "Пассажирпоток (описание)")
            {
                lvTable.ItemsSource = AppData.Context.TrafficDescription.ToList();
                Filter();
            }

        }

        private void btnAddUpdate_Click(object sender, RoutedEventArgs e)
        {
            //  ДОБАВЛЕНИЕ
            if (btnAddUpdate.Content.ToString() == "Добавить")
            {
                bool flagName = ClassHelper.Validation.IsNameValid(NewNameTxtBox.Text);
                if (flagName)
                {
                    try
                    {
                        Brush err = Brushes.Red;
                        Brush blue = btnAddUpdate.BorderBrush;

                        NewNameTxtBox.BorderBrush = flagName ? blue : err;
                        //NewNameTxtBox.Background = Brushes.White;
                        var resultClick = MessageBox.Show("Вы уверены?", "Подтвердите добавление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (resultClick == MessageBoxResult.Yes)
                        {
                            // Добавление нового объекта
                            Map newMap = new Map();
                            PhotoAngle newPhotoAngle = new PhotoAngle();
                            HallPhoto newHallPhoto = new HallPhoto();
                            TrainSeries newTrainSeries = new TrainSeries();
                            TransferType newTransferType = new TransferType();
                            TrafficDescription newTrafficDescription = new TrafficDescription();

                            if (TitleText.Text == "Карты")
                            {
                                newMap.Name = NewNameTxtBox.Text;
                                AppData.Context.Map.Add(newMap);
                            }
                            else if (TitleText.Text == "Помещения")
                            {
                                newHallPhoto.Name = NewNameTxtBox.Text;
                                AppData.Context.HallPhoto.Add(newHallPhoto);
                            }
                            else if (TitleText.Text == "Серии поездов")
                            {
                                newTrainSeries.Name = NewNameTxtBox.Text;
                                AppData.Context.TrainSeries.Add(newTrainSeries);
                            }
                            else if (TitleText.Text == "Типы пересадкок")
                            {
                                newTransferType.Name = NewNameTxtBox.Text;
                                AppData.Context.TransferType.Add(newTransferType);
                            }
                            else if (TitleText.Text == "Пассажирпоток (описание)")
                            {
                                newTrafficDescription.Name = NewNameTxtBox.Text;
                                AppData.Context.TrafficDescription.Add(newTrafficDescription);
                            }
                            else if (TitleText.Text == "Ракурсы")
                            {
                                newPhotoAngle.Name = NewNameTxtBox.Text;
                                AppData.Context.PhotoAngle.Add(newPhotoAngle);
                            }
                            else
                            {
                                MessageBox.Show("123", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Information);
                                return;
                            }

                            NewNameTxtBox.Text = "";
                            AppData.Context.SaveChanges();
                            Filter();
                            MessageBox.Show("Успех!", "Объект успешно добавлен!", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }

                else
                {
                    Brush err = Brushes.Red;
                    Brush blue = btnAddUpdate.BorderBrush;

                    NewNameTxtBox.BorderBrush = flagName ? blue : err;
                }
            }


            // ИЗМЕНЕНИЕ
            else if (btnAddUpdate.Content.ToString() == "Изменить")
            {
                var editMap = new Map();
                var editPhotoAngle = new PhotoAngle();
                var editHallPhoto = new HallPhoto();
                var editTrainSeries = new TrainSeries();
                var editTransferType = new TransferType();
                var editTrafficDescription = new TrafficDescription();

                if (lvTable.SelectedItem is Map) editMap = lvTable.SelectedItem as Map;
                else if (lvTable.SelectedItem is PhotoAngle) editPhotoAngle = lvTable.SelectedItem as PhotoAngle;
                else if (lvTable.SelectedItem is HallPhoto) editHallPhoto = lvTable.SelectedItem as HallPhoto;
                else if (lvTable.SelectedItem is TrainSeries) editTrainSeries = lvTable.SelectedItem as TrainSeries;
                else if (lvTable.SelectedItem is TransferType) editTransferType = lvTable.SelectedItem as TransferType;
                else if (lvTable.SelectedItem is TrafficDescription) editTrafficDescription = lvTable.SelectedItem as TrafficDescription;
                else
                {
                    MessageBox.Show("123", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                bool flagName = ClassHelper.Validation.IsNameValid(NewNameTxtBox.Text);
                if (flagName)
                {
                    try
                    {
                        Brush err = Brushes.Red;
                        Brush blue = btnAddUpdate.BorderBrush;

                        NewNameTxtBox.BorderBrush = flagName ? blue : err;
                        //NewNameTxtBox.Background = Brushes.White;
                        var resultClick = MessageBox.Show("Вы уверены?", "Подтвердите изменение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (resultClick == MessageBoxResult.Yes)
                        {
                            if (lvTable.SelectedItem is Map) editMap.Name = NewNameTxtBox.Text;
                            else if (lvTable.SelectedItem is PhotoAngle) editPhotoAngle.Name = NewNameTxtBox.Text;
                            else if (lvTable.SelectedItem is HallPhoto) editHallPhoto.Name = NewNameTxtBox.Text;
                            else if (lvTable.SelectedItem is TrainSeries) editTrainSeries.Name = NewNameTxtBox.Text;
                            else if (lvTable.SelectedItem is TransferType) editTransferType.Name = NewNameTxtBox.Text;
                            else if (lvTable.SelectedItem is TrafficDescription) editTrafficDescription.Name = NewNameTxtBox.Text;
                            else
                            {
                                MessageBox.Show("", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Information);
                                return;
                            }

                            NewNameTxtBox.Text = "";
                            AppData.Context.SaveChanges();
                            Filter();
                            btnAddUpdate.Content = "Добавить";
                            MessageBox.Show("Успех!", "Данные объекта успешно изменены!", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }

                else
                {
                    Brush err = Brushes.Red;
                    Brush blue = btnAddUpdate.BorderBrush;

                    NewNameTxtBox.BorderBrush = flagName ? blue : err;
                }


                //// Проверка на пустоту
                //if (string.IsNullOrWhiteSpace(NewNameTxtBox.Text))
                //{
                //    MessageBox.Show("Поля со * не должны быть пустым!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                //    return;
                //}
                //// Проверка на количество символов
                //if (NewNameTxtBox.Text.Length > 50)
                //{
                //    MessageBox.Show("Количество символов не должно быть больше 50!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                //    return;
                //}
            }
        }

        private void lvTable_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var editMap = new Map();
            var editPhotoAngle = new PhotoAngle();
            var editHallPhoto = new HallPhoto();
            var editTrainSeries = new TrainSeries();
            var editTransferType = new TransferType();
            var editTrafficDescription = new TrafficDescription();

            if (lvTable.SelectedItem is Map)
            {
                editMap = lvTable.SelectedItem as Map;
                NewNameTxtBox.Text = editMap.Name;
            }
            else if (lvTable.SelectedItem is PhotoAngle)
            {
                editPhotoAngle = lvTable.SelectedItem as PhotoAngle;
                NewNameTxtBox.Text = editPhotoAngle.Name;
            }
            else if (lvTable.SelectedItem is HallPhoto)
            {
                editHallPhoto = lvTable.SelectedItem as HallPhoto;
                NewNameTxtBox.Text = editHallPhoto.Name;
            }
            else if (lvTable.SelectedItem is TrainSeries)
            {
                editTrainSeries = lvTable.SelectedItem as TrainSeries;
                NewNameTxtBox.Text = editTrainSeries.Name;
            }
            else if (lvTable.SelectedItem is TransferType)
            {
                editTransferType = lvTable.SelectedItem as TransferType;
                NewNameTxtBox.Text = editTransferType.Name;
            }
            else if (lvTable.SelectedItem is TrafficDescription)
            {
                editTrafficDescription = lvTable.SelectedItem as TrafficDescription;
                NewNameTxtBox.Text = editTrafficDescription.Name;
            }
            else
            {
                MessageBox.Show("", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            btnAddUpdate.Content = "Изменить";
        }

        private void lvTable_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete || e.Key == Key.Back)
            {
                DeleteItem();
            }

            if (e.Key == Key.Escape)
            {
                NewNameTxtBox.Text = "";
                btnAddUpdate.Content = "Добавить";
            }
        }

        public void DeleteItem()
        {
            if (lvTable.SelectedItem is Map ||
                lvTable.SelectedItem is PhotoAngle ||
                lvTable.SelectedItem is HallPhoto ||
                lvTable.SelectedItem is TrafficDescription ||
                lvTable.SelectedItem is TrainSeries ||
                lvTable.SelectedItem is TransferType &&
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

                    var resultClick = MessageBox.Show("Вы уверены?", "Подтвердите удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (resultClick == MessageBoxResult.Yes)
                    {
                        if (lvTable.SelectedItem is Map) AppData.Context.Map.Remove(itemMap);
                        else if (lvTable.SelectedItem is PhotoAngle) AppData.Context.PhotoAngle.Remove(itemPhotoAngle);
                        else if (lvTable.SelectedItem is HallPhoto) AppData.Context.HallPhoto.Remove(itemHallPhoto);
                        else if (lvTable.SelectedItem is TrafficDescription) AppData.Context.TrafficDescription.Remove(itemTrafficDescription);
                        else if (lvTable.SelectedItem is TrainSeries) AppData.Context.TrainSeries.Remove(itemTrainSeries);
                        else if (lvTable.SelectedItem is TransferType) AppData.Context.TransferType.Remove(itemTransferType);

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

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "Для удаления объекта щёлкните по нему в таблице правой кнопкой мыши, или нажмите на него левой кнопкой, а затем Delete или Backspase.\n\n" +
                "Для изменения дважды щёлкните левой кнопкой мыши по выбранному объекту.\n\n" +
                "Чтобы отменить действе изменения объекта, нажмите Esc", 
                "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Filter()
        {
            if (TitleText.Text == "Карты")
            {
                MapList = AppData.Context.Map.ToList();
                MapList = MapList.Where(i => i.Name.ToLower().Contains(txtSearch.Text.ToLower()) || i.ID.ToString().ToLower().Contains(txtSearch.Text.ToLower())).ToList();
                if (cmbSort.SelectedIndex == 0) MapList = MapList.OrderBy(i => i.ID).ToList();
                if (cmbSort.SelectedIndex == 1) MapList = MapList.OrderBy(i => i.Name).ToList();
                else MapList = MapList.OrderBy(i => i.ID).ToList();
                lvTable.ItemsSource = MapList;
            }
            else if (TitleText.Text == "Ракурсы")
            {
                PhotoAngleList = AppData.Context.PhotoAngle.ToList();
                PhotoAngleList = PhotoAngleList.Where(i => i.Name.ToLower().Contains(txtSearch.Text.ToLower()) || i.ID.ToString().ToLower().Contains(txtSearch.Text.ToLower())).ToList();
                if (cmbSort.SelectedIndex == 0) PhotoAngleList = PhotoAngleList.OrderBy(i => i.ID).ToList();
                if (cmbSort.SelectedIndex == 1) PhotoAngleList = PhotoAngleList.OrderBy(i => i.Name).ToList();
                else PhotoAngleList = PhotoAngleList.OrderBy(i => i.ID).ToList();
                lvTable.ItemsSource = PhotoAngleList;
            }
            else if (TitleText.Text == "Помещения")
            {
                HallPhotoList = AppData.Context.HallPhoto.ToList();
                HallPhotoList = HallPhotoList.Where(i => i.Name.ToLower().Contains(txtSearch.Text.ToLower()) || i.ID.ToString().ToLower().Contains(txtSearch.Text.ToLower())).ToList();
                if (cmbSort.SelectedIndex == 0) HallPhotoList = HallPhotoList.OrderBy(i => i.ID).ToList();
                if (cmbSort.SelectedIndex == 1) HallPhotoList = HallPhotoList.OrderBy(i => i.Name).ToList();
                else HallPhotoList = HallPhotoList.OrderBy(i => i.ID).ToList();
                lvTable.ItemsSource = HallPhotoList;
            }
            else if (TitleText.Text == "Серии поездов")
            {
                TrainSeriesList = AppData.Context.TrainSeries.ToList();
                TrainSeriesList = TrainSeriesList.Where(i => i.Name.ToLower().Contains(txtSearch.Text.ToLower()) || i.ID.ToString().ToLower().Contains(txtSearch.Text.ToLower())).ToList();
                if (cmbSort.SelectedIndex == 0) TrainSeriesList = TrainSeriesList.OrderBy(i => i.ID).ToList();
                if (cmbSort.SelectedIndex == 1) TrainSeriesList = TrainSeriesList.OrderBy(i => i.Name).ToList();
                else TrainSeriesList = TrainSeriesList.OrderBy(i => i.ID).ToList();
                lvTable.ItemsSource = TrainSeriesList;
            }
            else if (TitleText.Text == "Типы пересадкок")
            {
                TransferTypeList = AppData.Context.TransferType.ToList();
                TransferTypeList = TransferTypeList.Where(i => i.Name.ToLower().Contains(txtSearch.Text.ToLower()) || i.ID.ToString().ToLower().Contains(txtSearch.Text.ToLower())).ToList();
                if (cmbSort.SelectedIndex == 0) TransferTypeList = TransferTypeList.OrderBy(i => i.ID).ToList();
                if (cmbSort.SelectedIndex == 1) TransferTypeList = TransferTypeList.OrderBy(i => i.Name).ToList();
                else TransferTypeList = TransferTypeList.OrderBy(i => i.ID).ToList();
                lvTable.ItemsSource = TransferTypeList;
            }
            else if (TitleText.Text == "Пассажирпоток (описание)")
            {
                TrafficDescriptionList = AppData.Context.TrafficDescription.ToList();
                TrafficDescriptionList = TrafficDescriptionList.Where(i => i.Name.ToLower().Contains(txtSearch.Text.ToLower()) || i.ID.ToString().ToLower().Contains(txtSearch.Text.ToLower())).ToList();
                if (cmbSort.SelectedIndex == 0) TrafficDescriptionList = TrafficDescriptionList.OrderBy(i => i.ID).ToList();
                if (cmbSort.SelectedIndex == 1) TrafficDescriptionList = TrafficDescriptionList.OrderBy(i => i.Name).ToList();
                else TrafficDescriptionList = TrafficDescriptionList.OrderBy(i => i.ID).ToList();
                lvTable.ItemsSource = TrafficDescriptionList;
            }
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

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditorPage());
        }
    }
}