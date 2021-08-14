using CVLibrary;
using KeyMouseControl;
using MetaData;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VirusKiller
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Skill Skill = new Skill();
        static RegionSquare FullScreen = new RegionSquare(0, 0, (int)SystemParameters.FullPrimaryScreenWidth, (int)SystemParameters.FullPrimaryScreenHeight);

        public MainWindow()
        {
            InitializeComponent();
        }



        private void Btn_FindWnd_Click(object sender, RoutedEventArgs e)
        {
            var img = Skill.FindMainWindow(FullScreen);

            BitmapImage bitmapImage = new BitmapImage();

            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);

            bitmapImage.BeginInit();
            bitmapImage.StreamSource = ms;
            bitmapImage.EndInit();


            imgGD.Background = new ImageBrush(bitmapImage);
            imgGD.Width = img.Width;
            imgGD.Height = img.Height;
        }
























        private static bool flagRun = false;
        private static void StartOpenCVShow()
        {
            Thread thread = new Thread(() => {
                OpenCV V = new OpenCV();
                while (flagRun)
                {
                    V.Load(Screen.CaptureScreen(FullScreen));
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
                    V.TemplateMatching(Screen.CaptureScreen(FullScreen), "MatchFile/Home/MainWeapon.png");
                    Thread.Sleep(1);
                }
            });
            flagRun = true;
            thread.Start();
            Console.WriteLine("OpenCV模板匹配打开");
        }










        private static void PrintScreen()
        {
            string path = System.IO.Path.Combine(Environment.CurrentDirectory, $"{DateTime.Now:MM dd HH mm ss fff}.png");
            Screen.CaptureScreen(FullScreen).Save(path, System.Drawing.Imaging.ImageFormat.Png);
            Console.WriteLine($"打印至{path}");
        }

    }
}
