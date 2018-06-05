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
            var res = _context.CompanyFieldOfActivities
                .Include(c => c.ActivityName)
                    .ThenInclude(c => c.Translations);
            return View(await res.ToListAsync());
        }

        // GET: CompanyFieldOfActivities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyFieldOfActivity = await _context.CompanyFieldOfActivities
                .Include(c => c.ActivityName)
                    .ThenInclude(t => t.Translations)
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CompanyFieldOfActivityCreateEditVM vm)
        {
            if (ModelState.IsValid)
            {
                vm.CompanyFieldOfActivity.ActivityName = new MultiLangString(vm.ActivityName);
                _context.Add(vm.CompanyFieldOfActivity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        // GET: CompanyFieldOfActivities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyFieldOfActivity = await _context.CompanyFieldOfActivities
                .Include(a => a.ActivityName)
                    .ThenInclude(t => t.Translations)
                .SingleOrDefaultAsync(m => m.CompanyFieldOfActivityId == id);

            if (companyFieldOfActivity == null)
            {
                return NotFound();
            }
            var vm = new CompanyFieldOfActivityCreateEditVM();
            vm.ActivityName = companyFieldOfActivity.ActivityName.ToString();
            vm.CompanyFieldOfActivity = companyFieldOfActivity;
            return View(vm);
        }

        // POST: CompanyFieldOfActivities/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CompanyFieldOfActivityCreateEditVM vm)
        {
            if (id != vm.CompanyFieldOfActivity.CompanyFieldOfActivityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    vm.CompanyFieldOfActivity.ActivityName =
                        _context.MultiLangStrings
                            .Include(t => t.Translations)
                            .FirstOrDefault(m =>
                            m.MultiLangStringId == vm.CompanyFieldOfActivity.CompanyFieldOfActivityId) ?? new MultiLangString();
                    vm.CompanyFieldOfActivity.ActivityName.SetTranslation(vm.ActivityName);
                    _context.Update(vm.CompanyFieldOfActivity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyFieldOfActivityExists(vm.CompanyFieldOfActivity.CompanyFieldOfActivityId))
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

        // GET: CompanyFieldOfActivities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyFieldOfActivity = await _context.CompanyFieldOfActivities
                .Include(c => c.ActivityName)
                    .ThenInclude(t => t.Translations)
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
