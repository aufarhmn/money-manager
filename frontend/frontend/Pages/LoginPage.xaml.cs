using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace frontend.Pages
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        public class Response
        {
            public int id;
            public string username;
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            if (username != "" && password != "")
            {
                var mainWindow = (MainWindow)Application.Current.MainWindow;
                //MessageBox.Show("Login Success, Welcome " + username);
                
                mainWindow.Navigate("DashboardPage");
                var response = new WebClient().DownloadString("https://localhost:7118/api/Clients/2");
                JObject response2 = JObject.Parse(response);
                var clientName = response2["clientName"].ToString();
                //string[] array = JsonConvert.DeserializeObject<string[]>(response);
                Trace.WriteLine(clientName);
                mainWindow.Username = clientName;


            }
            else
            {
                MessageBox.Show("Please fill all the forms.");
            }


            
        }
    }
}
