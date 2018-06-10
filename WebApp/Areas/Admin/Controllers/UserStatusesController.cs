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
    public class UserStatusesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserStatusesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserStatuses
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserStatuses.Include(t => t.UserStatusName).ThenInclude(t => t.Translations).ToListAsync());
        }

        // GET: UserStatuses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userStatus = await _context.UserStatuses
                .Include(t => t.UserStatusName)
                .ThenInclude(t => t.Translations)
                .SingleOrDefaultAsync(m => m.UserStatusId == id);
            if (userStatus == null)
            {
                return NotFound();
            }

            return View(userStatus);
        }

        // GET: UserStatuses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserStatuses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserStatusVM vm)
        {
            if (ModelState.IsValid)
            {
                vm.UserStatus.UserStatusName = new MultiLangString(vm.UserStatusName);
                _context.Add(vm.UserStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        // GET: UserStatuses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userStatus = await _context.UserStatuses.Include(t => t.UserStatusName).ThenInclude(t => t.Translations).SingleOrDefaultAsync(m => m.UserStatusId == id);
            if (userStatus == null)
            {
                return NotFound();
            }
            var vm = new UserStatusVM();
            vm.UserStatusName = userStatus.UserStatusName.ToString();
            vm.UserStatus = userStatus;

            return View(vm);
        }

        // POST: UserStatuses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UserStatusVM vm)
        {
            if (id != vm.UserStatus.UserStatusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    vm.UserStatus.UserStatusName =
                        _context.MultiLangStrings
                            .Include(t => t.Translations)
                            .FirstOrDefault(m =>
                            m.MultiLangStringId == vm.UserStatus.UserStatusNameId) ?? new MultiLangString();
                    vm.UserStatus.UserStatusName.SetTranslation(vm.UserStatusName);

                    _context.Update(vm.UserStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserStatusExists(vm.UserStatus.UserStatusId))
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
            return View(vm);
        }

        // GET: UserStatuses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userStatus = await _context.UserStatuses
                .Include(t => t.UserStatusName)
                .ThenInclude(t => t.Translations)
                .SingleOrDefaultAsync(m => m.UserStatusId == id);
            if (userStatus == null)
            {
                return NotFound();
            }

            return View(userStatus);
        }

        // POST: UserStatuses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userStatus = await _context.UserStatuses
                .Include(t => t.UserStatusName)
                .ThenInclude(t => t.Translations)
                .SingleOrDefaultAsync(m => m.UserStatusId == id);
            _context.UserStatuses.Remove(userStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserStatusExists(int id)
        {
            return _context.UserStatuses.Any(e => e.UserStatusId == id);
        }
    }
}
