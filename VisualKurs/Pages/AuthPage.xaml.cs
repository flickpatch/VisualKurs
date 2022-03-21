using System;
using System.Collections.Generic;
using System.Drawing;
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
using VisualKurs.Actions.Requests;
using VisualKurs.Windows;

namespace VisualKurs.Pages
{
    /// <summary>
    /// Interaction logic for AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private void btnRefistClick(object sender, RoutedEventArgs e)
        {

            if (AutorizeUser.AutorizatingUser(pbPass.Password.ToString(), tbLogin.Text))
            {
                NavigationService.Navigate(new ProductPage());
            }
            else
            {
                tblAuthInfo.Visibility = Visibility.Visible;
            }
              
            
         
                
        }

        private void btnAuthClick(object sender, RoutedEventArgs e)
        {
            new RegistWindow().ShowDialog();
        }
    }
}
