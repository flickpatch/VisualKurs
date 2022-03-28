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
using System.Windows.Shapes;
using VisualKurs.Actions.ImageActivities;
using VisualKurs.Actions.Requests;
using VisualKurs.Entities;

namespace VisualKurs.Windows
{
    /// <summary>
    /// Interaction logic for RegistWindow.xaml
    /// </summary>
    public partial class RegistWindow : Window
    {
        User u = new User();
        public RegistWindow()
        {
            InitializeComponent();
            DataContext = u;
        }
        private static bool IsValidPass(string Fpass, string sPass)
        {
            if (Fpass != sPass)
                return false;
            return true;
        }

        private void btnRegClick(object sender, RoutedEventArgs e)
        {
            if (IsValidPass(tbFirstPass.Text, pbPass.Password.ToString()))
            {
                try
                {
                    UserRequests.RegistrUser(DataContext as User);
                    MessageBox.Show("Вы успешно зарегестрированны!");
                    Close();
                }
                catch
                {
                    MessageBox.Show("Не корректно введены значения.");
                }
            }
            else
            {
                MessageBox.Show("Пароли не совпадают.");
            }       
        }

        private void btnPhotoClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;";
            if (dialog.ShowDialog() == true)
            {
                u.photo = File.ReadAllBytes(dialog.FileName);
                imgPhoto.Source = ImageManager.ImageConvert(u.photo);
            }
        }
    }
}
