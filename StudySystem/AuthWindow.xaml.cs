using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace StudySystem
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }
        private void ButtonRegistration(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }
        private void ButtonAuth(object sender, RoutedEventArgs e)
        {
            int i = 0;
            string login = textBoxLogin.Text.Trim();
            if (login.Length < 3)
            {
                textBoxLogin.ToolTip = "Логин содержит меньше трёх символов или поле не заполнено!";
                textBoxLogin.Background = Brushes.OrangeRed;
            }
            else
            {
                i++;
                textBoxLogin.Background = Brushes.Transparent;
                textBoxLogin.ToolTip = "";
            }
            string password = textBoxPassword.Password.Trim();
            if (password.Length < 5)
            {
                textBoxPassword.ToolTip = "Пароль должен содержать более 4 символов!";
                textBoxPassword.Background = Brushes.OrangeRed;
            }
            else
            {
                i++;
                textBoxPassword.Background = Brushes.Transparent;
                textBoxPassword.ToolTip = "";
            }
            if(i == 2)
            {
                textBoxLogin.Background = Brushes.Transparent;
                textBoxLogin.ToolTip = "";
                textBoxLogin.Text = "";
                textBoxPassword.Background = Brushes.Transparent;
                textBoxPassword.ToolTip = "";
                textBoxPassword.Password = "";
                User authUser = null;
                using (ApplicationContext db = new ApplicationContext())
                {
                    //аутентификация LINQ
                    authUser = db.Users.Where(b => b.Login == login && b.Password == password).FirstOrDefault();
                }
                if (authUser != null)
                {
                    UserAccount someWindow = new UserAccount();
                    someWindow.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль!");
                }
            }
        }
    }
}
