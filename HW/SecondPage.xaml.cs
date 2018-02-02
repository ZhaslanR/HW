using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для SecondPage.xaml
    /// </summary>
    public partial class SecondPage : Page
    {
        private Window window;
        private List<User> users;
        public SecondPage(Window window, List<User> users)
        {
            InitializeComponent();
            this.window = window;
            this.users = users;
        }

        private void BrowseImageButtonClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog browse = new OpenFileDialog();
            browse.Filter = "Картинки(*.PNG)| *.PNG";
            string path = "";
            if (browse.ShowDialog() == true)
            {
                path = browse.FileName;
            }
            if (path == null || path == "")
            {
                return;
            }

            ImageSourceConverter converter = new ImageSourceConverter();
            ImageSource source = (ImageSource)converter.ConvertFromString(path);

            image.Source = source;
        }
        private void RegisterButtonClick(object sender, RoutedEventArgs e)
        {
            if (passwordTextBox.Text != repeatPasswordTextBox.Text)
            {
                MessageBox.Show("Пароли не совпадают");
                return;
            }

            JsonSerializer serializer = new JsonSerializer();

            User user = new User() { Login = loginTextBox.Text, Password = passwordTextBox.Text, Email = emailTextBox.Text, UserImagePath = image.Source.ToString().Remove(0, 8) };

            users.Add(user);

            using (StreamWriter writer = new StreamWriter("Users.txt", false))
            {
                using (JsonWriter jsonWriter = new JsonTextWriter(writer))
                {
                    serializer.Serialize(jsonWriter, users);
                }
            }
            GoBackButtonClick(this, new RoutedEventArgs());
        }
        private void GoBackButtonClick(object sender, RoutedEventArgs e)
        {
            window.Content = new MainPage(window, users);
        }
    }
}
