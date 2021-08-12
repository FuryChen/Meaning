using MetaData;
using OpenCvSharp;
using System;
using System.Drawing;
using System.IO;
using System.Threading;
using Point = OpenCvSharp.Point;

namespace CVLibrary
{
    public class OpenCV : IDisposable
    {
        public Mat mat { get; set; }
        public Window wnd { get; set; }
        public OpenCV()
        {
            mat = new Mat();
            wnd = new Window($"{DateTime.Now:MM-dd HH:mm:ss.fff}");
        }

        public void Dispose()
        {
            mat.Dispose();
            wnd.Close();
            wnd.Dispose();
        }




        public void Load(Image img,bool show = true)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                img.Dispose();
                mat = Mat.FromImageData(ms.ToArray(), ImreadModes.AnyColor);
                if(show)
                    Show();
            }
        }


        private void Show()
        {
            try
            {
                wnd.ShowImage(mat);
                Cv2.WaitKey(1);
            }
            catch (Exception)
            {
            }
        }


        public RegionSquare TemplateMatching(Image src, string temp)
        {
            Load(src, false);
            Mat matTemplate = Cv2.ImRead(temp, ImreadModes.AnyColor);
            Mat matResult = new Mat();



            //进行匹配(1母图,2模版子图,3返回的result，4匹配模式_这里的算法比opencv少，具体可以看opencv的相关资料说明)
            Cv2.MatchTemplate(mat, matTemplate, matResult, TemplateMatchModes.SqDiff);

            //对结果进行归一化(这里我测试的时候没有发现有什么用,但在opencv的书里有这个操作，应该有什么神秘加成，这里也加上)
            Cv2.Normalize(matResult, matResult, 1, 0, NormTypes.MinMax, -1);

            Point minLocation, maxLocation;
            /// 通过函数 minMaxLoc 定位最匹配的位置
            /// (这个方法在opencv里有5个参数，这里我写的时候发现在有3个重载，看了下可以直接写成拿到起始坐标就不取最大值和最小值了)
            /// minLocation和maxLocation根据匹配调用的模式取不同的点
            Cv2.MinMaxLoc(matResult, out minLocation, out maxLocation);
            //画出匹配的矩，
            //  Cv2.Rectangle(mat1, maxLocation, new Point (maxLocation.X+mat2.Cols, maxLocation.Y+mat2.Rows), Scalar.Red, 2);
            Cv2.Rectangle(mat, minLocation, new Point(minLocation.X + matTemplate.Cols, minLocation.Y + matTemplate.Rows), Scalar.Red, 2);


            //Show();
            return new RegionSquare(minLocation.X, minLocation.Y, 0, 0);
        }

    }
}
