using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
using TransactionValidation;

namespace frontend
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // set loginpage uri
            navframe.Navigate(new Uri("Pages/LandingPage.xaml", UriKind.Relative));
        }

        public class Log
        {
            //Constructor
            public Log() { }

            //Attributes
            private string title;
            private int amount;

            //Encapsulation
            [JsonProperty("title")]
            public string Title { get => title; set => title = value; }
            [JsonProperty("amount")]
            public int Amount { get => amount; set => amount = value; }


        }

        //Attributes
        private string? username;
        private string? password;
        private int userId;
        private int clientBalance;
        private int clientExpense;
        public List<Log> clientLog = new List<Log>();


        //Encapsulation
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        public int ClientBalance
        {
            get { return clientBalance; }
            set { clientBalance = value; }
        }
        public int ClientExpense
        {
            get { return clientExpense; }
            set { clientExpense = value; }
        }

        private void NavButton_Selected(object sender, RoutedEventArgs e)
        {
            
        }

        //Navigations

        public void Navigate(string page)
        {
            Uri pageUri = new Uri("/Pages/" + page + ".xaml", UriKind.Relative);
            navframe.Navigate(pageUri);
        }

        private void sidebar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = sidebar.SelectedItem as NavButton;

            // Navigation auth protection
            if(this.Username != null)
            {
                navframe.Navigate(selected.NavLink);
            }
            else
            {
                MessageBox.Show("Please login first.");
            }
        }

        private void NavigateToHome(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            if(mainWindow.Username == null)
            {
                mainWindow.Navigate("LandingPage");
            }
            else
            {
                mainWindow.Navigate("DashboardPage");
            }
        }

        private void ConfirmDeletePopUp(object sender, RoutedEventArgs e)
        {
            ConfirmDelete popupWindow = new ConfirmDelete();
            popupWindow.Show();
        }
        public void Logout()
        {
            Username = null;
            Password = null;
            UserId = 0;
            ClientBalance = 0;
            ClientExpense = 0;
            clientLog.Clear();
        }
    }
}
