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
using VisualKurs.Actions.Info;
using VisualKurs.Actions.Requests.ProductRequests;
using VisualKurs.Entities;
using VisualKurs.Windows;

namespace VisualKurs.Pages
{
    /// <summary>
    /// Interaction logic for ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        private bool isyourproduct=false;
        List<Product> products = new List<Product>(); Color c = new Color();

        public ProductPage()
        {
            InitializeComponent(); 
            Update();
            c.R = 221; c.G = 221; c.B = 221;
            btnYourProduct.Background = new SolidColorBrush(c);
        }

    

        private void ClickAddProduct(object sender, RoutedEventArgs e)
        {
            new AddproductWindow().ShowDialog(); Color c = new Color(); c.R = 221; c.G = 221; c.B = 221;
            btnYourProduct.Background = new SolidColorBrush(c);
            Update();
        }
        private void Update()
        {

            products = ProductRequest.getProducts();
            lvProducts.ItemsSource = products;

        }

        private void btnInfoClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProductInfoPage(lvProducts.SelectedItem as Product));

        }

        private void clickYoursProducts(object sender, RoutedEventArgs e)
        {
           

            if (isyourproduct)
            {
                Update();              
            }
            else
            {
                products = ProductRequest.getYourProducts(AutorizeUser.user.id);
                lvProducts.ItemsSource = products;
            }
            if (isyourproduct)
            {
                Color c = new Color();
                isyourproduct = false; ;
                c.R = 221; c.G = 221; c.B = 221;
                btnYourProduct.Background = new SolidColorBrush(c);
            }
            else
            {
                
                isyourproduct = true;
                btnYourProduct.Background = Brushes.GreenYellow;
            }
        }

        private void clickLikedProducts(object sender, RoutedEventArgs e)
        {

        }

        private void SearchChange(object sender, TextChangedEventArgs e)
        {
            if (tbSearch.Text != "")
            {
                products = ProductRequest.GetProductsBySearxh(tbSearch.Text.ToString()); lvProducts.ItemsSource = products;
                if (products == null)
                {
                    MessageBox.Show("По вашему запросу ничего не найдено!");
                }
             
            }
            else
                Update();
        }
    }
}
