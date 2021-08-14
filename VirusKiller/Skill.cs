using CVLibrary;
using KeyMouseControl;
using MetaData;
using System;
using System.Drawing;
using System.Threading;

namespace VirusKiller
{
    public partial class Skill
    {
        public event EventHandler LogThrow;


        public RegionSquare GameWnd { get; set; } = new RegionSquare();
        public OpenCV Engine { get; set; }


        public Skill()
        {
            Engine = new OpenCV();
        }


        private bool FlagAllTime;
        public void StartGameAllTime()
        {
            //开启连续路径规划
            Thread Thread = new Thread(AllTimeRun);
            FlagAllTime = true;
            Thread.Start();
        }
        private void AllTimeRun(object obj)
        {
            while (FlagAllTime)
            {
                SelectLevel(210);
                StartGameOneTime();
            }
        }




        private bool FlagOneTime;
        public void StartGameOneTime()
        {
            //开启连续路径规划
            Thread Thread = new Thread(OneTimeRun);
            FlagOneTime = true;
            Thread.Start();
        }
        private bool xx;
        private void OneTimeRun(object obj)
        {
            while (FlagOneTime)
            {
                //查看游戏是否提前结束
                if (xx)
                {
                    FlagOneTime = false;
                    break;
                }

                //查看游戏是否正常结束
                if (xx)
                {
                    FlagOneTime = false;
                    break;
                }

                //寻找路径
                //执行路径
            }
        }





        public void StopImmediately()
        {
            FlagAllTime = false;
            FlagOneTime = false;
        }



        public void StopSoon()
        {
            FlagAllTime = false;
        }
    }


}