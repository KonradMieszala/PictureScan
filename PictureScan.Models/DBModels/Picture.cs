﻿using PictureScan.Models.DBModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PictureScan.Models
{
    public class Picture
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "varchar(26)")]
        public string FileName { get; set; }
        [ForeignKey("Directory")]
        public int DirectoryId { get; set; }
        public virtual Directory Directory { get; set; }
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
