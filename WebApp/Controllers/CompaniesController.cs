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

namespace WebApp.Controllers
{
    public class CompaniesController : Controller
    {
        //private readonly ApplicationDbContext _context;

        private readonly IAppUnitOfWork _uow;

        public CompaniesController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: Companies
        public async Task<IActionResult> Index()
        {
            // var applicationDbContext = _context.Companys.Include(c => c.CompanyFieldOfActivity).Include(c => c.CompanyType);
            

            return View(await _uow.Companies.AllAsync());
        }

        // GET: Companies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _uow.Companies.FindAsync(id);
            

            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // GET: Companies/Create
        public IActionResult Create()
        {
            //ViewData["CompanyFieldOfActivityId"] = new SelectList(_context.CompanyFieldOfActivities, "CompanyFieldOfActivityId", "CompanyFieldOfActivityId");
            //ViewData["CompanyTypeId"] = new SelectList(_context.CompanyTypes, "CompanyTypeId", "CompanyTypeId");
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompanyId,CompanyName,CompanyRegistrationName,CompanyWebsite,CompanyTypeId,CompanyFieldOfActivityId")] Company company)
        {
            if (ModelState.IsValid)
            {
                await  _uow.Companies.AddAsync(company);
                    //_context.Add(company);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["CompanyFieldOfActivityId"] = new SelectList(_context.CompanyFieldOfActivities, "CompanyFieldOfActivityId", "CompanyFieldOfActivityId", company.CompanyFieldOfActivityId);
            //ViewData["CompanyTypeId"] = new SelectList(_context.CompanyTypes, "CompanyTypeId", "CompanyTypeId", company.CompanyTypeId);
            return View(company);
        }

        // GET: Companies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _uow.Companies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            //ViewData["CompanyFieldOfActivityId"] = new SelectList(_context.CompanyFieldOfActivities, "CompanyFieldOfActivityId", "CompanyFieldOfActivityId", company.CompanyFieldOfActivityId);
            //ViewData["CompanyTypeId"] = new SelectList(_context.CompanyTypes, "CompanyTypeId", "CompanyTypeId", company.CompanyTypeId);
            return View(company);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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
                    _uow.Companies.Update(company);
                    await _uow.SaveChangesAsync();
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
                return RedirectToAction(nameof(Index));
            }
            //ViewData["CompanyFieldOfActivityId"] = new SelectList(_context.CompanyFieldOfActivities, "CompanyFieldOfActivityId", "CompanyFieldOfActivityId", company.CompanyFieldOfActivityId);
            //ViewData["CompanyTypeId"] = new SelectList(_context.CompanyTypes, "CompanyTypeId", "CompanyTypeId", company.CompanyTypeId);
            return View(company);
        }

        // GET: Companies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _uow.Companies.FindAsync(id);
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
            
            _uow.Companies.Remove(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyExists(int id)
        {
            if(_uow.Companies.Find(id) != null)
            return true;
            else return false;
        }
    }
}
