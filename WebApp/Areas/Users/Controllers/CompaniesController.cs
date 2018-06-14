using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain;
using DAL.App.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Threading;
using Microsoft.AspNetCore.Routing;
using WebApp.Areas.Users.Models;
using Microsoft.AspNetCore.Identity;

namespace WebApp.Areas.Users.Controllers
{
    [Authorize]
    [Area("Users")]
    public class CompaniesController : Controller
    {


        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        //private readonly IAppUnitOfWork _uow;

        public CompaniesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }



        // GET: Companies
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Companies
                .Include(c => c.CompanyFieldOfActivity)
                .ThenInclude(c => c.ActivityName)
                    .ThenInclude(c => c.Translations)
                .Include(c => c.CompanyType)
                    .ThenInclude(c => c.CompanyTypeName)
                        .ThenInclude(c => c.Translations);
            

            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Companies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var vm = new CompanyDetailsViewModel();
            vm.SelectedCompany = await _context.Companies.Where(u => u.CompanyId == id)
                .Include(i => i.CompanyProjects)
                    .ThenInclude(i => i.Project)
                .Include(i => i.CompanyType)
                    .ThenInclude(i => i.CompanyTypeName)
                        .ThenInclude(i => i.Translations)
                .Include(i => i.CompanyWorkers)
                    .ThenInclude(i => i.CompanyWorkerPosition)
                        .ThenInclude(i => i.PositionName)
                            .ThenInclude(i => i.Translations)
                .Include(i => i.CompanyFieldOfActivity)
                    .ThenInclude(i => i.ActivityName)
                        .ThenInclude(i => i.Translations)
                .AsNoTracking()
                .SingleOrDefaultAsync();

            vm.Contacts = await _context.Contacts.Where(u => u.CompanyId == id)
                .Include(i => i.ApplicationUser)
                .Include(i => i.ContactType)
                    .ThenInclude(i => i.ContactTypeName)
                        .ThenInclude(i => i.Translations)
                .Include(i => i.CompanyWorker)
                .Include(i => i.Company)
                .Include(i => i.Project)
                .AsNoTracking()
                .ToListAsync();

            vm.WorkerPositionSelectList = new SelectList(_context.CompanyWorkerPositions.Include(i => i.PositionName).ThenInclude(i => i.Translations), nameof(CompanyWorkerPosition.CompanyWorkerPositionId), nameof(CompanyWorkerPosition.PositionName));
            vm.CompanyWorkerSelectList = new SelectList(_context.CompanyWorkers.Where(u => u.CompanyId == id), nameof(CompanyWorker.CompanyWorkerId), nameof(CompanyWorker.WorkerName));
            vm.ProjectSelectList = new SelectList(_context.Projects, nameof(Project.ProjectId), nameof(Project.ProjectName));
            vm.ContactTypeSelectList = new SelectList(_context.ContactTypes.Include(i => i.ContactTypeName).ThenInclude(i => i.Translations), nameof(ContactType.ContactTypeId), nameof(ContactType.ContactTypeName));

            

            if (vm.SelectedCompany == null)
            {
                return NotFound();
            }

            return View(vm);
        }

        // GET: Companies/Create
        public IActionResult Create(int? fromProject)
        {
            var vm = new CompaniesCreateEditViewModel();
            if (fromProject != null)
            {
                vm.fromProject = fromProject;
                //ViewBag.fromProject = fromProject;
            }
            vm.CompanyFieldOfActivitesSelectList = new SelectList(_context.CompanyFieldOfActivities
                .Include(i => i.ActivityName)
                .ThenInclude(i => i.Translations)
                ,nameof(CompanyFieldOfActivity.CompanyFieldOfActivityId)
                ,nameof(CompanyFieldOfActivity.ActivityName));

            vm.CompanyTypesSelectList = new SelectList(_context.CompanyTypes
                .Include(i => i.CompanyTypeName)
                .ThenInclude(i => i.Translations)
                , nameof(CompanyType.CompanyTypeId)
                , nameof(CompanyType.CompanyTypeName));
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int? fromProject, CompaniesCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await  _context.Companies.AddAsync(vm.Company);
                    //_context.Add(company);
                await _context.SaveChangesAsync();
                if(fromProject != null)
                {
                    return RedirectToAction("Details", "Projects", new { id = fromProject });
                }
                return RedirectToAction(nameof(Index));
            }

            vm.CompanyFieldOfActivitesSelectList = new SelectList(_context.CompanyFieldOfActivities
                .Include(i => i.ActivityName)
                .ThenInclude(i => i.Translations)
                , nameof(CompanyFieldOfActivity.CompanyFieldOfActivityId)
                , nameof(CompanyFieldOfActivity.ActivityName));

            vm.CompanyTypesSelectList = new SelectList(_context.CompanyTypes
                .Include(i => i.CompanyTypeName)
                .ThenInclude(i => i.Translations)
                , nameof(CompanyType.CompanyTypeId)
                , nameof(CompanyType.CompanyTypeName));

            //ViewData["CompanyFieldOfActivityId"] = new SelectList(_context.CompanyFieldOfActivities, "CompanyFieldOfActivityId", IsEnglish() ? "ActivityName" : "ActivityNameEst", company.CompanyFieldOfActivityId);
            //ViewData["CompanyTypeId"] = new SelectList(_context.CompanyTypes, "CompanyTypeId", IsEnglish() ? "CompanyTypeName" : "CompanyTypeNameEst", company.CompanyTypeId);
            return View(vm);
        }

        // GET: Companies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Companies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            var vm = new CompaniesCreateEditViewModel();
            vm.Company = company;
            vm.CompanyFieldOfActivitesSelectList = new SelectList(_context.CompanyFieldOfActivities
                .Include(i => i.ActivityName)
                .ThenInclude(i => i.Translations)
                , nameof(CompanyFieldOfActivity.CompanyFieldOfActivityId)
                , nameof(CompanyFieldOfActivity.ActivityName));

            vm.CompanyTypesSelectList = new SelectList(_context.CompanyTypes
                .Include(i => i.CompanyTypeName)
                .ThenInclude(i => i.Translations)
                , nameof(CompanyType.CompanyTypeId)
                , nameof(CompanyType.CompanyTypeName));

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CompaniesCreateEditViewModel vm)
        {
            if (id != vm.Company.CompanyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Companies.Update(vm.Company);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyExists(vm.Company.CompanyId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", new { id });
            }
            vm.CompanyFieldOfActivitesSelectList = new SelectList(_context.CompanyFieldOfActivities
                      .Include(i => i.ActivityName)
                      .ThenInclude(i => i.Translations)
                      , nameof(CompanyFieldOfActivity.CompanyFieldOfActivityId)
                      , nameof(CompanyFieldOfActivity.ActivityName));

            vm.CompanyTypesSelectList = new SelectList(_context.CompanyTypes
                .Include(i => i.CompanyTypeName)
                .ThenInclude(i => i.Translations)
                , nameof(CompanyType.CompanyTypeId)
                , nameof(CompanyType.CompanyTypeName));

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddWorker(int id, CompanyDetailsViewModel vm)
        {
            if(id != vm.AddNewWorker.CompanyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    vm.AddNewWorker.EntryAdded = DateTime.Now;
                    _context.Update(vm.AddNewWorker);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Details", new { id });

                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;

                }
            }
            return RedirectToAction(nameof(Index));

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddContact(int id, CompanyDetailsViewModel vm)
        {
            if(id != vm.AddNewContact.CompanyId)
            {
                return NotFound();
            }
            vm.AddNewContact.ApplicationUserId = _userManager.GetUserId(User);

            if (ModelState.IsValid)
            {
                try
                {
                    vm.AddNewContact.ContactDate = DateTime.Now;
                    _context.Update(vm.AddNewContact);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Details", new { id });
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;

                }

            }
            return RedirectToAction(nameof(Index));

        }

        // GET: Companies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Companies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var removable = await _context.Companies.SingleOrDefaultAsync(u => u.CompanyId == id);
            _context.Companies.Remove(removable);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyExists(int id)
        {
            if(_context.Companies.Find(id) != null)
            return true;
            else return false;
        }

        //private bool IsEnglish()
        //{
        //    if (Thread.CurrentThread.CurrentUICulture.Name.ToString() == "en-GB")
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

    }
}
