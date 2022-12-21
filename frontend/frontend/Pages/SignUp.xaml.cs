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
            private string clientName;
            private string clientPass;
            private string clientBalance;
            private string clientExpense;

            // Encapsulation
            public int Id { get => id; set => id = value; }
            public string ClientName { get => clientName; set => clientName = value; }
            public string ClientPass { get => clientPass; set => clientPass = value; }
            public string ClientBalance { get => clientBalance; set => clientBalance = value; }
            public string ClientExpense { get => clientExpense; set => clientExpense = value; }

            //Constructor
            public User() { }
        }

        //public void RegisterNewUser()
        //{
        //    User newUser = new User();
        //    newUser.Id = Convert.ToInt32(DateTime.Now);
        //    newUser.ClientName = UsernameTextBox.Text;
        //    newUser.ClientPass = PasswordBox.Password;
        //    newUser.ClientBalance = 0.ToString();
        //    newUser.ClientExpense = 0.ToString();
        //
        //    string userJson = JsonConvert.SerializeObject(newUser, Formatting.Indented);
        //}

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
                        clientName = $"{UsernameTextBox.Text}",
                        clientPass = $"{PasswordBox.Password}"
                    });

                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    //TODO: FIX ME TO HANDLE IF FORM ISNT FILLED PROPERLY
                    if (result != null)
                    {
                        MessageBox.Show("Registration Succses, Please Login");
                        var mainWindow = (MainWindow)Application.Current.MainWindow;
                        mainWindow.Navigate("LoginPage");
                    }
                }
            }
            catch (Exception ex)
            {
                if(ex.Message.Contains("500"))
                {
                    MessageBox.Show("There are problems in the server");
                }
                else
                {
                    MessageBox.Show("Something went wrong");
                }
            }

        }
    }
}
