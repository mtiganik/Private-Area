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
using DAL.App.Interfaces;

namespace WebApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class CompanyFieldOfActivitiesController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public CompanyFieldOfActivitiesController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: CompanyFieldOfActivities
        public async Task<IActionResult> Index()
        {
            return View(await _uow.CompanyFieldOfActivities.AllAsync());
        }

        // GET: CompanyFieldOfActivities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyFieldOfActivity = await _uow.CompanyFieldOfActivities.GetSingle(id.Value);
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
        public async Task<IActionResult> Create( CompanyFieldOfActivityCreateEditVM vm)
        {
            if (ModelState.IsValid)
            {
                vm.CompanyFieldOfActivity.ActivityName = new MultiLangString(vm.ActivityName);
                await _uow.CompanyFieldOfActivities.AddAsync(vm.CompanyFieldOfActivity);
                await _uow.SaveChangesAsync();
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

            var companyFieldOfActivity = await _uow.CompanyFieldOfActivities.GetSingle(id.Value);
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
                    vm.CompanyFieldOfActivity.ActivityName = await _uow.MultiLangStrings.FindSingleAsync(vm.CompanyFieldOfActivity.ActivityNameId)
                        ?? new MultiLangString();
                    vm.CompanyFieldOfActivity.ActivityName.SetTranslation(vm.ActivityName);


                    _uow.CompanyFieldOfActivities.Update(vm.CompanyFieldOfActivity);
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!(await _uow.CompanyFieldOfActivities.ExistsByPrimaryKeyAsync(vm.CompanyFieldOfActivity.CompanyFieldOfActivityId)))
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

            var companyFieldOfActivity = await _uow.CompanyFieldOfActivities.GetSingle(id.Value);
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
            var companyFieldOfActivity = await _uow.CompanyFieldOfActivities.GetSingle(id);
            _uow.CompanyFieldOfActivities.Remove(companyFieldOfActivity);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
