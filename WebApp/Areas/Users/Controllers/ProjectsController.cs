﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain;
using Microsoft.AspNetCore.Authorization;
using WebApp.Areas.Users.Models;
using DAL.App.Interfaces;

namespace WebApp.Areas.Users.Controllers
{
    [Authorize(Roles ="User, Marketer")]
    [Area("Users")]
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
            var vm = new ProjectsIndexViewModel();
            vm.Projects = await _uow.Projects.AllAsync();
                //_context.Projects
                //.Include(i => i.ProjectType)
                //.Include(i => i.Positions)
                //.OrderByDescending(i => i.ProjectStartDate)
                //.AsNoTracking()
                //.ToListAsync();

            if(id != null)
            {
                vm.SelectedProject = await _uow.Projects.GetSingle(id.Value);
                //_context.Projects.Where(i => i.ProjectId == id).SingleOrDefaultAsync();
                vm.Positions = await _uow.Positions.GetPositionsForProject(id.Value);
                    //_context.Positions.Where(i => i.ProjectId == id)
                    //.Include(i => i.ApplicationUser)
                    //.Include(i => i.PositionName)
                    //    .ThenInclude(i => i.PositionNameName)
                    //        .ThenInclude(i => i.Translations)
                    //.AsNoTracking()
                    //.ToListAsync();
                vm.ProjectsId = id.Value;

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
            var vm = new ProjectDetailsViewModel();
            vm.SelectedProject = await _uow.Projects.GetSingleEnhancedAsync(id.Value);


                //_context.Projects.Where(U => U.ProjectId == id)
                //.Include(i => i.Positions)
                //    .ThenInclude(i => i.PositionName)
                //        .ThenInclude(i => i.PositionNameName)
                //            .ThenInclude(i => i.Translations)
                //.Include(i => i.Positions)
                //    .ThenInclude(i => i.ApplicationUser)
                //.Include(i => i.ProjectType)
                //.Include(i => i.CompanyProjects)
                //    .ThenInclude(i => i.Company)
                //.SingleOrDefaultAsync();

            if (vm.SelectedProject == null)
            {
                return NotFound();
            }

            vm.CompaniesSelectList = new SelectList(_uow.Companies.All(), nameof(Company.CompanyId), nameof(Company.CompanyName) );
            return View(vm);
        }

        // GET: Projects/Create
        //public IActionResult Create()
        //{
        //    ViewData["ProjectTypeId"] = new SelectList(_context.ProjectTypes, "ProjectTypeId", "ProjectTypeId");
        //    return View();
        //}

        // POST: Projects/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("ProjectId,ProjectName,ProjectNameEst,ProjectStartDate,ProjectEndDate,ProjectTypeId")] Project project)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(project);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["ProjectTypeId"] = new SelectList(_context.ProjectTypes, "ProjectTypeId", "ProjectTypeId", project.ProjectTypeId);
        //    return View(project);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCompanyProject(int id, [Bind("CompanyId,ProjectId")] CompanyProject companyProject)
        {
            if (ModelState.IsValid)
            {
                companyProject.ProjectId = id;
                _uow.CompanyProjects.Add(companyProject);
                await _uow.SaveChangesAsync();
                return  RedirectToAction("Details", new {  id });
            }
            ViewData["CompanyId"] = new SelectList(_uow.Companies.All(), "CompanyId", "CompanyId", companyProject.CompanyId);
            ViewData["ProjectId"] = new SelectList(_uow.Projects.All(), "ProjectId", "ProjectId", companyProject.ProjectId);
            return View(companyProject);
        }


        // GET: Projects/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var project = await _context.Projects.SingleOrDefaultAsync(m => m.ProjectId == id);
        //    if (project == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["ProjectTypeId"] = new SelectList(_context.ProjectTypes, "ProjectTypeId", "ProjectTypeId", project.ProjectTypeId);
        //    return View(project);
        //}

        // POST: Projects/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("ProjectId,ProjectName,ProjectNameEst,ProjectStartDate,ProjectEndDate,ProjectTypeId")] Project project)
        //{
        //    if (id != project.ProjectId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(project);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ProjectExists(project.ProjectId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["ProjectTypeId"] = new SelectList(_context.ProjectTypes, "ProjectTypeId", "ProjectTypeId", project.ProjectTypeId);
        //    return View(project);
        //}

        // GET: Projects/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var project = await _context.Projects
        //        .Include(p => p.ProjectType)
        //        .SingleOrDefaultAsync(m => m.ProjectId == id);
        //    if (project == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(project);
        //}

        //// POST: Projects/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var project = await _context.Projects.SingleOrDefaultAsync(m => m.ProjectId == id);
        //    _context.Projects.Remove(project);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool ProjectExists(int id)
        //{
        //    return _context.Projects.Any(e => e.ProjectId == id);
        //}
    }
}
