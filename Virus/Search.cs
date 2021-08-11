using CVLibrary;
using KeyMouseControl;
using System;
using System.Drawing;
using System.Threading;

namespace Virus
{
    public class Search
    {
        public void FindMainWindow(Image img)
        {
            OpenCV.GetInstance().Load(Screen.CaptureScreen());
            var location = OpenCV.GetInstance().TemplateMatching(null);
            if (location == null)
            {
                //报错
            }
            else
            {
                //赋值
            }
        }
    }


    public class Operation
    {
        private bool FlagAllTime;
        public void StartGameAllTime()
        {
            //开启连续路径规划
            Thread Thread = new Thread(()=> {
                while (FlagAllTime)
                {
                    SelectLevel(210);
                    StartGameOneTime();
                }
            });
            FlagAllTime = true;
            Thread.Start();
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










        public void SelectLevel(int level)
        {
            //展开关卡列表
            //点击左侧210关卡
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
    }
}
