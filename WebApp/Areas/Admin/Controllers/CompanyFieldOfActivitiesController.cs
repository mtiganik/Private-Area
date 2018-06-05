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


namespace WebApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class CompanyFieldOfActivitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompanyFieldOfActivitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CompanyFieldOfActivities
        public async Task<IActionResult> Index()
        {
            return View(await _context.CompanyFieldOfActivities.ToListAsync());
        }

        // GET: CompanyFieldOfActivities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyFieldOfActivity = await _context.CompanyFieldOfActivities
                .SingleOrDefaultAsync(m => m.CompanyFieldOfActivityId == id);
            if (companyFieldOfActivity == null)
            {
                return NotFound();
            }

            return View(companyFieldOfActivity);
        }

        // GET: CompanyFieldOfActivities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CompanyFieldOfActivities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompanyFieldOfActivityId,ActivityName,ActivityNameEst")] CompanyFieldOfActivity companyFieldOfActivity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(companyFieldOfActivity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(companyFieldOfActivity);
        }

        // GET: CompanyFieldOfActivities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyFieldOfActivity = await _context.CompanyFieldOfActivities.SingleOrDefaultAsync(m => m.CompanyFieldOfActivityId == id);
            if (companyFieldOfActivity == null)
            {
                return NotFound();
            }
            return View(companyFieldOfActivity);
        }

        // POST: CompanyFieldOfActivities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CompanyFieldOfActivityId,ActivityName,ActivityNameEst")] CompanyFieldOfActivity companyFieldOfActivity)
        {
            if (id != companyFieldOfActivity.CompanyFieldOfActivityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(companyFieldOfActivity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyFieldOfActivityExists(companyFieldOfActivity.CompanyFieldOfActivityId))
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
            return View(companyFieldOfActivity);
        }

        // GET: CompanyFieldOfActivities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyFieldOfActivity = await _context.CompanyFieldOfActivities
                .SingleOrDefaultAsync(m => m.CompanyFieldOfActivityId == id);
            if (companyFieldOfActivity == null)
            {
                return NotFound();
            }

            return View(companyFieldOfActivity);
        }

        // POST: CompanyFieldOfActivities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var companyFieldOfActivity = await _context.CompanyFieldOfActivities.SingleOrDefaultAsync(m => m.CompanyFieldOfActivityId == id);
            _context.CompanyFieldOfActivities.Remove(companyFieldOfActivity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyFieldOfActivityExists(int id)
        {
            return _context.CompanyFieldOfActivities.Any(e => e.CompanyFieldOfActivityId == id);
        }
    }
}
