﻿using System;
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
                string url = $"https://localhost:7118/api/Clients/getByName/{username}";
                var response = new WebClient().DownloadString(url);
                JObject response2 = JObject.Parse(response);

                if(response2 == null)
                {
                    MessageBox.Show("Username does not exist.");
                }
                else
                {
                    var mainWindow = (MainWindow)Application.Current.MainWindow;
                    MessageBox.Show("Login Success, Welcome " + username);

                    mainWindow.Navigate("DashboardPage");
                    var clientName = response2["clientName"].ToString();
                    var clientBalance = response2["clientBalance"].ToString();
                    var clientExpense = response2["clientExpense"].ToString();
                    Trace.WriteLine(clientName);
                    mainWindow.Username = clientName;
                    mainWindow.ClientBalance = Convert.ToInt32(clientBalance);
                    mainWindow.ClientExpense = Convert.ToInt32(clientExpense);
                }
            }
            else
            {
                MessageBox.Show("Please fill all the forms.");
            }


            
        }
    }
}
