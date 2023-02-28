using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
    public class SortItem
    {
        public string Name { get; set; }
        public SortDescription sort { get; set; }
    }

    public partial class ProductList : Page
    {
        dbconn dbconn;
        public List<SortItem> SortLists { get; set; }
        public SortItem SelectedSortItem { get; set; }

        public ProductList(dbconn dbconnection)
        {
            InitializeComponent();
            this.dbconn = dbconnection;
            Binding binding = new Binding();
            binding.Source = dbconn.Prod.ToList();
            ProductView.SetBinding(ItemsControl.ItemsSourceProperty, binding);

            SortLists = new List<SortItem>()
            {
                new SortItem()
                {
                    Name = "по возрастанию(цена)",
                    sort = new SortDescription("Price",ListSortDirection.Ascending)
                },
                new SortItem()
                {
                    Name = "по убыванию(цена)",
                    sort = new SortDescription("Price", ListSortDirection.Descending)
                },
                 new SortItem()
                {
                    Name = "по возрастанию(количество)",
                    sort = new SortDescription("Count", ListSortDirection.Ascending)
                },
                  new SortItem()
                {
                    Name = "по возрастанию(количество)",
                    sort = new SortDescription("Count", ListSortDirection.Descending)
                }
            };
         

            DataContext = this;
        }
        private void ApplySort()
        {
            var view = CollectionViewSource.GetDefaultView(ProductView.ItemsSource);
            if (view == null || SelectedSortItem == null) return;
            view.SortDescriptions.Clear();
            view.SortDescriptions.Add(SelectedSortItem.sort);

        }

        private void Find(string search)
        {
            search = search.Trim().ToLower();

            var view = CollectionViewSource.GetDefaultView(ProductView.ItemsSource);
            if (view == null) return;

            if (search.Length == 0)
            {
                view.Filter = null;
            }
            else
            {
                view.Filter = new Predicate<object>((object o) =>
                {
                    Prod prod = o as Prod;
                    if (prod == null)
                        return false;
                    return prod.Name.ToLower().IndexOf(search) != -1;
                });
            }
        }
    
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplySort();
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        public ProductList()
        {
            InitializeComponent();
        }

        private void TextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

     private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                Find(textBox.Text);
            }
        }
        
}

