using System;
using System.Collections.Generic;
using System.Data.Common;
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


namespace WpfAppNikiforov
{
    /// <summary>
    /// Логика взаимодействия для StPage.xaml
    /// </summary>
    public partial class StPage : Page
    {
        public StPage()
        {
            InitializeComponent();
        }
   
        private void Sign_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.Prod);
        }
    }
}
