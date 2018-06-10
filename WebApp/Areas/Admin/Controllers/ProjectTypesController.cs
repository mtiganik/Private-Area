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

namespace WebApp.Area.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class ProjectTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProjectTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProjectTypes.Include(t => t.ProjectTypeComments)
                .ThenInclude(t => t.Translations).ToListAsync());
        }

        // GET: ProjectTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectType = await _context.ProjectTypes
                .Include(t => t.ProjectTypeComments)
                .ThenInclude(t => t.Translations)
                .SingleOrDefaultAsync(m => m.ProjectTypeId == id);
            if (projectType == null)
            {
                return NotFound();
            }

            return View(projectType);
        }

        // GET: ProjectTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProjectTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProjectTypesVM vm)
        {
            if (ModelState.IsValid)
            {
                vm.ProjectType.ProjectTypeComments = new MultiLangString(vm.ProjectTypeComments);
                _context.Add(vm.ProjectType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        // GET: ProjectTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectType = await _context.ProjectTypes
                .Include(t => t.ProjectTypeComments)
                .ThenInclude(t => t.Translations)
                .SingleOrDefaultAsync(m => m.ProjectTypeId == id);
            if (projectType == null)
            {
                return NotFound();
            }
            var vm = new ProjectTypesVM();
            vm.ProjectTypeComments = projectType.ProjectTypeComments.ToString();
            vm.ProjectType = projectType;
            return View(vm);
        }

        // POST: ProjectTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProjectTypesVM vm)
        {
            if (id != vm.ProjectType.ProjectTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    vm.ProjectType.ProjectTypeComments =
                        _context.MultiLangStrings
                            .Include(t => t.Translations)
                            .FirstOrDefault(m =>
                            m.MultiLangStringId == vm.ProjectType.ProjectTypeCommentsId) ?? new MultiLangString();
                    vm.ProjectType.ProjectTypeComments.SetTranslation(vm.ProjectTypeComments);
                    _context.Update(vm.ProjectType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectTypeExists(vm.ProjectType.ProjectTypeId))
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

        // GET: ProjectTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectType = await _context.ProjectTypes
                .Include(i => i.ProjectTypeComments)
                    .ThenInclude(i => i.Translations)
                .SingleOrDefaultAsync(m => m.ProjectTypeId == id);
            if (projectType == null)
            {
                return NotFound();
            }

            return View(projectType);
        }

        // POST: ProjectTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projectType = await _context.ProjectTypes.Include(t => t.ProjectTypeComments)
                .ThenInclude(t => t.Translations)
                .SingleOrDefaultAsync(m => m.ProjectTypeId == id);
            _context.ProjectTypes.Remove(projectType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectTypeExists(int id)
        {
            return _context.ProjectTypes.Any(e => e.ProjectTypeId == id);
        }
    }
}
