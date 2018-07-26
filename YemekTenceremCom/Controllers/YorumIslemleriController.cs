using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YemekTenceremCom.Data;
using YemekTenceremCom.Models;
using YemekTenceremCom.Models.YorumIslemleriViewModels;

namespace YemekTenceremCom.Controllers
{
    public class YorumIslemleriController : Controller
    {
        private readonly YemekContext _context;

        public YorumIslemleriController(YemekContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> YorumEkle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yemek = await _context.Yemekler.SingleOrDefaultAsync(m => m.Id == id);
            if (yemek == null)
            {
                return NotFound();
            }

            YorumEkleViewModel yorumEkleViewModel = new YorumEkleViewModel();
            yorumEkleViewModel.YemekID = yemek.Id;
            yorumEkleViewModel.YemekAdi = yemek.Ad;
            yorumEkleViewModel.YemekResmi = yemek.Resim;

            return View(yorumEkleViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> YorumEkle(YorumEkleViewModel yorumEkleViewModel)
        {
            if (ModelState.IsValid)
            {
                var yemek = await _context.Yemekler.SingleOrDefaultAsync(m => m.Id == yorumEkleViewModel.YemekID);

                Yorum yorum = new Yorum();
                yorum.YorumMetni = yorumEkleViewModel.YapilanYorum;
                yorum.YorumOnay = "Onay Bekliyor";
                yorum.Yemek = yemek;

                _context.Yorumlar.Add(yorum);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "YemekIslemleri", new { @id = yorumEkleViewModel.YemekID });
            }
            return View(yorumEkleViewModel);
        }
    }
}