using CVLibrary;
using KeyMouseControl;
using System;
using System.IO;
using System.Threading;
using Virus;
using static KeyMouseControl.CtrlMouse;

namespace Meaning
{
    class Program
    {
        static bool flagMain = true;
        static void Main(string[] args)
        {
            Console.WriteLine("程序已启动.............");
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            string cmd;
            while (flagMain)
            {
                cmd = Console.ReadLine();
                switch (cmd)
                {
                    case "show":        StartOpenCVShow();      break;
                    case "match":       StartOpenCVMatch();     break;
                    case "start":       startWait?.Invoke();    break;
                    case "stop":        Stop();                 break;

                    case "ps":          PrintScreen();          break;
                    case "findwnd":     FindWnd();               break;

                    case "exit":
                        flagMain = false;
                        break;
                    default:
                        Console.WriteLine("未识别的命令");
                        break;
                }
            }
        }



        private static bool flagRun = false;
        private static void StartOpenCVShow()
        {
            Thread thread = new Thread(()=> {
                OpenCV V = new OpenCV();
                while (flagRun)
                {
                    V.Load(Screen.CaptureScreen());
                    Thread.Sleep(1);
                }
            });
            flagRun = true;
            thread.Start();
            Console.WriteLine("OpenCV显示打开");
        }


        private static void StartOpenCVMatch()
        {
            Thread thread = new Thread(() => {
                OpenCV V = new OpenCV();
                while (flagRun)
                {
                    V.TemplateMatching(Screen.CaptureScreen(), "MatchFile/Home/MainWeapon.png");
                    Thread.Sleep(1);
                }
            });
            flagRun = true;
            thread.Start();
            Console.WriteLine("OpenCV模板匹配打开");
        }



        private static void Stop()
        {
            stopWait?.Invoke();
            flagRun = false;
            Console.WriteLine("关闭");
        }





        public static Action startWait { get; set; }
        public static Action stopWait { get; set; }

        private static void FindWnd()
        {
            Thread thread = new Thread(() => {
                VirusKiller VK = new VirusKiller();
                startWait += VK.Wait;
                stopWait += VK.StopWait;
                VK.FindMainWindow();
                VK.Wait();
            });
            thread.Start();
        }

        private static void PrintScreen()
        {
            string path = Path.Combine(Environment.CurrentDirectory, $"{DateTime.Now:MM dd HH mm ss fff}.png");
            Screen.CaptureScreen().Save(path,System.Drawing.Imaging.ImageFormat.Png);
            Console.WriteLine($"打印至{path}");
        }
    }
}
