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
using System.Windows.Shapes;
using System.Net;
using System.Net.Http;


namespace frontend
{
    /// <summary>
    /// Interaction logic for ConfirmDelete.xaml
    /// </summary>
    public partial class ConfirmDelete : Window
    {
        public ConfirmDelete()
        {
            InitializeComponent();
        }

        private void DeleteAccount(object sender, RoutedEventArgs e)
        {
            try
            {
                // send request to delete https://localhost:7118/api/Clients/deleteById/
                string apiUrl = "https://localhost:7118/api/Clients/deleteById/" + ((MainWindow)Application.Current.MainWindow).UserId;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiUrl);
                request.Method = "DELETE";

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    MessageBox.Show("Account Deleted");
                    ((MainWindow)Application.Current.MainWindow).Logout();
                    ((MainWindow)Application.Current.MainWindow).Navigate("LandingPage");
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
