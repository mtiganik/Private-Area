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
    public class CompanyWorkerPositionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompanyWorkerPositionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CompanyWorkerPositions
        public async Task<IActionResult> Index()
        {
            return View(await _context.CompanyWorkerPositions.ToListAsync());
        }

        // GET: CompanyWorkerPositions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyWorkerPosition = await _context.CompanyWorkerPositions
                .SingleOrDefaultAsync(m => m.CompanyWorkerPositionId == id);
            if (companyWorkerPosition == null)
            {
                return NotFound();
            }

            return View(companyWorkerPosition);
        }

        // GET: CompanyWorkerPositions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CompanyWorkerPositions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompanyWorkerPositionId,PositionName,PositionNameEst")] CompanyWorkerPosition companyWorkerPosition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(companyWorkerPosition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(companyWorkerPosition);
        }

        // GET: CompanyWorkerPositions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyWorkerPosition = await _context.CompanyWorkerPositions.SingleOrDefaultAsync(m => m.CompanyWorkerPositionId == id);
            if (companyWorkerPosition == null)
            {
                return NotFound();
            }
            return View(companyWorkerPosition);
        }

        // POST: CompanyWorkerPositions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CompanyWorkerPositionId,PositionName,PositionNameEst")] CompanyWorkerPosition companyWorkerPosition)
        {
            if (id != companyWorkerPosition.CompanyWorkerPositionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(companyWorkerPosition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyWorkerPositionExists(companyWorkerPosition.CompanyWorkerPositionId))
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
            return View(companyWorkerPosition);
        }

        // GET: CompanyWorkerPositions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyWorkerPosition = await _context.CompanyWorkerPositions
                .SingleOrDefaultAsync(m => m.CompanyWorkerPositionId == id);
            if (companyWorkerPosition == null)
            {
                return NotFound();
            }

            return View(companyWorkerPosition);
        }

        // POST: CompanyWorkerPositions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var companyWorkerPosition = await _context.CompanyWorkerPositions.SingleOrDefaultAsync(m => m.CompanyWorkerPositionId == id);
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
