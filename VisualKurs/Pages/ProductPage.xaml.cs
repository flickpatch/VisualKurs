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
using VisualKurs.Actions.Requests.ProductRequests;

namespace VisualKurs.Pages
{
    /// <summary>
    /// Interaction logic for ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        public ProductPage()
        {
            InitializeComponent();
            lvProducts.ItemsSource = ProductRequest.getProducts();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ClickAddProduct(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
