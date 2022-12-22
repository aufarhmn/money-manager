using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.IO;
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
using Newtonsoft.Json;
using System.Collections.Specialized;
using Newtonsoft.Json.Linq;
using static System.Net.WebRequestMethods;
using System.Diagnostics;
using System.Text.Json;
using Nancy.Json;

namespace frontend.Pages
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Page
    {
        public SignUp()
        {
            InitializeComponent();
        }

        public class User
        {
            // Attributes
            private int id;
            private string? clientName;
            private string? clientPass;
            private string? clientBalance;
            private string? clientExpense;

            // Encapsulation
            public int Id { get => id; set => id = value; }
            public string ClientName { get => clientName; set => clientName = value; }
            public string ClientPass { get => clientPass; set => clientPass = value; }
            public string ClientBalance { get => clientBalance; set => clientBalance = value; }
            public string ClientExpense { get => clientExpense; set => clientExpense = value; }

            //Constructor
            public User() { }
        }


        private void Sign_Up(object sender, RoutedEventArgs e)
        {
            User newUser = new User();
            newUser.ClientName = UsernameTextBox.Text;
            newUser.ClientPass = PasswordBox.Password;

            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://localhost:7118/api/Clients/postAll");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        clientName = $"{newUser.ClientName}",
                        clientPass = $"{newUser.ClientPass}",
                        clientBalance = 0,
                        clientExpense = 0,
                        clientLog = "[]"
                    });

                    streamWriter.Write(json);
                }

                // Check for duplicate usernames
                var reqAllUsers = (HttpWebRequest)WebRequest.Create("https://localhost:7118/api/Clients/getAll");


                using (var streamReader = new StreamReader(reqAllUsers.GetResponse().GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    var users = JsonConvert.DeserializeObject<List<User>>(result);

                    foreach (var user in users)
                    {
                        if (user.ClientName == newUser.ClientName)
                        {
                            throw new Exception("username already exist.");
                        }
                    }
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    //TODO: FIX ME TO HANDLE IF FORM ISNT FILLED PROPERLY
                    if (result != null)
                    {
                        MessageBox.Show("Registration Success, Please Login");
                        var mainWindow = (MainWindow)Application.Current.MainWindow;
                        mainWindow.Navigate("LoginPage");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
