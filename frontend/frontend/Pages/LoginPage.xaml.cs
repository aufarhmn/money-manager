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
using System.CodeDom;
using Nancy.Json;
using TransactionValidation;

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
                try
                {
                    var response = new WebClient().DownloadString(url);
                    JObject response2 = JObject.Parse(response);

                    if (response2["clientPass"].ToString() != password)
                    {
                        throw new Exception("Wrong password");
                    }
                    
                    var mainWindow = (MainWindow)Application.Current.MainWindow;
                    MessageBox.Show("Login Success, Welcome " + username);

                    mainWindow.Navigate("DashboardPage");
                    var clientName = response2["clientName"].ToString();
                    var clientId = Convert.ToInt32(response2["id"]);
                    var clientPass = response2["clientPass"].ToString();
                    var clientBalance = response2["clientBalance"].ToString();
                    var clientExpense = response2["clientExpense"].ToString();
                    mainWindow.Username = clientName;
                    mainWindow.UserId = clientId;
                    mainWindow.Password = clientPass;
                    mainWindow.ClientBalance = Convert.ToInt32(clientBalance);
                    mainWindow.ClientExpense = Convert.ToInt32(clientExpense);
                    var list = JsonConvert.DeserializeObject<List<MainWindow.Log>>(response2["clientLog"].ToString());
                    //Store each log in a mainWindow.clientLog
                    foreach (var log in list)
                    {
                        mainWindow.clientLog.Add(log);
                    }
                    Transaction transactionValidate = new Transaction();
                    if (!transactionValidate.cekPemasukanNegatif(Convert.ToDouble(clientBalance)))
                    {
                        MessageBox.Show("Warning: Balance anda bernilai negatif, perbaiki segera");
                    }
                    if (!transactionValidate.cekPengeluaranNegatif(Convert.ToDouble(clientBalance)))
                    {
                        MessageBox.Show("Warning: Pengeluaran anda bernilai negatif, perbaiki segera");
                    }
                    if (!transactionValidate.cekPengeluaranLebihBesarPemasukan(Convert.ToDouble(clientBalance), Convert.ToDouble(clientExpense)))
                    {
                        MessageBox.Show("Warning: Balance anda lebih kecil dari pengeluaran anda");
                    }

                }
                catch (Exception ex)
                {
                    if(ex.Message.Contains("404"))
                    {
                        MessageBox.Show("Username does not exist.");
                    } else if(ex.Message.Contains("500"))
                    {
                        MessageBox.Show("Internal Server Error");
                    } else
                    {
                        MessageBox.Show(ex.Message);
                    }
                    
                }
            }
            else
            {
                MessageBox.Show("Please fill all the forms.");
            }


            
        }
    }
}
