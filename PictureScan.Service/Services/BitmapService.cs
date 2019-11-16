using PictureScan.Models;
using PictureScan.Models.ComonModels;
using System;
using System.Drawing;
using System.IO;

namespace PictureScan.Service.Services
{
    public interface IBitmapService
    {
        PictureInfo GetPicture(string pathToFile);
    }
    public class BitmapService : IBitmapService
    {
        private long GetNumberFromPixels(Bitmap bm, int x, int y)
        {
            var tmp = bm.GetPixel(x, y);
            return Convert.ToInt64(tmp.R + "" + tmp.G + "" + tmp.B);
        }

        public PictureInfo GetPicture(string pathToFile)
        {
            Bitmap bm = new System.Drawing.Bitmap(pathToFile);
            return new PictureInfo()
            {
                FileName = Path.GetFileName(pathToFile),
                Path = Path.GetDirectoryName(pathToFile),
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
