using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OpenCvSharp;
using System.Drawing;

namespace openCV_Sample
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
                string filename = @"E:\Project\新技術\openCV_Sample\openCV_Sample\bin\people.jpeg";
                //CvInvoke.UseOpenCL = CvInvoke.HaveOpenCLCompatibleGpuDevice;//使用GPU運算
                var face = new CascadeClassifier(@"E:\Project\新技術\openCV_Sample\openCV_Sample\bin\haarcascade_frontalface_default.xml");
                var mat = new Mat(filename, ImreadModes.Grayscale);//灰度匯入圖片 
                int minNeighbors = 7;//最小矩陣組，預設3
                                     //var size = new System.Drawing.Size(10, 10);//最小頭像大小
                var facesDetected = face.DetectMultiScale(mat, 1.1, minNeighbors);
                //迴圈把人臉部分切割出來並儲存
                int index = 0;
                var bitmap = Bitmap.FromFile(filename);
                foreach (var item in facesDetected)
                {
                    index++;
                    var bmpOut = new Bitmap(item.Width, item.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                    var g = Graphics.FromImage(bmpOut);
                    g.DrawImage(bitmap, new System.Drawing.Rectangle(0, 0, item.Width, item.Height),
                        new System.Drawing.Rectangle(item.X, item.Y, item.Width, item.Height), GraphicsUnit.Pixel);
                    g.Dispose();
                    bmpOut.Save(@"E:\Project\新技術\openCV_Sample\openCV_Sample\bin\Face_" + index.ToString() + ".png", System.Drawing.Imaging.ImageFormat.Png);
                    bmpOut.Dispose();
                }
                bitmap.Dispose();
                mat.Dispose();
                face.Dispose();
        }
    }
}