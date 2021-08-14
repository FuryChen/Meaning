using CVLibrary;
using KeyMouseControl;
using MetaData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public ObservableCollection<string> OBCLog = new System.Collections.ObjectModel.ObservableCollection<string>() { "123","dsafas"};
        public MainWindow()
        {
            InitializeComponent();

            lvLog.ItemsSource = OBCLog;
            OpenCV.LogThrow += LogThrowHandler;
            Skill.LogThrow += LogThrowHandler;
        }


        private void LogThrowHandler(object sender, EventArgs e)
        {
            this.Dispatcher.Invoke(() => {
                string log = $"{DateTime.Now:HH:mm:ss.fff}   {sender}";
                OBCLog.Add(log);
                lvLog.ScrollIntoView(log);

                if (OBCLog.Count > 50)
                    OBCLog.RemoveAt(0);
            });
        }

        private void SetShow(System.Drawing.Image img)
        {
            this.Dispatcher.Invoke(() => {
                var xxx = ImageConverter.ToImageBrush(img);
                xxx.Stretch = Stretch.Uniform;
                imgGD.Background = xxx;
                img.Dispose();
            });
        }


        bool FlagLoop = false;
        private void Btn_FindWnd_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(FindWnd);
            thread.Start();

        }
        private void FindWnd(object obj)
        {
            System.Drawing.Image img = Screen.CaptureScreen(FullScreen);
            if (Skill.FindMainWindow(ref img))
            {
                SetShow(Screen.CaptureScreen(Skill.GameWnd));
                FindWnd(null);
            }
            else
            {
                SetShow(img);
                FindWnd(null);
            }
        }





        private static void PrintScreen()
        {
            string path = System.IO.Path.Combine(Environment.CurrentDirectory, $"{DateTime.Now:MM dd HH mm ss fff}.png");
            Screen.CaptureScreen(FullScreen).Save(path, System.Drawing.Imaging.ImageFormat.Png);
            Console.WriteLine($"打印至{path}");
        }

    }
}
