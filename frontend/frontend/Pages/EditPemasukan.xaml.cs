using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
using Newtonsoft.Json;
using System.Collections.Specialized;
using Newtonsoft.Json.Linq;
using static System.Net.WebRequestMethods;
using Nancy.Json;
using System.IO;

namespace frontend.Pages
{
    /// <summary>
    /// Interaction logic for EditPemasukan.xaml
    /// </summary>
    public partial class EditPemasukan : Page
    {
        //Attributes
        private int userBalance;
        private int userId;

        public EditPemasukan()
        {
            InitializeComponent();
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            //MessageBox.Show(mainWindow.UserId.ToString());
            userBalance = mainWindow.ClientBalance;
            userId = mainWindow.UserId;
            SetBalanceTextBox.Text = userBalance.ToString();
        }

        private void EditBalance(object sender, RoutedEventArgs e)
        { 
            try
            {
                //NaN protection
                if (!int.TryParse(SetBalanceTextBox.Text, out int value) || Convert.ToInt32(SetBalanceTextBox.Text) < 0)
                {
                    throw new Exception("Enter a valid number.");
                }

                userBalance = Convert.ToInt32(SetBalanceTextBox.Text);

                string apiUrl = $"https://localhost:7118/api/Clients/putById/{userId}";

                // Create a new HttpWebRequest object
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiUrl);

                // Set the method to PUT
                request.Method = "PUT";

                // Set the content type to application/json
                request.ContentType = "application/json";

                // Set the content of the request to a JSON object
                int clientBalance = userBalance;
                string json = "{\"clientBalance\":\"" + clientBalance + "\"}";
                byte[] jsonBytes = Encoding.UTF8.GetBytes(json);

                // Write the content of the request to the request stream
                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(jsonBytes, 0, jsonBytes.Length);
                }

                MessageBox.Show(json);

                //Send the PUT request to the API and get the response
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    // Read the response as a string
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        string responseString = reader.ReadToEnd();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }
    }
}
