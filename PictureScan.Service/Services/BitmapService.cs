using PictureScan.Models;
using System;
using System.Drawing;

namespace PictureScan.Service.Services
{
    public interface IBitmapService
    {
        long GetNumberFromPixels(Bitmap bm, int x, int y);
        Picture GetPicture(Bitmap bm);
    }
    public class BitmapService : IBitmapService
    {
        public long GetNumberFromPixels(Bitmap bm, int x, int y)
        {
            var tmp = bm.GetPixel(x, y);
            return Convert.ToInt64(tmp.R + "" + tmp.G + "" + tmp.B);
        }

        public Picture GetPicture(Bitmap bm)
        {
            return new Picture()
            {
                LeftTop = GetNumberFromPixels(bm, 0, 0),
                LeftBottom = GetNumberFromPixels(bm, 0, bm.Height - 1),
                LeftCenter = GetNumberFromPixels(bm, 0, bm.Height / 2),
                CenterTop = GetNumberFromPixels(bm, bm.Width / 2, 0),
                CenterBottom = GetNumberFromPixels(bm, bm.Width / 2, bm.Height - 1),
                CenterCenter = GetNumberFromPixels(bm, bm.Width / 2, bm.Height / 2),
                RightTop = GetNumberFromPixels(bm, bm.Width - 1, 0),
                RightBottom = GetNumberFromPixels(bm, bm.Width - 1, bm.Height - 1),
                RightCenter = GetNumberFromPixels(bm, bm.Width - 1, bm.Height / 2),
            };
        }
    }
}
