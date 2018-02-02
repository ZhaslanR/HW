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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
        private List<User> users;
        public MainWindow()
        {
            InitializeComponent();
            JsonSerializer serializer = new JsonSerializer();
            using (StreamReader reader = new StreamReader("Users.txt"))
            {
                using (JsonTextReader jsonReader = new JsonTextReader(reader))
                {
                    users = serializer.Deserialize<List<User>>(jsonReader);
                }
            }
            if (users == null) users = new List<User>();
            mainWindow.Content = new MainPage(this, users);
        }
    }
}
