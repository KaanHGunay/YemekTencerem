using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using YemekTenceremCom.Data;
using YemekTenceremCom.Models;

namespace YemekTenceremCom.Controllers
{
    public class YorumOnayController : Controller
    {
        private readonly YemekContext _context;

        public YorumOnayController(YemekContext context)
        {
            _context = context;
        }

        // GET: YorumOnay
        public async Task<IActionResult> Index()
        {
            await _context.Yemekler.ToListAsync();
            return View(await _context.Yorumlar.ToListAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Onayla(int id, [Bind("YorumId,YorumMetni,YorumOnay")] Yorum yorum)
        {
            yorum = await _context.Yorumlar.SingleOrDefaultAsync(m => m.YorumId == id);

            if (ModelState.IsValid)
            {
                try
                {
                    yorum.YorumOnay = "Onaylandı";
                    _context.Update(yorum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YorumExists(yorum.YorumId))
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
            return View(yorum);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reddet(int id, [Bind("YorumId,YorumMetni,YorumOnay")] Yorum yorum)
        {
            yorum = await _context.Yorumlar.SingleOrDefaultAsync(m => m.YorumId == id);

            if (ModelState.IsValid)
            {
                try
                {
                    yorum.YorumOnay = "Red";
                    _context.Update(yorum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YorumExists(yorum.YorumId))
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
            return View(yorum);
        }

        private bool YorumExists(int id)
        {
            return _context.Yorumlar.Any(e => e.YorumId == id);
        }
    }
}
