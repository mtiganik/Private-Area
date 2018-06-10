using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain;
using WebApp.Areas.Admin.Models;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CompanyWorkerPositionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompanyWorkerPositionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/CompanyWorkerPositions
        public async Task<IActionResult> Index()
        {
            var res = _context.CompanyWorkerPositions.Include(i => i.PositionName).ThenInclude(t => t.Translations);
            return View(await res.ToListAsync());
        }

        // GET: Admin/CompanyWorkerPositions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyWorkerPosition = await _context.CompanyWorkerPositions
                .Include(i => i.PositionName).ThenInclude(t => t.Translations)
                .SingleOrDefaultAsync(m => m.CompanyWorkerPositionId == id);
            if (companyWorkerPosition == null)
            {
                return NotFound();
            }

            return View(companyWorkerPosition);
        }

        // GET: Admin/CompanyWorkerPositions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/CompanyWorkerPositions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CompanyWorkerPositionVM vm)
        {
            if (ModelState.IsValid)
            {
                vm.CompanyWorkerPosition.PositionName = new MultiLangString(vm.PositionName);
                _context.Add(vm.CompanyWorkerPosition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        // GET: Admin/CompanyWorkerPositions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyWorkerPosition = await _context.CompanyWorkerPositions.Include(t => t.PositionName)
                .ThenInclude(t => t.Translations)
                .SingleOrDefaultAsync(m => m.CompanyWorkerPositionId == id);
            if (companyWorkerPosition == null)
            {
                return NotFound();
            }
            var vm = new CompanyWorkerPositionVM();

            vm.PositionName = companyWorkerPosition.PositionName.ToString();
            vm.CompanyWorkerPosition = companyWorkerPosition;
            return View(vm);
        }

        // POST: Admin/CompanyWorkerPositions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CompanyWorkerPositionVM vm)
        {
            if (id != vm.CompanyWorkerPosition.CompanyWorkerPositionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    vm.CompanyWorkerPosition.PositionName =
                        _context.MultiLangStrings
                            .Include(t => t.Translations)
                            .FirstOrDefault(m =>
                            m.MultiLangStringId == vm.CompanyWorkerPosition.CompanyWorkerPositionId) ?? new MultiLangString();
                    vm.CompanyWorkerPosition.PositionName.SetTranslation(vm.PositionName);

                    _context.Update(vm.CompanyWorkerPosition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyWorkerPositionExists(vm.CompanyWorkerPosition.CompanyWorkerPositionId))
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

        // GET: Admin/CompanyWorkerPositions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyWorkerPosition = await _context.CompanyWorkerPositions.Include(t => t.PositionName)
                .ThenInclude(t => t.Translations)
                .SingleOrDefaultAsync(m => m.CompanyWorkerPositionId == id);
            if (companyWorkerPosition == null)
            {
                return NotFound();
            }

            return View(companyWorkerPosition);
        }

        // POST: Admin/CompanyWorkerPositions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var companyWorkerPosition = await _context.CompanyWorkerPositions
                .Include(t => t.PositionName).ThenInclude(t => t.Translations)
                .SingleOrDefaultAsync(m => m.CompanyWorkerPositionId == id);
            _context.CompanyWorkerPositions.Remove(companyWorkerPosition);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyWorkerPositionExists(int id)
        {
            return _context.CompanyWorkerPositions.Any(e => e.CompanyWorkerPositionId == id);
        }
    }
}
