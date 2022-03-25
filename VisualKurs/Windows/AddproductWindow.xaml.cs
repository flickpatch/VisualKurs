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
using VisualKurs.Entities;

namespace VisualKurs.Windows
{
    /// <summary>
    /// Interaction logic for AddproductWindow.xaml
    /// </summary>
    public partial class AddproductWindow : Window 
    {
        Product product = new Product();
        public AddproductWindow()
        {
            var typesTovar = new List<string>
            {
                "Авто", "Услуги", "Игрушки", "Свое", "Прикольная тема", "Кончилась фантазия", "Гена", "Вася", "Вася+Гена", "АХАахафаахХах", "Не могу", "ЫЫЫЫ", "выфв", "Васпомнил", "Запчасти", "Питание", "Одежда",
            };
            InitializeComponent();
            cbType.ItemsSource = typesTovar;
            DataContext =product;
            lvPhotos.ItemsSource = product.photos;
        }

        private void clickAddProduct(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddphotoclick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png; ";
            if (dialog.ShowDialog() == true)
            {
                product.photos.Add(new Photo()
                {
                    image = File.ReadAllBytes(dialog.FileName),
                     productId = product.id                     
                }) ;
                
            }    
        }
    }
}
