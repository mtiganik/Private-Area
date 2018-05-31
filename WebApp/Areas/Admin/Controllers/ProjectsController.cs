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
                ViewData["ProjectId"] = id.Value;
                vm.Positions = _context.Positions.Where(i => i.ProjectId == id.Value)
                    .Include(i => i.ApplicationUser)
                    .Include(i => i.PositionName)
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
            ViewData["ProjectTypeId"] = new SelectList(_context.ProjectTypes, "ProjectTypeId", "ProjectTypeName");
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectId,ProjectName,ProjectNameEst,ProjectStartDate,ProjectEndDate,ProjectTypeId")] Project project)
        {
            if (ModelState.IsValid)
            {
                _context.Add(project);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectTypeId"] = new SelectList(_context.ProjectTypes, "ProjectTypeId", "ProjectTypeId", project.ProjectTypeId);
            return View(project);
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
            ViewData["ProjectTypeId"] = new SelectList(_context.ProjectTypes, "ProjectTypeId", "ProjectTypeName", project.ProjectTypeId);
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProjectId,ProjectName,ProjectNameEst,ProjectStartDate,ProjectEndDate,ProjectTypeId")] Project project)
        {
            if (id != project.ProjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(project);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.ProjectId))
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
            ViewData["ProjectTypeId"] = new SelectList(_context.ProjectTypes, "ProjectTypeId", "ProjectTypeName", project.ProjectTypeId);
            return View(project);
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
