using KeyMouseControl;
using MetaData;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace VirusKiller
{
    /// <summary>
    /// Search
    /// </summary>
    public partial class Skill
    {
        public Image FindMainWindow(RegionSquare region)
        {
            Image img = Screen.CaptureScreen(region);
            RegionSquare locationTemp = Engine.TemplateMatching(img, "MatchFile/Home/MainWeapon.png");
            if (locationTemp == null)
            {
                LogThrow?.Invoke("未查找到窗口界面", new EventArgs() { });
                //报错
                throw new Exception("未查找到窗口界面");
            }
            else
            {
                //赋值
                RegionSquare location = new RegionSquare()
                {
                    Point = new Point()
                    {
                        X = locationTemp.Point.X - (105 - 59),
                        Y = locationTemp.Point.Y - (806 - 35)
                    },
                    Size = new Size()
                    {
                        Width = 508 - 59 + 1,
                        Height = 878 - 35 + 1
                    }
                };
                GameWnd = location;
            }

            return img;
        }
    }
}
