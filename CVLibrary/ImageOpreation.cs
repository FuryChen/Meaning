using OpenCvSharp;
using System;
using System.IO;
using System.Threading;

namespace CVLibrary
{
    public class ImageOpreation
    {
        public static void Load(string file)
        {
            Mat mat = new Mat(file);
            new Window("123", mat);
        }

        public static void Load(Stream stream)
        {
            Mat mat = Mat.FromStream(stream, ImreadModes.AnyColor);
            using (new Window("123", mat))
            {
                Thread.Sleep(1000 * 1);
            }
        }

        public static void Load(byte[] imageBytes)
        {
            Mat mat = Mat.FromImageData(imageBytes, ImreadModes.AnyColor);
            mat.Circle(new Point(50, 50), 10, new Scalar(255, 00, 00));
            mat.SaveImage(@"C:\Users\CHB\Desktop\456.jpeg");


            Cv2.ImShow("Demo", mat);
            
            Cv2.WaitKey(0);


        }

        public static void Do ()
        {
            #region 
            //自定义一张全红色的图片
            Mat src = new Mat(100, 100, MatType.CV_8UC3, new Scalar(0, 0, 255));
            Vec3b vec3B = new Vec3b();
            //获取第一个像素的三通道像素值
            vec3B.Item0 = src.At<Vec3b>(0, 0)[0];
            vec3B.Item1 = src.At<Vec3b>(0, 0)[1];
            vec3B.Item2 = src.At<Vec3b>(0, 0)[2];
            Console.WriteLine("0 :" + vec3B.Item0); //控制台输出
            Console.WriteLine("1 :" + vec3B.Item1);
            Console.WriteLine("2 :" + vec3B.Item2);


            using (new Window("src image", src)) //创建一个新窗口显示图像
            {
                Cv2.WaitKey();
            }
            #endregion
        }
    }
}
