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
    public class PositionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PositionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Positions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Positions.Include(p => p.PositionName).Include(p => p.Project);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Positions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var position = await _context.Positions
                .Include(p => p.PositionName)
                .Include(p => p.Project)
                .SingleOrDefaultAsync(m => m.PositionId == id);
            if (position == null)
            {
                return NotFound();
            }

            return View(position);
        }

        // GET: Positions/Create
        public IActionResult Create(int? projectId)
        {
            var vm = new PositionCreateEditViewModel();
            //vm.PositionNameSelectList = new SelectList(_context.PositionNames, nameof(PositionName.PositionNameId), nameof(PositionName.PositionNameName));
            vm.PositionNameSelectList = new SelectList(_context.PositionNames.Include(t => t.PositionNameName).ThenInclude(t => t.Translations), nameof(PositionName.PositionNameId), nameof(PositionName.PositionNameName));

            if (projectId != null)
            {
                vm.ProjectsSelectList = new SelectList(_context.Projects.Where(u => u.ProjectId == projectId), nameof(Project.ProjectId), nameof(Project.ProjectName));
            }
            else
            {
                vm.ProjectsSelectList = new SelectList(_context.Projects, nameof(Project.ProjectId), nameof(Project.ProjectName));

            }
            vm.ApplicationUserSelectList = new SelectList(_context.ApplicationUser, nameof(ApplicationUser.Id), nameof(ApplicationUser.FullName));


            return View(vm);
        }

        // POST: Positions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PositionCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vm.Position);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Projects", new { id = vm.Position.ProjectId });
            }
            vm.ProjectsSelectList = new SelectList(_context.Projects, "ProjectId", "ProjectName", vm.Position.ProjectId);
            vm.ApplicationUserSelectList = new SelectList(_context.ApplicationUser, "Id", "FullName", vm.Position.ApplicationUserId);

            return View(vm);
        }

        // GET: Positions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var vm = new PositionCreateEditViewModel();
            vm.Position = await _context.Positions.SingleOrDefaultAsync(m => m.PositionId == id);
            //var position = await _context.Positions.SingleOrDefaultAsync(m => m.PositionId == id);
            if (vm.Position == null)
            {
                return NotFound();
            }
            vm.PositionNameSelectList = new SelectList(_context.PositionNames.Include(t => t.PositionNameName).ThenInclude(t => t.Translations), nameof(PositionName.PositionNameId), nameof(PositionName.PositionNameName));
            vm.ProjectsSelectList = new SelectList(_context.Projects, "ProjectId", "ProjectName", vm.Position.ProjectId);
            vm.ApplicationUserSelectList = new SelectList(_context.ApplicationUser, "Id", "FullName", vm.Position.ApplicationUserId);
            return View(vm);
        }

        // POST: Positions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PositionCreateEditViewModel vm)
        {
            if (id != vm.Position.PositionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vm.Position);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PositionExists(vm.Position.PositionId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Projects", new { id = vm.Position.ProjectId });
            }
            vm.PositionNameSelectList = new SelectList(_context.PositionNames.Include(t => t.PositionNameName).ThenInclude(t => t.Translations), nameof(PositionName.PositionNameId), nameof(PositionName.PositionNameName));
            vm.ProjectsSelectList = new SelectList(_context.Projects, "ProjectId", "ProjectName", vm.Position.ProjectId);
            vm.ApplicationUserSelectList = new SelectList(_context.ApplicationUser, "Id", "FullName", vm.Position.ApplicationUserId);

            return View(vm);
        }

        // GET: Positions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var position = await _context.Positions
                .Include(p => p.PositionName)
                .Include(p => p.Project)
                .SingleOrDefaultAsync(m => m.PositionId == id);
            if (position == null)
            {
                return NotFound();
            }

            return View(position);
        }

        // POST: Positions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var position = await _context.Positions.SingleOrDefaultAsync(m => m.PositionId == id);
            _context.Positions.Remove(position);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PositionExists(int id)
        {
            return _context.Positions.Any(e => e.PositionId == id);
        }
    }
}
