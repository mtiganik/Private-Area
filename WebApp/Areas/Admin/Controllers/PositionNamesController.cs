using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain;
using Microsoft.AspNetCore.Authorization;
using WebApp.Areas.Admin.Models;

namespace WebApp.Area.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
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
            return View(await _context.PositionNames.Include(i => i.PositionNameName).ThenInclude(i => i.Translations).ToListAsync());
        }

        // GET: PositionNames/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var positionName = await _context.PositionNames
                .Include( t=> t.PositionNameName)
                    .ThenInclude(t => t.Translations)
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( PositionNameVM vm)
        {
            if (ModelState.IsValid)
            {
                vm.PositionName.PositionNameName = new MultiLangString(vm.PositionNameName);
                _context.Add(vm.PositionName);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        // GET: PositionNames/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var positionName = await _context.PositionNames
                .Include(t => t.PositionNameName)
                    .ThenInclude(t => t.Translations)
                   .SingleOrDefaultAsync(m => m.PositionNameId == id);
            if (positionName == null)
            {
                return NotFound();
            }
            var vm = new PositionNameVM();
            vm.PositionNameName = positionName.PositionNameName.ToString();
            vm.PositionName = positionName;
            return View(vm);
        }

        // POST: PositionNames/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PositionNameVM vm)
        {
            if (id != vm.PositionName.PositionNameId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    vm.PositionName.PositionNameName =
                        _context.MultiLangStrings
                            .Include(t => t.Translations)
                            .FirstOrDefault(m =>
                            m.MultiLangStringId == vm.PositionName.PositionNameId) ?? new MultiLangString();
                    vm.PositionName.PositionNameName.SetTranslation(vm.PositionNameName);


                    _context.Update(vm.PositionName);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PositionNameExists(vm.PositionName.PositionNameId))
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
            return View(vm);
        }

        // GET: PositionNames/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var positionName = await _context.PositionNames
                .Include( t => t.PositionNameName)
                    .ThenInclude( t => t.Translations)
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
            var positionName = await _context.PositionNames
                .Include(t => t.PositionNameName)
                .ThenInclude(t => t.Translations)
                .SingleOrDefaultAsync(m => m.PositionNameId == id);
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
