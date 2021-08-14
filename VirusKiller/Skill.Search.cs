using CVLibrary;
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
        //img不用ref也可以。
        public bool FindMainWindow(ref Image img)
        {
            if (!OpenCV.TemplateMatching(ref img, "MatchFile/Home/MainWeapon.png",out RegionSquare locationTemp))
            {
                LogThrow?.Invoke("未查找到窗口界面.............", new EventArgs() { });
                //报错
                //throw new Exception("未查找到窗口界面");
                return false;
            }
            else
            {
                LogThrow?.Invoke("查找到窗口界面", new EventArgs() { });
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
                return true;
            }
        }
    }
}
