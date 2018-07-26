using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YemekTenceremCom.Models;
using YemekTenceremCom.Models.YorumIslemleriViewModels;

namespace YemekTenceremCom.Data
{
    // YemekContext db = new YemekContext();
    // db.Yemekler...  VTYS'de ki Yemekler tablosuna karşılık gelecek
    public class YemekContext : DbContext
    {
        public YemekContext(DbContextOptions<YemekContext> options) :base(options)
        {

        }
        public DbSet<Yemek> Yemekler { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Yorum> Yorumlar { get; set; }
        public DbSet<YemekTenceremCom.Models.YorumIslemleriViewModels.YorumEkleViewModel> YorumEkleViewModel { get; set; }
    }
}
