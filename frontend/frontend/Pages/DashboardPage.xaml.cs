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

namespace frontend
{
    /// <summary>
    /// Interaction logic for DashboardPage.xaml
    /// </summary>
    public partial class DashboardPage : Page
    {
        public DashboardPage()
        {
            InitializeComponent();
            WelcomeLabel.Content = "Welcome, " + ((MainWindow)Application.Current.MainWindow).Username +"!";
            BalanceLabel.Content = "Balance: " + ((MainWindow)Application.Current.MainWindow).ClientBalance.ToString();
            ExpenseLabel.Content = "Spent: " + ((MainWindow)Application.Current.MainWindow).ClientExpense.ToString();
        }

        
    }
}
