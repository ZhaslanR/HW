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
    /// Логика взаимодействия для ThirdPage.xaml
    /// </summary>
    public partial class ThirdPage : Page
    {
        private Window window;
        private List<User> users;
        private User user;

        public ThirdPage(Window window, List<User> users, User user)
        {
            InitializeComponent();
            this.window = window;
            this.users = users;
            this.user = user;

            textBlock.Text = "Hello " + user.Login;

            ImageSourceConverter converter = new ImageSourceConverter();
            ImageSource source = (ImageSource)converter.ConvertFromString(user.UserImagePath);

            image.Source = source;
        }

        private void GoBackButtonClick(object sender, RoutedEventArgs e)
        {
            window.Content = new MainPage(window, users);
        }
    }
}
