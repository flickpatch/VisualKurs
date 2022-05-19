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
using VisualKurs.Actions.Info;
using VisualKurs.Actions.Requests.ProductRequests;
using VisualKurs.Entities;

namespace VisualKurs.Windows
{
    /// <summary>
    /// Interaction logic for AddproductWindow.xaml
    /// </summary>
    public partial class AddproductWindow : Window 
    {
        Product product = new Product()
        {
           
        }
        ;
        public AddproductWindow()
        {
            var typesTovar = new List<string>
            {
                "Авто", "Услуги", "Игрушки", "Свое", "Прикольная тема",  "Запчасти", "Питание", "Одежда",
            };
            InitializeComponent();
            cbType.ItemsSource = typesTovar;
            DataContext =product;
          
        }

        private void clickAddProduct(object sender, RoutedEventArgs e)
        {
            product = DataContext as Product;
            try
            {
                ProductRequest.AddProduct(product);
                MessageBox.Show("Добавление прошло усешно.");
                Close();
            }
            catch
            {
                MessageBox.Show("Не корректно введены значчения или имеются пустые поля.");
            }


        }

        private void btnAddphotoclick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.jfif";
            if (dialog.ShowDialog() == true)
            {
                product.photo = File.ReadAllBytes(dialog.FileName);
                imgPhoto.Source = ImageManager.ImageConvert(product.photo);
                
            }    
        }
    }
}
