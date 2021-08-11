using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using System.Text;

namespace KeyMouseControl
{
    public class Screen
    {

        public static Image CaptureScreen()
        {
            Size s = new Size(100, 100);
            Bitmap memoryImage = new Bitmap(s.Width, s.Height, PixelFormat.Format32bppArgb);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            memoryGraphics.CopyFromScreen(0, 0, 0, 0, s);

            return memoryImage;

            //memoryImage.Save(@"C:\Users\DELL\Desktop\123.png", ImageFormat.Png);
        }
    }
}


