using CVLibrary;
using KeyMouseControl;
using System;
using System.IO;
using System.Threading;
using static KeyMouseControl.CtrlMouse;

namespace Meaning
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                OpenCV.GetInstance().Load(Screen.CaptureScreen());
                Thread.Sleep(1);
            }
        }
    }
}
