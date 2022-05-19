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
using VisualKurs.Actions.Requests;
using VisualKurs.Entities;
using VisualKurs.Windows;

namespace VisualKurs.Pages
{
    /// <summary>
    /// Логика взаимодействия для UserPageInfo.xaml
    /// </summary>
    public partial class UserPageInfo : Page
    {
        int id;
        public UserPageInfo(int userid)
        {
            id = userid;
            InitializeComponent();
            User u = UserRequests.GetUserByProduct(userid);
            DataContext = u;
            if (AutorizeUser.user.id != userid)
            {
                btnLogOut.Visibility = Visibility.Hidden;
                btnChange.Visibility = Visibility.Hidden;
            }
        }

        private void btnChangeClick(object sender, RoutedEventArgs e)
        {
            User thisUser = DataContext as User;
            new RegistWindow(thisUser).ShowDialog();
            User u = UserRequests.GetUserByProduct(id);
            DataContext = u;

        }

        private void btnBackClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnLogOutClick(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Точно выйти?", "Внимание!", MessageBoxButton.OKCancel);
                  if (result == MessageBoxResult.OK)
            {
                NavigationService.Navigate(new AuthPage());
            }
                
        }
    }
}
