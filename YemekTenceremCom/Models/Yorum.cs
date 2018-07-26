using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YemekTenceremCom.Models
{
    public class Yorum
    {
        public int YorumId { get; set; }
        public string YorumMetni { get; set; }
        public virtual Yemek Yemek { get; set; }
        public string YorumOnay { get; set; }
    }
}
