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

        private void Login(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            if (username != "" && password != "")
            {
                var mainWindow = (MainWindow)Application.Current.MainWindow;
                mainWindow.Username = username;
                MessageBox.Show("Login Success, Welcome " + username);
                mainWindow.Navigate("DashboardPage");
                
            }
            else
            {
                MessageBox.Show("Please fill all the forms.");
            }
            
        }
    }
}
