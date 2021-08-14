using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using System.Text;
using MetaData;

namespace KeyMouseControl
{
    public class Screen
    {

        public static Image CaptureScreen(RegionSquare region)
        {
            if (region == null)
                throw new Exception("截图选取不可为空");

            Bitmap memoryImage = new Bitmap(region.Size.Width, region.Size.Height, PixelFormat.Format32bppArgb);
            using (Graphics memoryGraphics = Graphics.FromImage(memoryImage))
            {
                memoryGraphics.CopyFromScreen(region.Point.X, region.Point.Y, 0, 0, region.Size);
                return memoryImage;
            }
        }
    }
}


