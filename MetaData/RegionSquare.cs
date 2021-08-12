using System;
using System.Drawing;

namespace MetaData
{
    public class RegionSquare
    {
        public Point Point 
        { 
            get; 
            set; 
        }
        
        public Size Size 
        { 
            get; 
            set; 
        }
        
        public Point Center 
        {
            get => new Point((Point.X + Size.Width) / 2, (Point.Y + Size.Height) / 2);
        }


        public RegionSquare()
        {
            Point = new Point();
            Size = new Size();
        }

        public RegionSquare(Point point, Size size)
        {
            Point = point;
            Size = size;
        }

        public RegionSquare(int x, int y, int width, int height)
        {
            Point = new Point(x, y);
            Size = new Size(width, height);
        }

    }
}
