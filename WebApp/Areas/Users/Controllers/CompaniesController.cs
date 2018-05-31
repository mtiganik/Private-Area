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
            var applicationDbContext = _context.Companies.Include(c => c.CompanyFieldOfActivity).Include(c => c.CompanyType);
            

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
                .Include(i => i.CompanyWorkers)
                    .ThenInclude(i => i.CompanyWorkerPosition)
                .Include(i => i.CompanyFieldOfActivity)
                .AsNoTracking()
                .SingleOrDefaultAsync();

            vm.Contacts = await _context.Contacts.Where(u => u.CompanyId == id)
                .Include(i => i.ApplicationUser)
                .Include(i => i.ContactType)
                .Include(i => i.CompanyWorker)
                .Include(i => i.Company)
                .Include(i => i.Project)
                .AsNoTracking()
                .ToListAsync();

            vm.WorkerPositionSelectList = new SelectList(_context.CompanyWorkerPositions, "CompanyWorkerPositionId", IsEnglish() ? "PositionName" : "PositionNameEst");
            vm.CompanyWorkerSelectList = new SelectList(_context.CompanyWorkers.Where(u => u.CompanyId == id), "CompanyWorkerId", "WorkerName");
            vm.ProjectSelectList = new SelectList(_context.Projects, "ProjectId", IsEnglish() ? "ProjectName" : "ProjectNameEst");
            vm.ContactTypeSelectList = new SelectList(_context.ContactTypes, "ContactTypeId", IsEnglish() ? "ContactTypeName" : "ContactTypeNameEst");

            

            if (vm.SelectedCompany == null)
            {
                return NotFound();
            }

            return View(vm);
        }

        // GET: Companies/Create
        public IActionResult Create(int? fromProject)
        {
            if(fromProject != null)
            {
                ViewBag.fromProject = fromProject;
            }
            ViewData["CompanyFieldOfActivityId"] = new SelectList(_context.CompanyFieldOfActivities, "CompanyFieldOfActivityId", IsEnglish() ? "ActivityName" : "ActivityNameEst");
            ViewData["CompanyTypeId"] = new SelectList(_context.CompanyTypes, "CompanyTypeId", IsEnglish() ? "CompanyTypeName":"CompanyTypeNameEst");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int? fromProject, [Bind("CompanyId,CompanyName,CompanyRegistrationName,CompanyWebsite,CompanyTypeId,CompanyFieldOfActivityId")] Company company)
        {
            if (ModelState.IsValid)
            {
                await  _context.Companies.AddAsync(company);
                    //_context.Add(company);
                await _context.SaveChangesAsync();
                if(fromProject != null)
                {
                    return RedirectToAction("Details", "Projects", new { id = fromProject });
                }
                return RedirectToAction(nameof(Index));
            }


            ViewData["CompanyFieldOfActivityId"] = new SelectList(_context.CompanyFieldOfActivities, "CompanyFieldOfActivityId", IsEnglish() ? "ActivityName" : "ActivityNameEst", company.CompanyFieldOfActivityId);
            ViewData["CompanyTypeId"] = new SelectList(_context.CompanyTypes, "CompanyTypeId", IsEnglish() ? "CompanyTypeName" : "CompanyTypeNameEst", company.CompanyTypeId);
            return View(company);
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
            ViewData["CompanyFieldOfActivityId"] = new SelectList(_context.CompanyFieldOfActivities, "CompanyFieldOfActivityId", IsEnglish() ? "ActivityName" : "ActivityNameEst", company.CompanyFieldOfActivityId);
            ViewData["CompanyTypeId"] = new SelectList(_context.CompanyTypes, "CompanyTypeId", IsEnglish() ? "CompanyTypeName" : "CompanyTypeNameEst", company.CompanyTypeId);
            return View(company);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CompanyId,CompanyName,CompanyRegistrationName,CompanyWebsite,CompanyTypeId,CompanyFieldOfActivityId")] Company company)
        {
            if (id != company.CompanyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Companies.Update(company);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyExists(company.CompanyId))
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
            ViewData["CompanyFieldOfActivityId"] = new SelectList(_context.CompanyFieldOfActivities, "CompanyFieldOfActivityId", IsEnglish() ? "ActivityName" : "ActivityNameEst", company.CompanyFieldOfActivityId);
            ViewData["CompanyTypeId"] = new SelectList(_context.CompanyTypes, "CompanyTypeId", IsEnglish() ? "CompanyTypeName" : "CompanyTypeNameEst", company.CompanyTypeId);
            return View(company);
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
