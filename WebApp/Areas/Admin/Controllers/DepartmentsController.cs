using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain;
using WebApp.Areas.Admin.Models;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DepartmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DepartmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Departments
        public async Task<IActionResult> Index()
        {
            return View(await _context.Departments
                .Include(t => t.DepartmentName)
                .ThenInclude(t => t.Translations).ToListAsync());
        }

        // GET: Admin/Departments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _context.Departments
                .Include(t => t.DepartmentName)
                    .ThenInclude(t => t.Translations)
                .SingleOrDefaultAsync(m => m.DepartmentId == id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // GET: Admin/Departments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Departments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DepartmentVM vm)
        {
            if (ModelState.IsValid)
            {
                vm.Department.DepartmentName = new MultiLangString(vm.DepartmentName);
                _context.Add(vm.Department);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        // GET: Admin/Departments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _context.Departments
                .Include(t => t.DepartmentName).ThenInclude(t => t.Translations)
                .SingleOrDefaultAsync(m => m.DepartmentId == id);
            if (department == null)
            {
                return NotFound();
            }
            var vm = new DepartmentVM();
            vm.DepartmentName = department.DepartmentName.ToString();
            vm.Department = department;
            return View(vm);
        }

        // POST: Admin/Departments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DepartmentVM vm)
        {
            if (id != vm.Department.DepartmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    vm.Department.DepartmentName =
                        _context.MultiLangStrings
                            .Include(t => t.Translations)
                            .FirstOrDefault(m =>
                            m.MultiLangStringId == vm.Department.DepartmentNameId) ?? new MultiLangString();
                    vm.Department.DepartmentName.SetTranslation(vm.DepartmentName);

                    _context.Update(vm.Department);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentExists(vm.Department.DepartmentId))
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

        // GET: Admin/Departments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _context.Departments
                .Include(T => T.DepartmentName)
                .ThenInclude(t => t.Translations)
                .SingleOrDefaultAsync(m => m.DepartmentId == id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // POST: Admin/Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var department = await _context.Departments.Include(T => T.DepartmentName)
                .ThenInclude(T => T.Translations)
                .SingleOrDefaultAsync(m => m.DepartmentId == id);
            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentExists(int id)
        {
            return _context.Departments.Any(e => e.DepartmentId == id);
        }
    }
}
