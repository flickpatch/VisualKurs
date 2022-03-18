  using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace VisualKurs.Actions.ImageActivities
{
    public class ImageManager
    {
        public static BitmapImage ImageConvert(byte[] array)
        {
            using(var i = new MemoryStream(array))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = i;
                image.EndInit();
                return image;
            }
        }
    }
}
