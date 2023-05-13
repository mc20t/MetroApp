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
    public partial class IdTitlePage : Page
    {
        List<Map> mapList = new List<Map>();
        List<string> listSortMap = new List<string>() { "По умолчанию", "По названию" };

        public IdTitlePage(string x)
        {
            InitializeComponent();
            Title += x;
            IdTitleTxt.Text = x;

            if (x == "Карты")
            {
                lvIdTitle.ItemsSource = AppData.Context.Map.ToList();
                cmbSort.ItemsSource = listSortMap;
                cmbSort.SelectedIndex = 0;
                Filter();
            }
        }

        private void btnAddUpdate_Click(object sender, RoutedEventArgs e)
        {
            //  ДОБАВЛЕНИЕ
            if (btnAddUpdate.Content.ToString() == "Добавить")
            {
                // Валидация проверка на пустоту
                if (string.IsNullOrWhiteSpace(NewNameTxtBox.Text))
                {
                    MessageBox.Show("Поле Название не должно быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                try
                {
                    var resultClick = MessageBox.Show("Вы уверены?", "Подтвердите добавление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (resultClick == MessageBoxResult.Yes)
                    {
                        // Добавление нового объекта
                        Map newMap = new Map();
                        newMap.Name = NewNameTxtBox.Text;
                        AppData.Context.Map.Add(newMap);
                        NewNameTxtBox.Text = "";
                        AppData.Context.SaveChanges();
                        Filter();
                        MessageBox.Show("Успех!", "Карта успешно добавлена!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }


            // ИЗМЕНЕНИЕ
            if (btnAddUpdate.Content.ToString() == "Изменить")
            {
                var editMap = new Map();
                if (lvIdTitle.SelectedItem is Map)
                {
                    editMap = lvIdTitle.SelectedItem as Map;
                }

                // Валидация проверка на пустоту
                if (string.IsNullOrWhiteSpace(NewNameTxtBox.Text))
                {
                    MessageBox.Show("Поле Название не должно быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                try
                {
                    var resultClick = MessageBox.Show("Вы уверены?", "Подтвердите изменение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (resultClick == MessageBoxResult.Yes)
                    {
                        editMap.Name = NewNameTxtBox.Text;
                        NewNameTxtBox.Text = "";
                        AppData.Context.SaveChanges();
                        Filter();
                        btnAddUpdate.Content = "Добавить";
                        MessageBox.Show("Успех!", "Данные карты успешно изменены!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

                //this.Opacity = 0.2;
                //lvIdTitle.ItemsSource = AppData.Context.Map.ToList();
                //this.Opacity = 1;
            }
        }

        private void lvIdTitle_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var editMap = new Map();
            if (lvIdTitle.SelectedItem is Map)
            {
                editMap = lvIdTitle.SelectedItem as Map;
            }

            btnAddUpdate.Content = "Изменить";
            NewNameTxtBox.Text = editMap.Name;
        }

        private void lvIdTitle_KeyUp(object sender, KeyEventArgs e)
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
            if (lvIdTitle.SelectedItem is Map && lvIdTitle.SelectedIndex != -1)
            {
                try
                {
                    var item = lvIdTitle.SelectedItem as Map;
                    var resultClick = MessageBox.Show("Вы уверены?", "Подтвердите удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (resultClick == MessageBoxResult.Yes)
                    {
                        AppData.Context.Map.Remove(item);
                        AppData.Context.SaveChanges();
                        Filter();
                        MessageBox.Show("Карта успешно удалена!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void lvIdTitle_RightButtonUp(object sender, MouseButtonEventArgs e)
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

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "Для удаления объекта щёлкните по нему в таблице правок кнопкой мыши, или нажмите на него левой кнопкой, а затем Delete или Backspase.\n\n" +
                "Для изменения дважды щёлкните левой кнопкой мыши по выбранному объекту.\n\n" +
                "Чтобы отменить действе изменения объекта, нажмите Esc", 
                "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Filter()
        {
            if (IdTitleTxt.Text == "Карты")
            {
                mapList = AppData.Context.Map.ToList();
                mapList = mapList.
                    Where(i =>
                        i.Name.ToLower().Contains(txtSearch.Text.ToLower()) ||
                        i.ID.ToString().ToLower().Contains(txtSearch.Text.ToLower())
                    ).ToList();

                switch (cmbSort.SelectedIndex)
                {
                    case 0:
                        mapList = mapList.OrderBy(i => i.ID).ToList();
                        break;
                    case 1:
                        mapList = mapList.OrderBy(i => i.Name).ToList();
                        break;
                    default:
                        mapList = mapList.OrderBy(i => i.ID).ToList();
                        break;
                }

                lvIdTitle.ItemsSource = mapList;
            }
            
        }
    }
}
