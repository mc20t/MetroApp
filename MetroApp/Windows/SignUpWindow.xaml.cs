using System;
using System.IO;
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

namespace MetroApp.Windows
{
    public partial class SignUpWindow : Window
    {
        public SignUpWindow()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            Brush err = Brushes.Red;

            string pathPsswrd = "C:/qwerty/psswrd.txt";
            string pathValid = "C:/qwerty/valid.txt";
            string checkPsswrd;
            string checkValid;

            using (StreamWriter writerV = new StreamWriter(pathValid, false)) writerV.Write(tbxPassword.Text);
            using (StreamReader readerP = new StreamReader(pathPsswrd)) checkPsswrd = readerP.Read().ToString();
            using (StreamReader readerV = new StreamReader(pathValid)) checkValid = readerV.Read().ToString();

            if (checkPsswrd == checkValid) this.Close();
            else
            {
                tbxPassword.BorderBrush = err;
                tbxPassword.Text = "";
                MessageBox.Show("Неверный пароль!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
