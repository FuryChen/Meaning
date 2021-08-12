using CVLibrary;
using KeyMouseControl;
using MetaData;
using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;

namespace Virus
{

    /// <summary>
    /// Operation
    /// </summary>
    public partial class VirusKiller
    {
        public bool IsWait = false;
        public void Wait()
        {
            Console.WriteLine("wait" + Thread.CurrentThread.ManagedThreadId);
            IsWait = true;
            while (IsWait)
            {
                
                Engine.Load(Screen.CaptureScreen());
                Thread.Sleep(1);
            }
        }

        public void StopWait()
        {
            Console.WriteLine("wait" + Thread.CurrentThread.ManagedThreadId);
            IsWait = false;
        }




        public void SelectLevel(int level)
        {
            //展开关卡列表
            //点击左侧210关卡
        }


       
    }
}
