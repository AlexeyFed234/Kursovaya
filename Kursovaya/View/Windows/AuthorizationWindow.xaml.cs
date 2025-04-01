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
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LoginTb.Text))
            {
                MessageBox.Show("Пожалуйста, заполните логин.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning); return;
            }
            if (string.IsNullOrWhiteSpace(PasswordPb.Password))
            {
                MessageBox.Show("Пожалуйста, заполните пароль.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning); return;
            }
            var employee = App.context.Employees.ToList().Where(index => index.Login == LoginTb.Text && index.Passowrd == PasswordPb.Password).FirstOrDefault();
            if (employee != null)
            {
                MessageBox.Show("Добро пожаловать!");
                MainWindow maimWindow = new MainWindow(); maimWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Вы ввели неправильный логин или пароль!", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void RegistrationHl_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
            this.Close();
        }
    }
}
