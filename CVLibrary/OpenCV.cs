using MetaData;
using OpenCvSharp;
using System;
using System.Drawing;
using System.IO;
using System.Threading;
using Point = OpenCvSharp.Point;

namespace CVLibrary
{
    public class OpenCV
    {

        public static event EventHandler LogThrow;

        public static Mat Load(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                //img.Dispose();
                Mat mat = Mat.FromImageData(ms.ToArray(), ImreadModes.AnyColor);

                return mat;
            }
        }
        public static Image Takeout(Mat mat)
        {
            MemoryStream ms = mat.ToMemoryStream();
            return new Bitmap(ms);
        }

        private static void Show(Mat mat,Window wnd = null)
        {
            if (wnd == null)
                wnd = new Window($"{DateTime.Now:mm-dd HH:MM:ss.fff}");
            wnd.ShowImage(mat);
            Cv2.WaitKey(1);
        }


        public static bool TemplateMatching(ref Image imgSrc, string imgTemp,out RegionSquare region)
        {
            Mat matSrc = Load(imgSrc);
            Mat matTemp = Cv2.ImRead(imgTemp, ImreadModes.AnyColor);
            Mat matResult = new Mat();



            //进行匹配(1母图,2模版子图,3返回的result，4匹配模式_这里的算法比opencv少，具体可以看opencv的相关资料说明)
            Cv2.MatchTemplate(matSrc, matTemp, matResult, TemplateMatchModes.SqDiffNormed);

            //对结果进行归一化(这里我测试的时候没有发现有什么用,但在opencv的书里有这个操作，应该有什么神秘加成，这里也加上)
           // Cv2.Normalize(matResult, matResult, 1, 0, NormTypes.MinMax, -1);

            double minValue, maxValue;
            Point minLocation, maxLocation;
            Cv2.MinMaxLoc(matResult,out minValue,out maxValue, out minLocation, out maxLocation);


            Cv2.Rectangle(matSrc, minLocation, new Point(minLocation.X + matTemp.Cols, minLocation.Y + matTemp.Rows), Scalar.Red, 2);
            Cv2.PutText(matSrc, $"{minLocation}", new Point(0, 30), HersheyFonts.HersheyComplex, 1, Scalar.Red, 3);
            Cv2.PutText(matSrc, $"{maxLocation}", new Point(0, 80), HersheyFonts.HersheyComplex, 1, Scalar.Red, 3);


            LogThrow?.Invoke(new { minValue, maxValue, minLocation, maxLocation }, null);

            imgSrc = Takeout(matSrc);

            region = new RegionSquare(minLocation.X, minLocation.Y, 0, 0);
            return minValue < 0.1;
        }

    }
}
