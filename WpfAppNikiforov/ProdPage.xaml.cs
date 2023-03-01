using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для ProdPage.xaml
    /// </summary>
    public partial class ProdPage : Page
    {
        dbconn dbconn;

        public cat1 cat1 { get; set; }


        public ProdPage(dbconn dbconnection)
        {
            InitializeComponent();
            cat1 = new cat1();
            dbconn = dbconnection;

            DataContext = this;
            ProductBlock.DataContext = new Prod();

            Binding binding = new Binding();
            binding.Source = dbconn.cat1.ToList();
            cbCategory.DisplayMemberPath = "name";
            cbCategory.SetBinding(ComboBox.ItemsSourceProperty, binding);
        }

        private void BtnSaveClick_AddProd(object sender, RoutedEventArgs e)
        {
            Prod prod = ProductBlock.DataContext as Prod;

            prod.Name = tbCategoryName.Text.Trim();
            prod.Size = tbSize.Text.Trim();

            if (prod.Name.Length == 0)
            {
                MessageBox.Show("Введите наименование товара");
                return;
            }

            if (cbCategory.SelectedItem == null)
            {
                MessageBox.Show("Категория не выбрана");
                return;
            }

            dbconn.Prod.Add(prod);
            dbconn.SaveChanges();
            MessageBox.Show("Товар сохранен");
            ProductBlock.DataContext = new Prod();
        }

        public ProdPage()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
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

        private void InputCat_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.Cat);
        }

        private void ImageBlock_SourceUpdated(object sender, DataTransferEventArgs e)
        {

        }



        private void MoveLastView(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.List);
        }

        private void EditProducts(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.Edit);
        }
    }
}