using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
        User u;
        public RegistWindow(User user)
        {
            InitializeComponent();
            u = user;
            DataContext = u;
            if(user.id != 0)
            {
                TbTitle.Text = "Изменение информации";
                btnReg.Content = "Изменить";
                     
            }
           
        }
        private static bool IsValidPass(string Fpass, string sPass)
        {
            if (Fpass != sPass)
                return false;
            return true;
        }

        private void btnRegClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tbFirstPass.Text != "")
                {

                    if (tbFirstPass.Text == pbPass.Password.ToString())
                    {
                        if (u.id == 0)
                        {
                            if (UserRequests.RegistrUser(DataContext as User) == HttpStatusCode.BadRequest)
                                MessageBox.Show("Некорректно введены данный");
                            else
                            {
                                MessageBox.Show("Complete");
                                Close();
                            }
                        }
                        else
                        {
                            if (UserRequests.ChangeUser(DataContext as User) == HttpStatusCode.BadRequest)
                                MessageBox.Show("Некорректно введены данный");
                            else
                            {
                                MessageBox.Show("Complete");
                                Close();
                            }
                        }
                    }
                    else
                        MessageBox.Show("Пароли не совпадают");
                }
                else
                    MessageBox.Show("Введите пароль");               
            }            
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.UnknownError)
                {
                    MessageBox.Show("Подключение к сети отсутствует или сервер временно не доступен.");
                }
                else
                    MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnPhotoClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.jfif";
            if (dialog.ShowDialog() == true)
            {
                u.photo = File.ReadAllBytes(dialog.FileName);
                imgPhoto.Source = ImageManager.ImageConvert(u.photo);
            }
        }

        private void btnBackCLick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
