﻿using CVLibrary;
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
            //int cmd = 0;
            //Console.WriteLine("Hello World!");
            //Console.ReadLine();
            //Thread.Sleep(5000);
            //Console.WriteLine("Well Done");
            //while (cmd == 0)
            //{
            //    CtrlMouse.TestMoveMouse((int)EnumMoveType.MOUSEEVENTF_LEFTDOWN | (int)EnumMoveType.MOUSEEVENTF_MOVE, 100, 0);
            //    Thread.Sleep(500);
            //    CtrlMouse.TestMoveMouse((int)EnumMoveType.MOUSEEVENTF_LEFTDOWN | (int)EnumMoveType.MOUSEEVENTF_MOVE, 0, 100);
            //    Thread.Sleep(500);
            //    CtrlMouse.TestMoveMouse((int)EnumMoveType.MOUSEEVENTF_LEFTDOWN | (int)EnumMoveType.MOUSEEVENTF_MOVE, -100, 0);
            //    Thread.Sleep(500);
            //    CtrlMouse.TestMoveMouse((int)EnumMoveType.MOUSEEVENTF_LEFTDOWN | (int)EnumMoveType.MOUSEEVENTF_MOVE, 0, -100);
            //    Thread.Sleep(500);
            //    Console.WriteLine("Over");
            //}
            ////Screen.CaptureScreen();
            //Console.WriteLine("Well Done");


            System.Drawing.Image img = Screen.CaptureScreen();
            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            img.Save(@"C:\Users\CHB\Desktop\123.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
            ImageOpreation.Load(ms.ToArray());

            Console.ReadLine();

        }
    }
}