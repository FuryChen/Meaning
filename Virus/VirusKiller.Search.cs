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
            RegionSquare location = Engine.TemplateMatching(Screen.CaptureScreen(), "MatchFile/Home/MainWeapon.png");
            if (location == null)
            {
                //报错
            }
            else
            {
                //赋值
                GameWnd = location;
                Screen.SetDefaultRegion(location);
            }
        }
    }
}
