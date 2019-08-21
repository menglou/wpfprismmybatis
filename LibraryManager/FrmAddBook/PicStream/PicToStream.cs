using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace FrmAddBook.PicStream
{
   public class PicToStream
    {
        /// <summary>
        /// 图片转成bas64编码
        /// </summary>
        /// <param name="imagefile"></param>
        /// <returns></returns>
        public static string GetBase64FromImage(string imagefile)
        {
            string strbaser64 = "";
            try
            {
                Bitmap bmp = new Bitmap(imagefile);
                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] arr = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(arr, 0, (int)ms.Length);
                ms.Close();
                strbaser64 = Convert.ToBase64String(arr);
            }
            catch (Exception)
            {
                throw new Exception("Something wrong during convert!");
            }
            return strbaser64;
        }
        /// <summary>
        /// base64编码转成图片
        /// </summary>
        /// <param name="base64string"></param>
        /// <returns></returns>
        public static BitmapSource GetImageFromBase64(string base64string)
        {
            byte[] b = Convert.FromBase64String(base64string);
            MemoryStream ms = new MemoryStream(b);
            Bitmap bitmap = new Bitmap(ms);

            BitmapSource bs = Imaging.CreateBitmapSourceFromHBitmap(bitmap.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            return bs;

        }
    }
}
