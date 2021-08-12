using KeyMouseControl;
using MetaData;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace Virus
{
    /// <summary>
    /// Search
    /// </summary>
    public partial class VirusKiller
    {
        public void FindMainWindow()
        {
            Screen.SetDefaultRegion();
            RegionSquare locationTemp = Engine.TemplateMatching(Screen.CaptureScreen(), "MatchFile/Home/MainWeapon.png");
            if (locationTemp == null)
            {
                //报错
            }
            else
            {
                //赋值

                RegionSquare location = new RegionSquare()
                {
                    Point = new Point()
                    {
                        X = locationTemp.Point.X - ( 105 - 59 ),
                        Y = locationTemp.Point.Y - ( 806 - 35 )
                    },
                    Size = new Size()
                    {
                        Width = 508 - 59 + 1,
                        Height = 878 - 35 + 1
                    }
                };
                GameWnd = location;
                Screen.SetDefaultRegion(location);
            }
        }
    }
}
