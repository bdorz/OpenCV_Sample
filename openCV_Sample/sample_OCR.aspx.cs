using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;
using System.IO.Compression;
using OpenCvSharp;

namespace openCV_Sample
{
    public partial class sample_OCR : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string savePath = AppDomain.CurrentDomain.BaseDirectory + @"images\";
            if (FileUpload1.HasFile)
            {
               
                try
                {
                    //上傳檔案
                    string fileName = FileUpload1.FileName;
                    savePath += fileName;
                    FileUpload1.SaveAs(savePath);
                    labResule.Text = fileName + "成功上傳";

                    //string imagePath = AppDomain.CurrentDomain.BaseDirectory + @"images\ocrtest.jpg";
                    //圖片識別
                    Mat img = new Mat(savePath);
                    //Mat img = Cv2.ImRead(savePath);
                    string tessDataPath = AppDomain.CurrentDomain.BaseDirectory + @"tessdata";
                    string result = "";
                    OpenCvSharp.Rect[] textLocations = null;
                    string[] componentTexts = null;
                    float[] confidences = null;
                    using (var engine = OpenCvSharp.Text.OCRTesseract.Create(tessDataPath, "eng"))
                    {
                        engine.Run(img, out result, out textLocations, out componentTexts, out confidences, OpenCvSharp.Text.ComponentLevels.TextLine);
                    }
                    outPutTbArea.InnerText = result;
                }
                catch (Exception)
                {
                    labResule.Text = "上傳失敗，檔案不是圖檔格式";
                }
               
            }
            else
            {
                labResule.Text = "請先選擇檔案";
            }
            
        }
    }
}