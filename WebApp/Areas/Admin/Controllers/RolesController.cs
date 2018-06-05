using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.App.EF;
using System.Data.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain;
using WebApp.Controllers;
using Microsoft.AspNetCore.Authorization;
using WebApp.Areas.Admin.Models;

namespace WebApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class RolesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _rolesManager;

        public RolesController(ApplicationDbContext context, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _rolesManager = roleManager;
        }

        public UserManager<ApplicationUser> UserManager { get; private set; }


        //
        // GET: /Roles/
        public ActionResult Index()
        {
            var roles = _context.Roles.ToList();
            return View(roles);
        }




        //
        // GET: /Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Roles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IdentityRole identity)
        {

            if (ModelState.IsValid)
            {
                _context.Add(identity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }



        //
        // GET: /Roles/Delete/5
        public ActionResult Delete(string RoleName)
        {
            var thisRole = _context.Roles.Where(r => r.Name.Equals(RoleName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            _context.Roles.Remove(thisRole);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ManageUserRoles()
        {
            var vm = CreateViewModel("");
                
            return View(vm);
        }

        private UserRolesViewModel CreateViewModel ( string ResultMessage)
        {
            var vm = new UserRolesViewModel();
            vm.RoleList = _context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            vm.ApplicationUsersList = _context.ApplicationUser.OrderBy(r => r.UserName).ToList().Select(u => new SelectListItem { Value = u.UserName.ToString(), Text = u.UserName }).ToList();
            vm.ResultMessage = ResultMessage;

            return vm;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetRoles(string UserName)
        {
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                ApplicationUser user = _context.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                var vm = CreateViewModel("");
                var userRoles = _context.UserRoles.Where(u => u.UserId == user.Id).Select(u => u.RoleId).ToList();


             
                    
                List<string> RolesList = new List<String>();

                
                foreach (string role in userRoles)
                {
                    RolesList.Add(_context.Roles.Where(u => u.Id == role).Select(u => u.Name).SingleOrDefault());

                }


                ViewBag.RolesForThisUser = RolesList;

                return View("ManageUserRoles", vm);

            }

            return View("ManageUserRoles");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RoleAddToUser(string UserName, string RoleName)
        {
            try
            {
                ApplicationUser user = _context.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                var roleId = _context.Roles.Where(u => u.Name == RoleName).Select(u => u.Id).Single();
                var identityUserRole = new IdentityUserRole<string>
                {
                    RoleId = roleId,
                    UserId = user.Id
                };
                _context.UserRoles.AddAsync(identityUserRole);
                _context.SaveChangesAsync();
                ViewBag.ResultMessage = "Role created successfully !";
            }
            catch (DbUpdateException)
            {
                throw;
            }

            return View("/Areas/Admin/Views/Home/Index.cshtml");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRoleForUser(string UserName, string RoleName)
        {
            // var account = new AccountController();
            ApplicationUser user = _context.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            var roleId = _context.Roles.Where(u => u.Name == RoleName).Select(u => u.Id).Single();
            var identityUserRole = new IdentityUserRole<string>
            {
                RoleId = roleId,
                UserId = user.Id
            };
            if (  _context.UserRoles.Where(i => i.UserId == identityUserRole.UserId).Select(i => i.RoleId == identityUserRole.RoleId) == null)
            {
                ViewBag.ResultMessage = "User " + UserName + " does not have a role in " + RoleName + "!";
                return View("/Areas/Admin/Views/Home/Index.cshtml");
            }
            else
            {
                try
                {
                    _context.UserRoles.Remove(identityUserRole);
                    _context.SaveChangesAsync();
                    ViewBag.ResultMessage = "User " + UserName + " succesfully removed from " + RoleName + "!";
                    return View("/Areas/Admin/Views/Home/Index.cshtml");
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }
        }
    }
}