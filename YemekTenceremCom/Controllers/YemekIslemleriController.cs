using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using YemekTenceremCom.Data;
using YemekTenceremCom.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace YemekTenceremCom.Controllers
{
    public class YemekIslemleriController : Controller
    {
        private readonly YemekContext _context;
        IHostingEnvironment _cevresel;

        public YemekIslemleriController(YemekContext context, IHostingEnvironment cevresel)
        {
            _context = context;
            _cevresel = cevresel;
        }

        // GET: YemekIslemleri
        public async Task<IActionResult> Index()
        {
            return View(await _context.Yemekler.ToListAsync());
        }

        // GET: YemekIslemleri/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _context.Yorumlar.ToListAsync();
            var yemek = await _context.Yemekler
                .SingleOrDefaultAsync(m => m.Id == id);
            if (yemek == null)
            {
                return NotFound();
            }

            return View(yemek);
        }

        // GET: YemekIslemleri/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: YemekIslemleri/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ad,Malzemeler,Hazirlanisi,ResimDosyasi")] Yemek yemek)
        {
            if (ModelState.IsValid)
            {
                var resimler = Path.Combine(_cevresel.WebRootPath, "resimler");
                if (yemek.ResimDosyasi.Length>0)
                {
                    using (var dosya = new FileStream(Path.Combine(resimler,yemek.ResimDosyasi.FileName), FileMode.Create))
                    {
                       await yemek.ResimDosyasi.CopyToAsync(dosya);
                    }
                }

                yemek.Resim = yemek.ResimDosyasi.FileName;

                _context.Add(yemek);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(yemek);
        }

        // GET: YemekIslemleri/Edit/5
        public async Task<IActionResult> Edit(int? id)
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
            return View(yemek);
        }

        // POST: YemekIslemleri/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ad,Malzemeler,Hazirlanisi")] Yemek yemek)
        {
            if (id != yemek.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yemek);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YemekExists(yemek.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(yemek);
        }

        // GET: YemekIslemleri/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yemek = await _context.Yemekler
                .SingleOrDefaultAsync(m => m.Id == id);
            if (yemek == null)
            {
                return NotFound();
            }

            return View(yemek);
        }

        // POST: YemekIslemleri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var yemek = await _context.Yemekler.SingleOrDefaultAsync(m => m.Id == id);
            _context.Yemekler.Remove(yemek);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YemekExists(int id)
        {
            return _context.Yemekler.Any(e => e.Id == id);
        }
    }
}
