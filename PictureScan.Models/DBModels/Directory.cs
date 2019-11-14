using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PictureScan.Models.DBModels
{
    public class Directory
    {
        // tabela może nie ma super dużego znaczenia, ponieważ bardzo łatwo zmienić nazwę katalogu
        // czy przenieść folder, ale na moment znalezienia dubli zdjęć się przyda
        public Directory()
        {
            Pictures = new HashSet<Picture>();
        }
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "varchar(max)")]
        public string FileDirectory { get; set; }
        public ICollection<Picture> Pictures { get; set; }
    }
}
