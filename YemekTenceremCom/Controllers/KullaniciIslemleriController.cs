using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YemekTenceremCom.Models;
using YemekTenceremCom.Data;
using Microsoft.AspNetCore.Http;

namespace YemekTenceremCom.Controllers
{
    public class KullaniciIslemleriController : Controller
    {
        YemekContext db;
        public KullaniciIslemleriController(YemekContext db)
        {
            this.db = db;
        }
        public IActionResult Giris()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Giris(Kullanici kullanici)
        {
            Kullanici bulunanKullanici;
            try
            {
                bulunanKullanici = db.Kullanicilar.Where(x => x.KAdi == kullanici.KAdi && x.Sifre == kullanici.Sifre).Single();
            }
            catch (Exception)
            {
                bulunanKullanici = null;
            }

            if (bulunanKullanici != null)
            {
                HttpContext.Session.SetString("kAdi", bulunanKullanici.KAdi);
                HttpContext.Session.SetString("turu", bulunanKullanici.Turu);
            }

            return RedirectToAction("Index", "YemekIslemleri");
        }
    }
}