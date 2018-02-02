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

namespace HW
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        List<User> users;
        private Window window;
        public MainPage(Window mainWindow, List<User> users)
        {
            window = mainWindow;
            InitializeComponent();
            this.users = users;
        }

        private void SignUpButtonClick(object sender, RoutedEventArgs e)
        {
            window.Content = new SecondPage(window, users);
        }

        private void LogInButtonClick(object sender, RoutedEventArgs e)
        {
            bool finded = false;
            foreach (var user in users)
            {
                if (user.Password == passwordTextBox.Text && user.Login == loginTextBox.Text)
                {
                    finded = true;
                    window.Content = new ThirdPage(window, users, user);
                }
            }
            if (!finded)
                MessageBox.Show("Неправильно введенный логин либо пароль");
        }
    }
}
