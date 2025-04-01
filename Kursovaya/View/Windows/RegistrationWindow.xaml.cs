using Kursovaya.Model;
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

namespace Kursovaya.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string FullName = FullNameTb.Text;
            string Login = LoginTb.Text; 
            string Passowrd = PassowrdPb.Password;
            if (string.IsNullOrEmpty(FullName) || string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(Passowrd))
            {
                MessageBox.Show("Пожалуйста, заполните все обязательные поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            Employees Employees = new Employees()
            {
                FullName = FullName,
                Login = Login,
                Passowrd = Passowrd,
            };
            App.context.Employees.Add(Employees);
            App.context.SaveChanges();
            MessageBox.Show($"Регистрация успешна!\nИмя: {FullName}\nLogin: {Login}", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
