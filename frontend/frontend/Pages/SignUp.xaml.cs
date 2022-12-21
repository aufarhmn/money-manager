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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

        public void RegisterNewUser()
        {
            User newUser = new User();
            newUser.Id = Convert.ToInt32(DateTime.Now);
            newUser.ClientName = UsernameTextBox.Text;
            newUser.ClientPass = PasswordBox.Password;
            newUser.ClientBalance = 0.ToString();
            newUser.ClientExpense = 0.ToString();

            string userJson = JsonConvert.SerializeObject(newUser, Formatting.Indented);





        }
    }
}
