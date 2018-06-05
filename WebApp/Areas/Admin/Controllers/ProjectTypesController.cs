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
            return View(await _context.ProjectTypes.ToListAsync());
        }

        // GET: ProjectTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectType = await _context.ProjectTypes
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectTypeId,ProjectTypeName,ProjectTypeNameEst,ProjectTypeComments,ProjectTypeCommentsEst")] ProjectType projectType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projectType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(projectType);
        }

        // GET: ProjectTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectType = await _context.ProjectTypes.SingleOrDefaultAsync(m => m.ProjectTypeId == id);
            if (projectType == null)
            {
                return NotFound();
            }
            return View(projectType);
        }

        // POST: ProjectTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProjectTypeId,ProjectTypeName,ProjectTypeNameEst,ProjectTypeComments,ProjectTypeCommentsEst")] ProjectType projectType)
        {
            if (id != projectType.ProjectTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectTypeExists(projectType.ProjectTypeId))
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
            return View(projectType);
        }

        // GET: ProjectTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectType = await _context.ProjectTypes
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
            var projectType = await _context.ProjectTypes.SingleOrDefaultAsync(m => m.ProjectTypeId == id);
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
