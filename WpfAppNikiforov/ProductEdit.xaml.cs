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
    /// Логика взаимодействия для ProductEdit.xaml
    /// </summary>
    public partial class ProductEdit : Page
    {
        dbconn dbconn;
        public ProductEdit(dbconn dbconnection)
        {
            InitializeComponent();
        }

        private void EditProduct(object sender, RoutedEventArgs e)
        {

        }
        private void SelectImageAndAdd(object sender, RoutedEventArgs e)
        {
            Prod prod = ProductBlock.DataContext as Prod;
            if (prod == null)
                return;

            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Файлы изображений|*.jpg;*.jpeg;*.png;";
            fileDialog.Multiselect = false;
            if (fileDialog.ShowDialog() == true)
            {
                Stream fileStream = fileDialog.OpenFile();
                prod.Image = new byte[fileStream.Length];
                fileStream.Read(prod.Image, 0, (int)fileStream.Length);

                fileStream.Seek(0, SeekOrigin.Begin);
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.StreamSource = fileStream;
                bitmap.EndInit();
                ImageBlock.Source = bitmap;
            }
        }
    }

}
