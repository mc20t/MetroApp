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
    public partial class IdTitleAbbrPage : Page
    {
        List<Depot> DepotList = new List<Depot>();
        List<Construction> ConstructionList = new List<Construction>();
        List<DB.Span> SpanList = new List<DB.Span>();
        List<Floor> FloorList = new List<Floor>();
        List<Peculiarity> PeculiarityList = new List<Peculiarity>();
        List<string> listSort = new List<string>() { "По умолчанию", "По названию", "По аббревиатуре" };

        public IdTitleAbbrPage(string x)
        {
            InitializeComponent();
            cmbSort.ItemsSource = listSort;
            cmbSort.SelectedIndex = 0;
            Title += x;
            TitleText.Text = x;

            if (x == "Депо")
            {
                lvTable.ItemsSource = AppData.Context.Depot.ToList();
                Filter();
            }
            else if (x == "Конструкции")
            {
                lvTable.ItemsSource = AppData.Context.Construction.ToList();
                Filter();
            }
            else if (x == "Пролёты")
            {
                lvTable.ItemsSource = AppData.Context.Span.ToList();
                Filter();
            }
            else if (x == "Перекрытия")
            {
                lvTable.ItemsSource = AppData.Context.Floor.ToList();
                Filter();
            }
            else if (x == "Особенности")
            {
                lvTable.ItemsSource = AppData.Context.Peculiarity.ToList();
                Filter();
            }

        }

        private void btnAddUpdate_Click(object sender, RoutedEventArgs e)
        {
            //  ДОБАВЛЕНИЕ
            if (btnAddUpdate.Content.ToString() == "Добавить")
            {
                // Проверка на пустоту
                if (string.IsNullOrWhiteSpace(NewNameTxtBox.Text) || string.IsNullOrWhiteSpace(NewAbbrTxtBox.Text))
                {
                    NewNameTxtBox.Background = Brushes.Red;
                    NewAbbrTxtBox.Background = Brushes.Red;
                    MessageBox.Show("Поля со * не должны быть пустыми!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                // Проверка на количество символов
                if (NewNameTxtBox.Text.Length > 50)
                {
                    NewNameTxtBox.Background = Brushes.Red;
                    NewAbbrTxtBox.Background = Brushes.Red;
                    MessageBox.Show("Количество символов не должно быть больше 50!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                try
                {
                    NewNameTxtBox.Background = Brushes.White;
                    NewAbbrTxtBox.Background = Brushes.White;
                    var resultClick = MessageBox.Show("Вы уверены?", "Подтвердите добавление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (resultClick == MessageBoxResult.Yes)
                    {
                        // Добавление нового объекта
                        Depot newDepot = new Depot();
                        Construction newConstruction = new Construction();
                        DB.Span newSpan = new DB.Span();
                        Floor newFloor = new Floor();
                        Peculiarity newPeculiarity = new Peculiarity();

                        if (TitleText.Text == "Депо")
                        {
                            newDepot.Name = NewNameTxtBox.Text;
                            newDepot.Code = NewAbbrTxtBox.Text;
                            AppData.Context.Depot.Add(newDepot);
                        }
                        else if (TitleText.Text == "Пролёты")
                        {
                            newSpan.Title = NewNameTxtBox.Text;
                            newSpan.Abbreviation = NewAbbrTxtBox.Text;
                            AppData.Context.Span.Add(newSpan);
                        }
                        else if (TitleText.Text == "Перекрытия")
                        {
                            newFloor.Title = NewNameTxtBox.Text;
                            newFloor.Abbreviation = NewAbbrTxtBox.Text;
                            AppData.Context.Floor.Add(newFloor);
                        }
                        else if (TitleText.Text == "Особенности")
                        {
                            newPeculiarity.Title = NewNameTxtBox.Text;
                            newPeculiarity.Abbreviation = NewAbbrTxtBox.Text;
                            AppData.Context.Peculiarity.Add(newPeculiarity);
                        }
                        else if (TitleText.Text == "Конструкции")
                        {
                            newConstruction.Title = NewNameTxtBox.Text;
                            newConstruction.Abbreviation = NewAbbrTxtBox.Text;
                            AppData.Context.Construction.Add(newConstruction);
                        }
                        else
                        {
                            MessageBox.Show("123", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Information);
                            return;
                        }

                        NewNameTxtBox.Text = "";
                        NewAbbrTxtBox.Text = "";
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


            // ИЗМЕНЕНИЕ
            else if (btnAddUpdate.Content.ToString() == "Изменить")
            {
                var editDepot = new Depot();
                var editConstruction = new Construction();
                var editSpan = new DB.Span();
                var editFloor = new Floor();
                var editPeculiarity = new Peculiarity();

                if (lvTable.SelectedItem is Depot) editDepot = lvTable.SelectedItem as Depot;
                else if (lvTable.SelectedItem is Construction) editConstruction = lvTable.SelectedItem as Construction;
                else if (lvTable.SelectedItem is DB.Span) editSpan = lvTable.SelectedItem as DB.Span;
                else if (lvTable.SelectedItem is Floor) editFloor = lvTable.SelectedItem as Floor;
                else if (lvTable.SelectedItem is Peculiarity) editPeculiarity = lvTable.SelectedItem as Peculiarity;
                else
                {
                    MessageBox.Show("123", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                // Проверка на пустоту
                if (string.IsNullOrWhiteSpace(NewNameTxtBox.Text) || string.IsNullOrWhiteSpace(NewAbbrTxtBox.Text))
                {
                    NewNameTxtBox.Background = Brushes.Red;
                    NewAbbrTxtBox.Background = Brushes.Red;
                    MessageBox.Show("Поля со * не должны быть пустыми!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                // Проверка на количество символов
                if (NewNameTxtBox.Text.Length > 50)
                {
                    NewNameTxtBox.Background = Brushes.Red;
                    NewAbbrTxtBox.Background = Brushes.Red;
                    MessageBox.Show("Количество символов не должно быть больше 50!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                try
                {
                    NewNameTxtBox.Background = Brushes.White;
                    NewAbbrTxtBox.Background = Brushes.White;
                    var resultClick = MessageBox.Show("Вы уверены?", "Подтвердите изменение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (resultClick == MessageBoxResult.Yes)
                    {
                        if (lvTable.SelectedItem is Depot)
                        {
                            editDepot.Name = NewNameTxtBox.Text;
                            editDepot.Code = NewAbbrTxtBox.Text;
                        }
                        else if (lvTable.SelectedItem is Construction)
                        {
                            editConstruction.Title = NewNameTxtBox.Text;
                            editConstruction.Abbreviation = NewAbbrTxtBox.Text;
                        }
                        else if (lvTable.SelectedItem is DB.Span)
                        {
                            editSpan.Title = NewNameTxtBox.Text;
                            editSpan.Abbreviation = NewAbbrTxtBox.Text;
                        }
                        else if (lvTable.SelectedItem is Floor)
                        {
                            editFloor.Title = NewNameTxtBox.Text;
                            editFloor.Abbreviation = NewAbbrTxtBox.Text;
                        }
                        else if (lvTable.SelectedItem is Peculiarity)
                        {
                            editPeculiarity.Title = NewNameTxtBox.Text;
                            editFloor.Abbreviation = NewAbbrTxtBox.Text;
                        }
                        else
                        {
                            MessageBox.Show("", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Information);
                            return;
                        }

                        NewNameTxtBox.Text = "";
                        NewAbbrTxtBox.Text = "";
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
        }

        private void lvTable_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var editDepot = new Depot();
            var editConstruction = new Construction();
            var editSpan = new DB.Span();
            var editFloor = new Floor();
            var editPeculiarity = new Peculiarity();

            if (lvTable.SelectedItem is Depot)
            {
                editDepot = lvTable.SelectedItem as Depot;
                NewNameTxtBox.Text = editDepot.Name;
                NewAbbrTxtBox.Text = editDepot.Code;
            }
            else if (lvTable.SelectedItem is Construction)
            {
                editConstruction = lvTable.SelectedItem as Construction;
                NewNameTxtBox.Text = editConstruction.Title;
                NewAbbrTxtBox.Text = editConstruction.Abbreviation;
            }
            else if (lvTable.SelectedItem is DB.Span)
            {
                editSpan = lvTable.SelectedItem as DB.Span;
                NewNameTxtBox.Text = editSpan.Title;
                NewAbbrTxtBox.Text = editSpan.Abbreviation;
            }
            else if (lvTable.SelectedItem is Floor)
            {
                editFloor = lvTable.SelectedItem as Floor;
                NewNameTxtBox.Text = editFloor.Title;
                NewAbbrTxtBox.Text = editFloor.Abbreviation;
            }
            else if (lvTable.SelectedItem is Peculiarity)
            {
                editPeculiarity = lvTable.SelectedItem as Peculiarity;
                NewNameTxtBox.Text = editPeculiarity.Title;
                NewAbbrTxtBox.Text = editPeculiarity.Abbreviation;
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
                NewAbbrTxtBox.Text = "";
                btnAddUpdate.Content = "Добавить";
            }
        }

        public void DeleteItem()
        {
            if (lvTable.SelectedItem is Depot ||
                lvTable.SelectedItem is Construction ||
                lvTable.SelectedItem is DB.Span ||
                lvTable.SelectedItem is Peculiarity ||
                lvTable.SelectedItem is Floor &&
                lvTable.SelectedIndex != -1)
            {
                try
                {
                    var itemDepot = lvTable.SelectedItem as Depot;
                    var itemConstruction = lvTable.SelectedItem as Construction;
                    var itemSpan = lvTable.SelectedItem as DB.Span;
                    var itemPeculiarity = lvTable.SelectedItem as Peculiarity;
                    var itemFloor = lvTable.SelectedItem as Floor;

                    var resultClick = MessageBox.Show("Вы уверены?", "Подтвердите удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (resultClick == MessageBoxResult.Yes)
                    {
                        if (lvTable.SelectedItem is Depot) AppData.Context.Depot.Remove(itemDepot);
                        else if (lvTable.SelectedItem is Construction) AppData.Context.Construction.Remove(itemConstruction);
                        else if (lvTable.SelectedItem is DB.Span) AppData.Context.Span.Remove(itemSpan);
                        else if (lvTable.SelectedItem is Peculiarity) AppData.Context.Peculiarity.Remove(itemPeculiarity);
                        else if (lvTable.SelectedItem is Floor) AppData.Context.Floor.Remove(itemFloor);

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
            if (TitleText.Text == "Депо")
            {
                DepotList = AppData.Context.Depot.ToList();
                DepotList = DepotList.Where(i => i.Name.ToLower().Contains(txtSearch.Text.ToLower()) ||
                                                 i.ID.ToString().ToLower().Contains(txtSearch.Text.ToLower()) ||
                                                 i.Code.ToString().ToLower().Contains(txtSearch.Text.ToLower())).ToList();
                if (cmbSort.SelectedIndex == 0) DepotList = DepotList.OrderBy(i => i.ID).ToList();
                if (cmbSort.SelectedIndex == 1) DepotList = DepotList.OrderBy(i => i.Name).ToList();
                if (cmbSort.SelectedIndex == 2) DepotList = DepotList.OrderBy(i => i.Code).ToList();
                else DepotList = DepotList.OrderBy(i => i.ID).ToList();
                lvTable.ItemsSource = DepotList;
            }
            else if (TitleText.Text == "Конструкции")
            {
                ConstructionList = AppData.Context.Construction.ToList();
                ConstructionList = ConstructionList.Where(i => i.Title.ToLower().Contains(txtSearch.Text.ToLower()) ||
                                                               i.ID.ToString().ToLower().Contains(txtSearch.Text.ToLower()) ||
                                                               i.Abbreviation.ToString().ToLower().Contains(txtSearch.Text.ToLower())).ToList();
                if (cmbSort.SelectedIndex == 0) ConstructionList = ConstructionList.OrderBy(i => i.ID).ToList();
                if (cmbSort.SelectedIndex == 1) ConstructionList = ConstructionList.OrderBy(i => i.Title).ToList();
                if (cmbSort.SelectedIndex == 2) ConstructionList = ConstructionList.OrderBy(i => i.Abbreviation).ToList();
                else ConstructionList = ConstructionList.OrderBy(i => i.ID).ToList();
                lvTable.ItemsSource = ConstructionList;
            }
            else if (TitleText.Text == "Пролёты")
            {
                SpanList = AppData.Context.Span.ToList();
                SpanList = SpanList.Where(i => i.Title.ToLower().Contains(txtSearch.Text.ToLower()) ||
                                               i.ID.ToString().ToLower().Contains(txtSearch.Text.ToLower()) ||
                                               i.Abbreviation.ToString().ToLower().Contains(txtSearch.Text.ToLower())).ToList();
                if (cmbSort.SelectedIndex == 0) SpanList = SpanList.OrderBy(i => i.ID).ToList();
                if (cmbSort.SelectedIndex == 1) SpanList = SpanList.OrderBy(i => i.Title).ToList();
                if (cmbSort.SelectedIndex == 2) SpanList = SpanList.OrderBy(i => i.Abbreviation).ToList();
                else SpanList = SpanList.OrderBy(i => i.ID).ToList();
                lvTable.ItemsSource = SpanList;
            }
            else if (TitleText.Text == "Перекрытия")
            {
                FloorList = AppData.Context.Floor.ToList();
                FloorList = FloorList.Where(i => i.Title.ToLower().Contains(txtSearch.Text.ToLower()) ||
                                                 i.ID.ToString().ToLower().Contains(txtSearch.Text.ToLower()) ||
                                                 i.Abbreviation.ToString().ToLower().Contains(txtSearch.Text.ToLower())).ToList();
                if (cmbSort.SelectedIndex == 0) FloorList = FloorList.OrderBy(i => i.ID).ToList();
                if (cmbSort.SelectedIndex == 1) FloorList = FloorList.OrderBy(i => i.Title).ToList();
                if (cmbSort.SelectedIndex == 2) FloorList = FloorList.OrderBy(i => i.Abbreviation).ToList();
                else FloorList = FloorList.OrderBy(i => i.ID).ToList();
                lvTable.ItemsSource = FloorList;
            }
            else if (TitleText.Text == "Особенности")
            {
                PeculiarityList = AppData.Context.Peculiarity.ToList();
                PeculiarityList = PeculiarityList.Where(i => i.Title.ToLower().Contains(txtSearch.Text.ToLower()) ||
                                                             i.ID.ToString().ToLower().Contains(txtSearch.Text.ToLower()) ||
                                                             i.Abbreviation.ToString().ToLower().Contains(txtSearch.Text.ToLower())).ToList();
                if (cmbSort.SelectedIndex == 0) PeculiarityList = PeculiarityList.OrderBy(i => i.ID).ToList();
                if (cmbSort.SelectedIndex == 1) PeculiarityList = PeculiarityList.OrderBy(i => i.Title).ToList();
                if (cmbSort.SelectedIndex == 2) PeculiarityList = PeculiarityList.OrderBy(i => i.Abbreviation).ToList();
                else PeculiarityList = PeculiarityList.OrderBy(i => i.ID).ToList();
                lvTable.ItemsSource = PeculiarityList;
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