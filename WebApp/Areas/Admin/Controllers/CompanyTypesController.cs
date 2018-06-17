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
    public class CompanyTypesController : Controller
    {
        //private readonly ApplicationDbContext _context;
        private readonly IAppUnitOfWork _uow;

        public CompanyTypesController( IAppUnitOfWork uow)
        {
            
            _uow = uow;
        }

        // GET: CompanyTypes
        public async Task<IActionResult> Index()
        {
            //var res = 
            //    _context.CompanyTypes
            //    .Include(t => t.CompanyTypeName)
            //        .ThenInclude(t => t.Translations);
            return View(await _uow.CompanyTypes.AllAsync());
        }

        // GET: CompanyTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyType = await _uow.CompanyTypes.GetSingle(id.Value);
                //_context.CompanyTypes
                //.Include(t => t.CompanyTypeName)
                //    .ThenInclude(t => t.Translations)
                //.SingleOrDefaultAsync(m => m.CompanyTypeId == id);
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CompanyTypeCreateEditVM vm)
        {
            if (ModelState.IsValid)
            {
                vm.CompanyType.CompanyTypeName = new MultiLangString(vm.CompanyTypeName);
                _uow.CompanyTypes.Add(vm.CompanyType);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        // GET: CompanyTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyType = await _uow.CompanyTypes.GetSingle(id.Value);
                //await _context.CompanyTypes
                //.Include(t => t.CompanyTypeName)
                //.ThenInclude(t => t.Translations)
                //.SingleOrDefaultAsync(m => m.CompanyTypeId == id);
            if (companyType == null)
            {
                return NotFound();
            }

            var vm = new CompanyTypeCreateEditVM();
            vm.CompanyTypeName = companyType.CompanyTypeName.ToString();
            vm.CompanyType = companyType;
            return View(vm);
        }

        // POST: CompanyTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CompanyTypeCreateEditVM vm)
        {
            if (id != vm.CompanyType.CompanyTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    vm.CompanyType.CompanyTypeName = await _uow.MultiLangStrings
                        .FindSingleAsync(vm.CompanyType.CompanyTypeNameId)
                        ?? new MultiLangString();
                        //_context.MultiLangStrings
                        //.Include(t => t.Translations)
                        //.FirstOrDefault(m =>
                        //m.MultiLangStringId == vm.CompanyType.CompanyTypeNameId) ?? new MultiLangString();
                    vm.CompanyType.CompanyTypeName.SetTranslation(vm.CompanyTypeName);
                    _uow.CompanyTypes.Update(vm.CompanyType);
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (! (await _uow.CompanyTypes.ExistsByPrimaryKeyAsync(vm.CompanyType.CompanyTypeId)))
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

        // GET: CompanyTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyType = await _uow.CompanyTypes.GetSingle(id.Value);
                //_context.CompanyTypes.Include(t => t.CompanyTypeName).ThenInclude(t => t.Translations)
                //.SingleOrDefaultAsync(m => m.CompanyTypeId == id);
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
            var companyType = await _uow.CompanyTypes.GetSingle(id);
                //context.CompanyTypes.SingleOrDefaultAsync(m => m.CompanyTypeId == id);
            _uow.CompanyTypes.Remove(companyType);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
