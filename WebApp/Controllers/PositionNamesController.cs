using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain;

namespace WebApp.Controllers
{
    public class PositionNamesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PositionNamesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PositionNames
        public async Task<IActionResult> Index()
        {
            return View(await _context.PositionNames.ToListAsync());
        }

        // GET: PositionNames/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var positionName = await _context.PositionNames
                .SingleOrDefaultAsync(m => m.PositionNameId == id);
            if (positionName == null)
            {
                return NotFound();
            }

            return View(positionName);
        }

        // GET: PositionNames/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PositionNames/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PositionNameId,PositionNameEng,PositionNameEst")] PositionName positionName)
        {
            if (ModelState.IsValid)
            {
                _context.Add(positionName);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(positionName);
        }

        // GET: PositionNames/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var positionName = await _context.PositionNames.SingleOrDefaultAsync(m => m.PositionNameId == id);
            if (positionName == null)
            {
                return NotFound();
            }
            return View(positionName);
        }

        // POST: PositionNames/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PositionNameId,PositionNameEng,PositionNameEst")] PositionName positionName)
        {
            if (id != positionName.PositionNameId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(positionName);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PositionNameExists(positionName.PositionNameId))
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
            return View(positionName);
        }

        // GET: PositionNames/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var positionName = await _context.PositionNames
                .SingleOrDefaultAsync(m => m.PositionNameId == id);
            if (positionName == null)
            {
                return NotFound();
            }

            return View(positionName);
        }

        // POST: PositionNames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var positionName = await _context.PositionNames.SingleOrDefaultAsync(m => m.PositionNameId == id);
            _context.PositionNames.Remove(positionName);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PositionNameExists(int id)
        {
            return _context.PositionNames.Any(e => e.PositionNameId == id);
        }
    }
}
