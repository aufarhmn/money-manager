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

        //Attributes
        private string username;
        private int clientBalance;
        private int clientExpense;


        //Encapsulation
        public string Username
        {
            get { return username; }
            set { username = value; }
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
                MessageBox.Show("Please authenticate yourself.");
            }
        }
    }
}
