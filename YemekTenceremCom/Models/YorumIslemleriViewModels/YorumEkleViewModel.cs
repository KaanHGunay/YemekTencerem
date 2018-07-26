using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YemekTenceremCom.Models.YorumIslemleriViewModels
{
    public class YorumEkleViewModel
    {
        [Key]
        public int YemekID { get; set; }
        [Display(Name = "Yemek")]
        public string YemekAdi { get; set; }
        public string YemekResmi { get; set; }
        public string YapilanYorum { get; set; }
    }
}
