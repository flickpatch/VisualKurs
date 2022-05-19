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
using VisualKurs.Actions.Requests;
using VisualKurs.Entities;

namespace VisualKurs.Pages
{
    /// <summary>
    /// Interaction logic for ProductInfoPage.xaml
    /// </summary>
    public partial class ProductInfoPage : Page
    {
        
        Product product;
        public ProductInfoPage(Product p)
        {
            InitializeComponent();
            DataContext = p;
            product = p;
            if(isLiked())
            {
                btnLike.Background = Brushes.Red;
            }
        }
        private bool isLiked()
        {
           return UserRequests.IsLikedProduct(product.id);
        }
        private void btnbackclick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void LikeProduct(object sender, RoutedEventArgs e)
        {
            if (!isLiked())
            {
                UserRequests.Like((DataContext as Product).id);
                MessageBox.Show("Понравилось( ͡ᵔ ͜ʖ ͡ᵔ )");
                btnLike.Background = Brushes.Red;
            }
            else
            {
                UserRequests.DeleteLike((DataContext as Product).id); 
                btnLike.Background = Brushes.White;
            }
        }

        private void btnContectWithUserClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserPageInfo(product.userId));
        }
    }
}
