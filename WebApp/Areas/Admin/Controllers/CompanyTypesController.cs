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
    public class CompanyTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompanyTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CompanyTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CompanyTypes.ToListAsync());
        }

        // GET: CompanyTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyType = await _context.CompanyTypes
                .SingleOrDefaultAsync(m => m.CompanyTypeId == id);
            if (companyType == null)
            {
                return NotFound();
            }

            return View(companyType);
        }

        // GET: CompanyTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CompanyTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompanyTypeId,CompanyTypeName,CompanyTypeNameEst")] CompanyType companyType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(companyType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(companyType);
        }

        // GET: CompanyTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyType = await _context.CompanyTypes.SingleOrDefaultAsync(m => m.CompanyTypeId == id);
            if (companyType == null)
            {
                return NotFound();
            }
            return View(companyType);
        }

        // POST: CompanyTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CompanyTypeId,CompanyTypeName,CompanyTypeNameEst")] CompanyType companyType)
        {
            if (id != companyType.CompanyTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(companyType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyTypeExists(companyType.CompanyTypeId))
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
            return View(companyType);
        }

        // GET: CompanyTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyType = await _context.CompanyTypes
                .SingleOrDefaultAsync(m => m.CompanyTypeId == id);
            if (companyType == null)
            {
                return NotFound();
            }

            return View(companyType);
        }

        // POST: CompanyTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var companyType = await _context.CompanyTypes.SingleOrDefaultAsync(m => m.CompanyTypeId == id);
            _context.CompanyTypes.Remove(companyType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyTypeExists(int id)
        {
            return _context.CompanyTypes.Any(e => e.CompanyTypeId == id);
        }
    }
}
