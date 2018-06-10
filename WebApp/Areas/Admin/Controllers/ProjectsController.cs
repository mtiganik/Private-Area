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
    public class ProjectsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectsController(ApplicationDbContext context)
        {
            _context = context;
        }
        


        // GET: Projects
        public async Task<IActionResult> Index(int? id)
        {
            var vm = new ProjectsIndexData();

            vm.Projects = await _context.Projects
                .Include(i => i.ProjectType)
                .Include(i => i.Positions)
                    .ThenInclude(i => i.ApplicationUser)
                .Include(i => i.Positions)
                    .ThenInclude(i => i.PositionName)
                .AsNoTracking()
                .OrderBy(i => i.ProjectStartDate)
                .ToListAsync();


            if (id != null)
            {
                vm.ProjectId = id.Value;
                vm.Positions = _context.Positions.Where(i => i.ProjectId == id.Value)
                    .Include(i => i.ApplicationUser)
                    .Include(i => i.PositionName)
                        .ThenInclude(t => t.PositionNameName)
                            .ThenInclude(t => t.Translations)
                    .Include(i => i.Project);
                vm.SelectedProject = _context.Projects.Where(i => i.ProjectId == id.Value).SingleOrDefault();

            }

            return View(vm);
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .Include(p => p.ProjectType)
                .SingleOrDefaultAsync(m => m.ProjectId == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: Projects/Create
        public IActionResult Create()
        {
            var vm = new ProjectsCreateEditVM();
            vm.ProjectTypeSelectList = new SelectList(_context.ProjectTypes, nameof(ProjectType.ProjectTypeId), nameof(ProjectType.ProjectTypeName));
            return View(vm);
        }

        // POST: Projects/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProjectsCreateEditVM vm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vm.Project);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.ProjectTypeSelectList = new SelectList(_context.ProjectTypes, nameof(ProjectType.ProjectTypeId), nameof(ProjectType.ProjectTypeName), vm.Project.ProjectTypeId);
            return View(vm);
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.SingleOrDefaultAsync(m => m.ProjectId == id);
            if (project == null)
            {
                return NotFound();
            }
            var vm = new ProjectsCreateEditVM();
            vm.Project = project;
            vm.ProjectTypeSelectList = new SelectList(_context.ProjectTypes, nameof(ProjectType.ProjectTypeId), nameof(ProjectType.ProjectTypeName), project.ProjectTypeId);
            return View(vm);
        }

        // POST: Projects/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProjectsCreateEditVM vm)
        {
            if (id != vm.Project.ProjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vm.Project);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(vm.Project.ProjectId))
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
            vm.ProjectTypeSelectList = new SelectList(_context.ProjectTypes, nameof(Project.ProjectTypeId), nameof(Project.ProjectName), vm.Project.ProjectTypeId);
            return View(vm);
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .Include(p => p.ProjectType)
                .SingleOrDefaultAsync(m => m.ProjectId == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var project = await _context.Projects.SingleOrDefaultAsync(m => m.ProjectId == id);
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.ProjectId == id);
        }
    }
}
