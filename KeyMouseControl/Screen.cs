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
        public static RegionSquare RegionDefault { get; set; } = new RegionSquare(0, 0, 1920, 1080);

        public static void SetDefaultRegion(RegionSquare region = null)
        {
            RegionDefault = region ?? new RegionSquare(0, 0, 1920, 1080);
        }

        public static Image CaptureScreen(RegionSquare region = null)
        {
            if (region == null)
                region = RegionDefault;

            Bitmap memoryImage = new Bitmap(region.Size.Width, region.Size.Height, PixelFormat.Format32bppArgb);
            using (Graphics memoryGraphics = Graphics.FromImage(memoryImage))
            {
                memoryGraphics.CopyFromScreen(region.Point.X, region.Point.Y, 0, 0, region.Size);
                return memoryImage;
            }
        }
    }
}


