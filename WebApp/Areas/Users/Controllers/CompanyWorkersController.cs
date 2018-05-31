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
            if(fromProject != null)
            {
                ViewBag.fromProject = fromProject;
            }
            var companyWorker = await _context.CompanyWorkers.SingleOrDefaultAsync(m => m.CompanyWorkerId == id);
            if (companyWorker == null)
            {
                return NotFound();
            }
            ViewData["CompanyWorkerPositionId"] = new SelectList(_context.CompanyWorkerPositions, "CompanyWorkerPositionId",IsEnglish() ? "PositionName" : "PositionNameEst", companyWorker.CompanyWorkerPositionId);

            //ViewData["CompanyWorkerPositionId"] = new SelectList(_context.CompanyWorkerPositions, "CompanyWorkerPositionId", "CompanyWorkerPositionId", companyWorker.CompanyWorkerPositionId);
            return View(companyWorker);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, int? fromProject, [Bind("CompanyWorkerId,WorkerName,CompanyWorkerPositionId,WorkerPhone,WorkerEmail,EntryAdded,CompanyId")] CompanyWorker companyWorker)
        {
            if (id != companyWorker.CompanyWorkerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    companyWorker.EntryAdded = DateTime.Now;
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
                if (fromProject != null)
                {
                    return RedirectToAction("Details", "Companies", new { id = fromProject });
                }

                return RedirectToAction("Index","Companies");
            }
            ViewData["CompanyWorkerPositionId"] = new SelectList(_context.CompanyWorkerPositions, "CompanyWorkerPositionId", "CompanyWorkerPositionId", companyWorker.CompanyWorkerPositionId);
            return View(companyWorker);
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

        private bool IsEnglish()
        {
            if (Thread.CurrentThread.CurrentUICulture.Name.ToString() == "en-GB")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
