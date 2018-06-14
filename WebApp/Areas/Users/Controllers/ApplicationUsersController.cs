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
using WebApp.Areas.Users.Models;
using System.Threading;

namespace WebApp.Areas.Users.Controllers
{
    [Authorize(Roles = "User, Marketer")]
    [Area("Users")]
    public class ApplicationUsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ApplicationUsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ApplicationUsers
        public async Task<IActionResult> Index(string user)
        {
            var vm = new UsersIndexData();
            vm.ApplicationUsers = _context.ApplicationUser
                .Include(i => i.Positions)
                .Include(i => i.Department)
                    .ThenInclude(i => i.DepartmentName)
                        .ThenInclude(i => i.Translations)
                .Include(i => i.UserStatus)
                    .ThenInclude(i => i.UserStatusName)
                        .ThenInclude(i => i.Translations);

            if (user != null)
            {
                vm.Positions = await _context.Positions.Where(u => u.ApplicationUser.UserName == user)
                    .Include(i => i.Project)
                        .ThenInclude(i => i.ProjectType)
                            .ThenInclude(i => i.ProjectTypeComments)
                                .ThenInclude(i => i.Translations)
                    .Include(i => i.PositionName)
                        .ThenInclude(i => i.PositionNameName)
                            .ThenInclude(i => i.Translations)
                    .Include(i => i.ApplicationUser)
                    .OrderByDescending(i => i.Project.ProjectStartDate)
                    .AsNoTracking()
                    .ToListAsync();

                vm.SelectedApplicationUser = await _context.ApplicationUser.Where(i => i.UserName == user).SingleOrDefaultAsync();

                vm.UserName = user;
                //ViewData["UserName"] = user;

            }

            return View(vm);
        }

        // GET: ApplicationUsers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUser = await _context.ApplicationUser
                .Include(a => a.Department)
                    .ThenInclude(i => i.DepartmentName)
                        .ThenInclude(i => i.Translations)
                .Include(a => a.UserStatus)
                    .ThenInclude(i => i.UserStatusName)
                        .ThenInclude(i => i.Translations)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (applicationUser == null)
            {
                return NotFound();
            }

            return View(applicationUser);
        }

        
        // GET: ApplicationUsers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var vm = new UsersEditVM();
            vm.ApplicationUser = await _context.ApplicationUser.Where(u => u.Id == id).SingleOrDefaultAsync();

            if (vm.ApplicationUser == null)
            {
                return NotFound();
            }
            vm.DepartmentSelectList =  new SelectList(_context.Departments.Include(t => t.DepartmentName).ThenInclude(t => t.Translations), nameof(Department.DepartmentId), nameof(Department.DepartmentName), vm.ApplicationUser.DepartmentId);
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, UsersEditVM vm)
        {
            if (id != vm.ApplicationUser.Id 
                || _context.ApplicationUser.Where(u=> u.Id == id).Select(u=> u.UserStatusId).Single() 
                != vm.ApplicationUser.UserStatusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vm.ApplicationUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationUserExists(vm.ApplicationUser.Id))
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
            vm.DepartmentSelectList = new SelectList(_context.Departments.Include(t => t.DepartmentName).ThenInclude(t => t.Translations), nameof(Department.DepartmentId), nameof(Department.DepartmentName), vm.ApplicationUser.DepartmentId);
            return View(vm);
        }
        
        
        private bool ApplicationUserExists(string id)
        {
            return _context.ApplicationUser.Any(e => e.Id == id);
        }
    }
}
