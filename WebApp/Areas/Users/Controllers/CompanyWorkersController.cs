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
using System.Threading;
using WebApp.Areas.Users.Models;

namespace WebApp.Areas.Users.Controllers
{
    [Authorize(Roles = "Marketer")]
    [Area("Users")]
    public class CompanyWorkersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompanyWorkersController(ApplicationDbContext context)
        {
            _context = context;
        }
        

        // GET: CompanyWorkers/Edit/5
        public async Task<IActionResult> Edit(int? id, int? fromProject)
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

            var vm = new CompanyWorkerEditVM();
            vm.CompanyWorker = companyWorker;

            if(fromProject != null)
            {
                vm.fromProject = fromProject;
            }
            vm.WorkerPositionSelectList = new SelectList(_context.CompanyWorkerPositions.Include(i => i.PositionName).ThenInclude(t => t.Translations), nameof(CompanyWorkerPosition.CompanyWorkerPositionId), nameof(CompanyWorkerPosition.PositionName), companyWorker.CompanyWorkerPositionId);

            //ViewData["CompanyWorkerPositionId"] = new SelectList(_context.CompanyWorkerPositions, "CompanyWorkerPositionId", "CompanyWorkerPositionId", companyWorker.CompanyWorkerPositionId);
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, int? fromProject, CompanyWorkerEditVM vm)
        {
            if (id != vm.CompanyWorker.CompanyWorkerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    vm.CompanyWorker.EntryAdded = DateTime.Now;
                    _context.Update(vm.CompanyWorker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyWorkerExists(vm.CompanyWorker.CompanyWorkerId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                if (fromProject != null)
                {
                    return RedirectToAction("Details", "Companies", new { id = fromProject });
                }

                return RedirectToAction("Index","Companies");
            }
            vm.WorkerPositionSelectList = new SelectList(_context.CompanyWorkerPositions.Include(i => i.PositionName).ThenInclude(t => t.Translations), nameof(CompanyWorkerPosition.CompanyWorkerPositionId), nameof(CompanyWorkerPosition.PositionName), vm.CompanyWorker.CompanyWorkerPositionId);
            return View(vm);
        }

        // GET: CompanyWorkers/Delete/5
        public async Task<IActionResult> Delete(int? id, int? fromProject)
        {
            if (id == null)
            {
                return NotFound();
            }
            if(fromProject != null)
            {
                ViewBag.fromProject = fromProject;
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
        public async Task<IActionResult> DeleteConfirmed(int id, int?fromProject)
        {
            var companyWorker = await _context.CompanyWorkers.SingleOrDefaultAsync(m => m.CompanyWorkerId == id);
            _context.CompanyWorkers.Remove(companyWorker);
            await _context.SaveChangesAsync();
            if(fromProject != null)
            {
                return RedirectToAction("Details", "Companies", new { id = fromProject });

            }
            return RedirectToAction("Index","Companies");
        }

        private bool CompanyWorkerExists(int id)
        {
            return _context.CompanyWorkers.Any(e => e.CompanyWorkerId == id);
        }


    }
}
