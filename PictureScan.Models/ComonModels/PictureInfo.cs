using System;
using System.Collections.Generic;
using System.Text;

namespace PictureScan.Models.ComonModels
{
    public class PictureInfo
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string  Path { get; set; }
        public DateTime CreationFileDate { get; set; }
        public long LeftTop { get; set; }
        public long LeftBottom { get; set; }
        public long LeftCenter { get; set; }
        public long CenterTop { get; set; }
        public long CenterBottom { get; set; }
        public long CenterCenter { get; set; }
        public long RightTop { get; set; }
        public long RightBottom { get; set; }
        public long RightCenter { get; set; }
    }
}
