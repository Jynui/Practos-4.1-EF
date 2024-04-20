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

namespace Practos_4._11
{
    
    public partial class MainWindow : Window
    {
        private yandex_storeEntities DataBaze = new yandex_storeEntities();
        public MainWindow()
        {
            InitializeComponent();
            holo1.ItemsSource = DataBaze.Order_Products.ToList();
            FF.ItemsSource = DataBaze.Products.ToList();
            FF.DisplayMemberPath = "product_name";
        }
     
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            holo1.ItemsSource = DataBaze.Products.ToList().Where(items => items.product_name.Contains(Txt.Text));
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            holo1.ItemsSource = DataBaze.Order_Products.ToList();
            FF.SelectedItem = null;

        }

        private void FF_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FF.SelectedItem != null) 
            {
                var choice = FF.SelectedItem as Products;
                holo1.ItemsSource = DataBaze.Order_Products.ToList().Where(item => item.products_id == choice.product_id);
            }

        }
    }
}
