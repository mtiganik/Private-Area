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
    public class CompanyWorkersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompanyWorkersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CompanyWorkers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CompanyWorkers.Include(c => c.CompanyWorkerPosition);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CompanyWorkers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyWorker = await _context.CompanyWorkers
                .Include(c => c.CompanyWorkerPosition)
                .SingleOrDefaultAsync(m => m.CompanyWorkerId == id);
            if (companyWorker == null)
            {
                return NotFound();
            }

            return View(companyWorker);
        }

        // GET: CompanyWorkers/Create
        public IActionResult Create()
        {
            ViewData["CompanyWorkerPositionId"] = new SelectList(_context.CompanyWorkerPositions, "CompanyWorkerPositionId", "CompanyWorkerPositionId");
            return View();
        }

        // POST: CompanyWorkers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompanyWorkerId,WorkerName,CompanyWorkerPositionId,WorkerPhone,WorkerEmail,EntryAdded,CompanyId")] CompanyWorker companyWorker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(companyWorker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompanyWorkerPositionId"] = new SelectList(_context.CompanyWorkerPositions, "CompanyWorkerPositionId", "CompanyWorkerPositionId", companyWorker.CompanyWorkerPositionId);
            return View(companyWorker);
        }

        // GET: CompanyWorkers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyWorker = await _context.CompanyWorkers.SingleOrDefaultAsync(m => m.CompanyWorkerId == id);
            if (companyWorker == null)
            {
                return NotFound();
            }
            ViewData["CompanyWorkerPositionId"] = new SelectList(_context.CompanyWorkerPositions, "CompanyWorkerPositionId", "CompanyWorkerPositionId", companyWorker.CompanyWorkerPositionId);
            return View(companyWorker);
        }

        // POST: CompanyWorkers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CompanyWorkerId,WorkerName,CompanyWorkerPositionId,WorkerPhone,WorkerEmail,EntryAdded,CompanyId")] CompanyWorker companyWorker)
        {
            if (id != companyWorker.CompanyWorkerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(companyWorker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyWorkerExists(companyWorker.CompanyWorkerId))
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
            ViewData["CompanyWorkerPositionId"] = new SelectList(_context.CompanyWorkerPositions, "CompanyWorkerPositionId", "CompanyWorkerPositionId", companyWorker.CompanyWorkerPositionId);
            return View(companyWorker);
        }

        // GET: CompanyWorkers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyWorker = await _context.CompanyWorkers
                .Include(c => c.CompanyWorkerPosition)
                .SingleOrDefaultAsync(m => m.CompanyWorkerId == id);
            if (companyWorker == null)
            {
                return NotFound();
            }

            return View(companyWorker);
        }

        // POST: CompanyWorkers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var companyWorker = await _context.CompanyWorkers.SingleOrDefaultAsync(m => m.CompanyWorkerId == id);
            _context.CompanyWorkers.Remove(companyWorker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyWorkerExists(int id)
        {
            return _context.CompanyWorkers.Any(e => e.CompanyWorkerId == id);
        }
    }
}
