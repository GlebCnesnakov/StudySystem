using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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

namespace StudySystem
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationContext db;
        public MainWindow()
        {
            InitializeComponent();
            db = new ApplicationContext();
        }

        private void ButtonAuth(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            this.Hide();
        }

        private void ButtonRegistration(object sender, RoutedEventArgs e)
        {
            List<User> users = db.Users.ToList();
            int i = 0;
            string login = textBoxLogin.Text.Trim();
            string password = textBoxPassword.Password.Trim();
            string password2 = textBoxSecondPassword.Password.Trim();
            foreach(User user in users)
            {
                if(user.Login == login || String.IsNullOrEmpty(login))
                {
                    textBoxLogin.ToolTip = "Пользователь уже зарегистрирован или логин не введён";
                    textBoxLogin.Background = Brushes.OrangeRed;
                    return;
                }
            }
            if (login.Length < 3 || String.IsNullOrEmpty(login))
            {
                textBoxLogin.ToolTip = "Логин содержит менее трёх символов или поле не заполнено";
                textBoxLogin.Background = Brushes.OrangeRed;
            }
            else
            {
                i++;
                textBoxLogin.Background = Brushes.Transparent;
                textBoxLogin.ToolTip = "";
            }
            if (password.Length < 5 || String.IsNullOrEmpty(password))
            {
                textBoxPassword.ToolTip = "Пароль должен содержать более 4 символов";
                textBoxPassword.Background = Brushes.OrangeRed;
            }
            else
            {
                i++;
                textBoxPassword.Background = Brushes.Transparent;
                textBoxPassword.ToolTip = "";
            }
            if (password2 != password || password2.Length < 5 || String.IsNullOrEmpty(password2))
            {
                textBoxSecondPassword.ToolTip = "Пароли не совпадают";
                textBoxSecondPassword.Background = Brushes.OrangeRed;
            }
            else
            {
                i++;
                textBoxSecondPassword.Background = Brushes.Transparent;
                textBoxSecondPassword.ToolTip = "";
            }
            if (i == 3)
            {
                textBoxLogin.Background = Brushes.Transparent;
                textBoxLogin.ToolTip = "";
                textBoxLogin.Text = "";
                textBoxPassword.Background = Brushes.Transparent;
                textBoxPassword.ToolTip = "";
                textBoxPassword.Password = "";
                textBoxSecondPassword.Background = Brushes.Transparent;
                textBoxSecondPassword.ToolTip = "";
                textBoxSecondPassword.Password = "";
                DataAdd(login, password);
            }
        }
        private void DataAdd(string login, string password)
        {
            User user = new User(login, password);
            db.Users.Add(user);
            db.SaveChanges();
            MessageBox.Show("Регистрация прошла успешно");
            UserAccount someWindow = new UserAccount();
            someWindow.Show();
            this.Hide();
        }
    }
}
