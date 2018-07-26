using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YemekTenceremCom.Models
{
    public class Yemek
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Malzemeler { get; set; }
        public string Hazirlanisi { get; set; }
        public string Resim { get; set; }
        [NotMapped] //İlgili alanın vtys'ye yansımamasını sağlar
        public IFormFile ResimDosyasi { get; set; }
        // <input type=file name=ResimDosyasi... 

        public virtual List<Yorum> Yorumlar { get; set; }
    }
}
