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

namespace VisualKurs.Pages
{
    /// <summary>
    /// Interaction logic for ProductInfoPage.xaml
    /// </summary>
    public partial class ProductInfoPage : Page
    {
        public ProductInfoPage()
        {
            InitializeComponent();
        }

        private void btnbackclick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void LikeProduct(object sender, RoutedEventArgs e)
        {

        }
    }
}
