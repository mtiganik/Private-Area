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

namespace WebApp.Area.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class ProjectsController : Controller
    {
        //private readonly ApplicationDbContext _context;
        private readonly IAppUnitOfWork _uow;

        public ProjectsController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }
        


        // GET: Projects
        public async Task<IActionResult> Index(int? id)
        {
            var vm = new ProjectsIndexData();

            vm.Projects = await _uow.Projects.AllAsync();

            if (id != null)
            {
                vm.ProjectId = id.Value;
                vm.Positions = await _uow.Positions.GetPositionsForProject(id.Value);
                vm.SelectedProject = await _uow.Projects.GetSingle(id.Value);

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

            var project = await _uow.Projects.GetSingleWithProjectType(id.Value);
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
            vm.ProjectTypeSelectList = new SelectList(_uow.ProjectTypes.All(), nameof(ProjectType.ProjectTypeId), nameof(ProjectType.ProjectTypeName));

            return View(vm);
        }

        // POST: Projects/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProjectsCreateEditVM vm)
        {
            if (ModelState.IsValid)
            {
                _uow.Projects.Add(vm.Project);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.ProjectTypeSelectList = new SelectList(_uow.ProjectTypes.All(), nameof(ProjectType.ProjectTypeId), nameof(ProjectType.ProjectTypeName), vm.Project.ProjectTypeId);
            return View(vm);
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _uow.Projects.GetSingle(id.Value);
            if (project == null)
            {
                return NotFound();
            }
            var vm = new ProjectsCreateEditVM();
            vm.Project = project;
            vm.ProjectTypeSelectList = new SelectList(_uow.ProjectTypes.All(), nameof(ProjectType.ProjectTypeId), nameof(ProjectType.ProjectTypeName), project.ProjectTypeId);
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
                    _uow.Projects.Update(vm.Project);
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!(await _uow.Projects.ExistsByPrimaryKeyAsync(vm.Project.ProjectId)))
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
            vm.ProjectTypeSelectList = new SelectList(_uow.ProjectTypes.All(), nameof(Project.ProjectTypeId), nameof(Project.ProjectName), vm.Project.ProjectTypeId);
            return View(vm);
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _uow.Projects.GetSingleWithProjectType(id.Value);
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
            var project = await _uow.Projects.GetSingle(id);
            _uow.Projects.Remove(project);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
