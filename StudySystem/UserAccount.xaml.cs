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

namespace StudySystem
{
    /// <summary>
    /// Логика взаимодействия для UserAccount.xaml
    /// </summary>
    public partial class UserAccount : Window
    {
        public UserAccount()
        {
            InitializeComponent();
        }
        private void ButtonExit(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            Hide();
        }
        private void ButtonMyProgress(object sender, RoutedEventArgs e)
        {
        }
        private void ButtonCreateCourse(object sender, RoutedEventArgs e)
        {
        }
        private void ButtonCourses(object sender, RoutedEventArgs e)
        {
        }
    }
}
