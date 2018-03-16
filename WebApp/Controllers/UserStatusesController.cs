using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain;

namespace WebApp.Controllers
{
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
            return View(await _context.UserStatuses.ToListAsync());
        }

        // GET: UserStatuses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userStatus = await _context.UserStatuses
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserStatusId,UserStatusName,UserStatusNameEst")] UserStatus userStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userStatus);
        }

        // GET: UserStatuses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userStatus = await _context.UserStatuses.SingleOrDefaultAsync(m => m.UserStatusId == id);
            if (userStatus == null)
            {
                return NotFound();
            }
            return View(userStatus);
        }

        // POST: UserStatuses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserStatusId,UserStatusName,UserStatusNameEst")] UserStatus userStatus)
        {
            if (id != userStatus.UserStatusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserStatusExists(userStatus.UserStatusId))
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
            return View(userStatus);
        }

        // GET: UserStatuses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userStatus = await _context.UserStatuses
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
            var userStatus = await _context.UserStatuses.SingleOrDefaultAsync(m => m.UserStatusId == id);
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
