using System;

namespace KeyMouseControl
{
    public class CtrlMouse
    {
        [System.Runtime.InteropServices.DllImport("user32")]
        private static extern int mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);



        public static void TestMoveMouse(int dwFlags, int dx, int dy)
        {
            mouse_event(dwFlags, dx, dy, 0, 0);
        }

        public enum EnumMoveType
        {
            //移动鼠标
            MOUSEEVENTF_MOVE = 0x0001,
            //模拟鼠标左键按下
            MOUSEEVENTF_LEFTDOWN = 0x0002,
            //模拟鼠标左键抬起
            MOUSEEVENTF_LEFTUP = 0x0004,
            //模拟鼠标右键按下
            MOUSEEVENTF_RIGHTDOWN = 0x0008,
            //模拟鼠标右键抬起
            MOUSEEVENTF_RIGHTUP = 0x0010,
            //模拟鼠标中键按下
            MOUSEEVENTF_MIDDLEDOWN = 0x0020,
            //模拟鼠标中键抬起
            MOUSEEVENTF_MIDDLEUP = 0x0040,
            //标示是否采用绝对坐标
            MOUSEEVENTF_ABSOLUTE = 0x8000,
            //模拟鼠标滚轮滚动操作，必须配合dwData参数
            MOUSEEVENTF_WHEEL = 0x0800,
    }
    }

}
