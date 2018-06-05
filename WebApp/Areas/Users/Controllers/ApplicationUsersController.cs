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
                .Include(i => i.UserStatus);

            if (user != null)
            {
                vm.Positions = await _context.Positions.Where(u => u.ApplicationUser.UserName == user)
                    .Include(i => i.Project)
                        .ThenInclude(i => i.ProjectType)
                    .Include(i => i.PositionName)
                    .Include(i => i.ApplicationUser)
                    .OrderByDescending(i => i.Project.ProjectStartDate)
                    .AsNoTracking()
                    .ToListAsync();

                vm.SelectedApplicationUser = await _context.ApplicationUser.Where(i => i.UserName == user).SingleOrDefaultAsync();

                ViewData["UserName"] = user;

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
                .Include(a => a.UserStatus)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (applicationUser == null)
            {
                return NotFound();
            }

            return View(applicationUser);
        }

        
        private bool IsEnglish()
        {
            if(Thread.CurrentThread.CurrentUICulture.Name.ToString() == "en-GB")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // GET: ApplicationUsers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var vm = new UserEditViewModel();
            vm.ApplicationUser = await _context.ApplicationUser.Where(u => u.Id == id).SingleOrDefaultAsync();

            //var applicationUser = await _context.ApplicationUser.SingleOrDefaultAsync(m => m.Id == id);
            if (vm.ApplicationUser == null)
            {
                return NotFound();
            }
            vm.DepartmentSelectList =  new SelectList(_context.Departments, "DepartmentId", IsEnglish() ? "DepartmentName" : "DepartmentNameEst", vm.ApplicationUser.DepartmentId);
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(string id, [Bind("FirstName,LastName,Address,Skype,Comments,UserStatusId,DepartmentId,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] ApplicationUser applicationUser)
        public async Task<IActionResult> Edit(string id, UserEditViewModel vm)
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
                    //vm.ApplicationUser.UserName = vm.ApplicationUser.Email;
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
            vm.DepartmentSelectList = new SelectList(_context.Departments, "DepartmentId", IsEnglish() ? "DepartmentName" : "DepartmentNameEst", vm.ApplicationUser.DepartmentId);
            return View(vm);
        }
        
        
        private bool ApplicationUserExists(string id)
        {
            return _context.ApplicationUser.Any(e => e.Id == id);
        }
    }
}
