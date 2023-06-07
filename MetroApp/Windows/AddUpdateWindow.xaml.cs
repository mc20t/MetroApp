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
using System.Windows.Shapes;
using MetroApp.Pages;
using MetroApp.DB;
using MetroApp.ClassHelper;
using System.Xml.Linq;

namespace MetroApp
{
    public partial class AddUpdateWindow : Window
    {
        string global;
        string format;
        public string[] addubrReturn = new string[20];
        //string pathPhoto = null; // Для сохранения пути к изображению
        TextBlock tbName = new TextBlock();
        TextBlock tbAbbr = new TextBlock();
        TextBox NewFirstTxtBox = new TextBox { BorderBrush = Brushes.Gray };
        TextBox NewSecondTxtBox = new TextBox { BorderBrush = Brushes.Gray };


        public AddUpdateWindow(string x, string[] s)
        {
            InitializeComponent();
            global = x;
            if (x == "Карты" || x == "Ракурсы" || x == "Помещения" ||
                x == "Серии поездов" || x == "Типы пересадкок" || x == "Пассажирпоток (описание)")
                SetIdTxt(s);
            else if (x == "Депо" || x == "Конструкции" || x == "Пролёты" ||
                     x == "Перекрытия" || x == "Особенности" || x == "Платформы")
                SetIdTxtTxt(s);
        }

        public void SetIdTxt(string[] s)
        {
            tbName.FontSize = 25;
            tbName.HorizontalAlignment = HorizontalAlignment.Right;
            tbName.Text = "Название*";
            tbName.Margin = new Thickness(5);
            StPanText.Children.Add(tbName);

            NewFirstTxtBox.FontSize = 25;
            NewFirstTxtBox.Width = 200;
            NewFirstTxtBox.Margin = new Thickness(5);
            NewFirstTxtBox.HorizontalAlignment = HorizontalAlignment.Left;
            StPanTxtBox.Children.Add(NewFirstTxtBox);

            NewFirstTxtBox.Text = s[0];
            format = "IdText";
        }

        public void SetIdTxtTxt(string[] s)
        {
            tbName.FontSize = 25;
            tbName.HorizontalAlignment = HorizontalAlignment.Right;
            if (global == "Платформы") tbName.Text = "Береговая*";
            else tbName.Text = "Название*";
            tbName.Margin = new Thickness(5);
            StPanText.Children.Add(tbName);

            tbAbbr.FontSize = 25;
            tbAbbr.Margin = new Thickness(5);
            tbAbbr.HorizontalAlignment = HorizontalAlignment.Right;
            if (global == "Депо") tbAbbr.Text = "Код*";
            else if (global == "Платформы") tbAbbr.Text = "Островная*";
            else tbAbbr.Text = "Аббревиатура*";
            StPanText.Children.Add(tbAbbr);

            NewFirstTxtBox.FontSize = 25;
            NewFirstTxtBox.Width = 200;
            NewFirstTxtBox.Margin = new Thickness(5);
            NewFirstTxtBox.HorizontalAlignment = HorizontalAlignment.Left;
            StPanTxtBox.Children.Add(NewFirstTxtBox);

            NewSecondTxtBox.FontSize = 25;
            NewSecondTxtBox.Width = 200;
            NewSecondTxtBox.Margin = new Thickness(5);
            NewSecondTxtBox.HorizontalAlignment = HorizontalAlignment.Left;
            StPanTxtBox.Children.Add(NewSecondTxtBox);

            NewFirstTxtBox.Text = s[0];
            NewSecondTxtBox.Text = s[1];
            format = "IdTextText";
        }



        private void btnAddUpdate_Click(object sender, RoutedEventArgs e)
        {
            Brush err = Brushes.Red;
            Brush ok = Brushes.Gray;
            bool flagOne;
            bool flagTwo;
            string Info = "Все поля должны быть заполнены корректно!\n\n" +
                          "Название: от 1 до 50 символов\n" +
                          "Аббревиатура: от 1 до 7 символов\n" +
                          "Числовые поля...";

            if (format == "IdText")
            {
                NewFirstTxtBox.Text = NewFirstTxtBox.Text.Trim();
                flagOne = ClassHelper.Validation.IsNameValid(NewFirstTxtBox.Text);
                if (flagOne)
                {
                    NewFirstTxtBox.BorderBrush = ok;
                    if (btnAddUpdate.Content.ToString() == "Изменить") UpdateObject();
                    else if (btnAddUpdate.Content.ToString() == "Добавить") AddObject();
                }
                else
                {
                    NewFirstTxtBox.BorderBrush = err;
                    MessageBox.Show(Info, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            else if (format == "IdTextText")
            {
                NewFirstTxtBox.Text = NewFirstTxtBox.Text.Trim();
                NewSecondTxtBox.Text = NewSecondTxtBox.Text.Trim();
                if (global == "Платформы")
                {
                    flagOne = ClassHelper.Validation.IsTintValid(NewFirstTxtBox.Text);
                    flagTwo = ClassHelper.Validation.IsTintValid(NewSecondTxtBox.Text);
                }
                else
                {
                    flagOne = ClassHelper.Validation.IsNameValid(NewFirstTxtBox.Text);
                    flagTwo = ClassHelper.Validation.IsAbbrValid(NewSecondTxtBox.Text);
                }
                
                if (flagOne && flagTwo)
                {
                    NewFirstTxtBox.BorderBrush = ok;
                    NewSecondTxtBox.BorderBrush = ok;
                    if (btnAddUpdate.Content.ToString() == "Изменить") UpdateObject();
                    else if (btnAddUpdate.Content.ToString() == "Добавить") AddObject();
                }
                else
                {
                    NewFirstTxtBox.BorderBrush = flagOne ? ok : err;
                    NewSecondTxtBox.BorderBrush = flagTwo ? ok : err;
                    MessageBox.Show(Info, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            else
            {
                MessageBox.Show("Процедура прервана", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
        }

        public void AddObject()
        {
            try
            {
                var resultClick = MessageBox.Show("Вы уверены?", "Подтвердите добавление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (resultClick == MessageBoxResult.Yes)
                {
                    if (global == "Карты")
                    {
                        Map newObj = new Map { Name = NewFirstTxtBox.Text };
                        AppData.Context.Map.Add(newObj);
                    }
                    else if (global == "Ракурсы")
                    {
                        PhotoAngle newObj = new PhotoAngle { Name = NewFirstTxtBox.Text };
                        AppData.Context.PhotoAngle.Add(newObj);
                    }
                    else if (global == "Помещения")
                    {
                        HallPhoto newObj = new HallPhoto { Name = NewFirstTxtBox.Text };
                        AppData.Context.HallPhoto.Add(newObj);
                    }
                    else if (global == "Серии поездов")
                    {
                        TrainSeries newObj = new TrainSeries { Name = NewFirstTxtBox.Text };
                        AppData.Context.TrainSeries.Add(newObj);
                    }
                    else if (global == "Типы пересадкок")
                    {
                        TransferType newObj = new TransferType { Name = NewFirstTxtBox.Text };
                        AppData.Context.TransferType.Add(newObj);
                    }
                    else if (global == "Пассажирпоток (описание)")
                    {
                        TrafficDescription newObj = new TrafficDescription { Name = NewFirstTxtBox.Text };
                        AppData.Context.TrafficDescription.Add(newObj);
                    }
                    else if (global == "Депо")
                    {
                        Depot newObj = new Depot();
                        newObj.Name = NewFirstTxtBox.Text;
                        newObj.Code = NewSecondTxtBox.Text;
                        AppData.Context.Depot.Add(newObj);
                    }
                    else if (global == "Конструкции")
                    {
                        Construction newObj = new Construction();
                        newObj.Title = NewFirstTxtBox.Text;
                        newObj.Abbreviation = NewSecondTxtBox.Text;
                        AppData.Context.Construction.Add(newObj);
                    }
                    else if (global == "Пролёты")
                    {
                        DB.Span newObj = new DB.Span();
                        newObj.Title = NewFirstTxtBox.Text;
                        newObj.Abbreviation = NewSecondTxtBox.Text;
                        AppData.Context.Span.Add(newObj);
                    }
                    else if (global == "Перекрытия")
                    {
                        Floor newObj = new Floor();
                        newObj.Title = NewFirstTxtBox.Text;
                        newObj.Abbreviation = NewSecondTxtBox.Text;
                        AppData.Context.Floor.Add(newObj);
                    }
                    else if (global == "Особенности")
                    {
                        Peculiarity newObj = new Peculiarity();
                        newObj.Title = NewFirstTxtBox.Text;
                        newObj.Abbreviation = NewSecondTxtBox.Text;
                        AppData.Context.Peculiarity.Add(newObj);
                    }
                    else if (global == "Платформы")
                    {
                        Platform newObj = new Platform();
                        byte u = byte.Parse(NewFirstTxtBox.Text);
                        byte b = byte.Parse(NewSecondTxtBox.Text);
                        newObj.Unilateral = u;
                        newObj.Bilateral = b;
                        AppData.Context.Platform.Add(newObj);
                    }

                    else
                    {
                        MessageBox.Show("Процедура прервана", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }

                    AppData.Context.SaveChanges();
                    this.Close();
                    MessageBox.Show("Успех!", "Объект успешно добавлен!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public void UpdateObject()
        {
            try
            {
                var resultClick = MessageBox.Show("Вы уверены?", "Подтвердите изменение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (resultClick == MessageBoxResult.Yes)
                {
                    if (format == "IdText")
                    {
                        addubrReturn[0] = NewFirstTxtBox.Text;
                        this.Close();
                    }
                    else if (format == "IdTextText")
                    {
                        addubrReturn[0] = NewFirstTxtBox.Text;
                        addubrReturn[1] = NewSecondTxtBox.Text;
                        this.Close();
                    }

                    else
                    {
                        MessageBox.Show("Процедура прервана", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}