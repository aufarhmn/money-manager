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
    /// Interaction logic for LogsPage.xaml
    /// </summary>
    public partial class LogsPage : Page
    {
        public LogsPage()
        {
            InitializeComponent();
            var mainWindow = ((MainWindow)Application.Current.MainWindow);
            string logsMapping = "";
            foreach (var log in mainWindow.clientLog)
            {
                logsMapping += "> " + log.Title + ", amount: " + log.Amount + "\n";
            }
            LogsMap.Text = logsMapping;
        }

        private void NavigateToAddLog(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).Navigate("CreatePage");
        }
    }
}
