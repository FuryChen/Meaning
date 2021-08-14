using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace VirusKiller
{
    public static class ImageConverter
    {
        public static MemoryStream ToMemoryStream(Image img)
        {
            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms;
        }


        public static BitmapImage ToBitmapImage(Image img)
        {
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = ToMemoryStream(img);
            bitmapImage.EndInit();

            return bitmapImage;
        }

        public static ImageBrush ToImageBrush(Image img)
        {
            return new ImageBrush(ToBitmapImage(img));
        }
    }
}
