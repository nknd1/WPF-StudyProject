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

namespace WpfAppNikiforov
{
    /// <summary>
    /// Логика взаимодействия для CatPage.xaml
    /// </summary>
    public partial class CatPage : Page
    {
        dbconn dbconn;

        public CatPage(dbconn dbconnection)
        {
            InitializeComponent();
            dbconn dbcon;
            cat1 = new cat1();
            dbcon = new dbconn();
            this.dbconn = dbconn;
        }

             public Prod Prod { get; set; }
             public cat1 cat1 { get; set; }
            
        private void BtnSaveClick_AddCat(object sender, RoutedEventArgs e)
        {
            string categoryName = tbProd.Text.Trim();
            List<cat1> category = dbconn.cat1.ToList();


           for (int i = 0; i < category.Count; i++)
           {
                if (category[i].name.ToLower() == categoryName.ToLower())
                {
                    MessageBox.Show("Данная категория уже есть");
                    return;

                }
            }

            cat1 cat1 = new cat1();

            cat1.name = categoryName;
            dbconn.cat1.Add(cat1);
            dbconn.SaveChanges();
            MessageBox.Show("Категория сохранена");
            tbProd.Text = "";
        }

        private void BackToProdPage_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.Prod);
        }
    }

   
}
