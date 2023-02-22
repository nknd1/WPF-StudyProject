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
                    Name = "Цена",
                    sort = new SortDescription("по возрастанию (цена)", ListSortDirection.Ascending)
                }
            };
            SortLists = new List<SortItem>()
            {
                new SortItem()
                {
                    Name = "Цена",
                    sort = new SortDescription("по убыванию(цена)", ListSortDirection.Descending)
                }
            };
            SortLists = new List<SortItem>()
            {
                new SortItem()
                {
                    Name = "Количество",
                    sort = new SortDescription("по возрастанию(количество)", ListSortDirection.Ascending)
                }
            };
            SortLists = new List<SortItem>()
            {
                new SortItem()
                {
                    Name = "Количество",
                    sort = new SortDescription("по возрастанию(количество)", ListSortDirection.Descending)
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
        public ProductList()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplySort();
        }
    }
}