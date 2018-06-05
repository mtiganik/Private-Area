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
using Microsoft.AspNetCore.Identity;
using WebApp.Areas.Admin.Models;


namespace WebApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class ApplicationUsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _rolesManager;

        //public ApplicationUsersController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}


        public ApplicationUsersController(
            ApplicationDbContext context,
            RoleManager<IdentityRole> roleManager
            )
        {
            _rolesManager = roleManager;
            _context = context;
        }

        // GET: ApplicationUsers
        public async Task<IActionResult> Index()
        {
            //var usersWithRoles = (from user in _context.ApplicationUser
            //                      select new
            //                      {
            //                          UserId = user.Id,
            //                          Username = user.UserName,
            //                          Email = user.Email,
            //                          RoleNames = (from userRole in user.Roles
            //                                       join role in _context.Roles on userRole.RoleId
            //                                       equals role.Id
            //                                       select role.Name).ToList()
            //                      }).ToList().Select(p => new UserRolesViewModel()

            //                      {
            //                          UserId = p.UserId,
            //                          Username = p.Username,
            //                          Email = p.Email,
            //                          Role = string.Join(",", p.RoleNames)
            //                      });


            //return View(usersWithRoles);


            //var vm = new List<UserRolesViewModel>();
            //foreach (ApplicationUser user in _context.ApplicationUser)
            //{
            //    List<string> RoleId = _context.UserRoles.Where(a => a.UserId == user.Id).Select(b => b.RoleId).Distinct().ToList(); ;
            //    vm.Add(new UserRolesViewModel()
            //    {
            //        ApplicationUser = user,
            //        RoleManager = _context.Roles.Where(a => a.Id.Equals(RoleId)).ToList()

            //});
            //}

            //List<string> userids = _context.UserRoles.Where(a => a.RoleId == "").Select(b => b.UserId).Distinct().ToList();
            ////The first step: get all user id collection as userids based on role from db.UserRoles

            //List<ApplicationUser> listUsers = _context.Users.Where(a => userids.Any(c => c == a.Id)).ToList();



            var applicationDbContext = _context.ApplicationUser.Include(a => a.Department).Include(a => a.UserStatus);
            return View(await applicationDbContext.ToListAsync());
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

        // GET: ApplicationUsers/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentId");
            ViewData["UserStatusId"] = new SelectList(_context.UserStatuses, "UserStatusId", "UserStatusId");
            return View();
        }

        // POST: ApplicationUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Address,Skype,Comments,UserStatusId,DepartmentId,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(applicationUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "SpecialityId", "SpecialityId", applicationUser.DepartmentId);
            ViewData["UserStatusId"] = new SelectList(_context.UserStatuses, "UserStatusId", "UserStatusId", applicationUser.UserStatusId);
            return View(applicationUser);
        }

        // GET: ApplicationUsers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUser = await _context.ApplicationUser.SingleOrDefaultAsync(m => m.Id == id);
            if (applicationUser == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentId", applicationUser.DepartmentId);
            ViewData["UserStatusId"] = new SelectList(_context.UserStatuses, "UserStatusId", "UserStatusId", applicationUser.UserStatusId);
            return View(applicationUser);
        }

        // POST: ApplicationUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("FirstName,LastName,Address,Skype,Comments,UserStatusId,DepartmentId,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] ApplicationUser applicationUser)
        {
            if (id != applicationUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(applicationUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationUserExists(applicationUser.Id))
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
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentId", applicationUser.DepartmentId);
            ViewData["UserStatusId"] = new SelectList(_context.UserStatuses, "UserStatusId", "UserStatusId", applicationUser.UserStatusId);
            return View(applicationUser);
        }

        // GET: ApplicationUsers/Delete/5
        public async Task<IActionResult> Delete(string id)
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

        // POST: ApplicationUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var applicationUser = await _context.ApplicationUser.SingleOrDefaultAsync(m => m.Id == id);
            _context.ApplicationUser.Remove(applicationUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationUserExists(string id)
        {
            return _context.ApplicationUser.Any(e => e.Id == id);
        }
    }
}
