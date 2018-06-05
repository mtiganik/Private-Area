using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain;
using WebApp.Areas.Admin.Models;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/ContactTypes
        public async Task<IActionResult> Index()
        {
            var res = _context.ContactTypes.Include(i => i.ContactTypeName).ThenInclude(i => i.Translations);
            return View(await res.ToListAsync());
        }

        // GET: Admin/ContactTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactType = await _context.ContactTypes.Include(i => i.ContactTypeName).ThenInclude(i => i.Translations)
                .SingleOrDefaultAsync(m => m.ContactTypeId == id);
            if (contactType == null)
            {
                return NotFound();
            }

            return View(contactType);
        }

        // GET: Admin/ContactTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/ContactTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ContactTypeCreateEditVM vm)
        {
            if (ModelState.IsValid)
            {
                vm.ContactType.ContactTypeName = new MultiLangString(vm.ContactTypeName);
                _context.Add(vm.ContactType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        // GET: Admin/ContactTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactType = await _context.ContactTypes
                .Include(i => i.ContactTypeName)
                    .ThenInclude(i => i.Translations)
                .SingleOrDefaultAsync(m => m.ContactTypeId == id);
            if (contactType == null)
            {
                return NotFound();
            }
            return View(contactType);
        }

        // POST: Admin/ContactTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ContactTypeCreateEditVM vm)
        {
            if (id != vm.ContactType.ContactTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    vm.ContactType.ContactTypeName =
                        _context.MultiLangStrings
                            .Include(t => t.Translations)
                            .FirstOrDefault(m => m.MultiLangStringId == vm.ContactType.ContactTypeNameId) ?? new MultiLangString();
                    vm.ContactType.ContactTypeName.SetTranslation(vm.ContactTypeName);
                    _context.Update(vm.ContactType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactTypeExists(vm.ContactType.ContactTypeId))
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

        // GET: Admin/ContactTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactType = await _context.ContactTypes
                .SingleOrDefaultAsync(m => m.ContactTypeId == id);
            if (contactType == null)
            {
                return NotFound();
            }

            return View(contactType);
        }

        // POST: Admin/ContactTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contactType = await _context.ContactTypes.SingleOrDefaultAsync(m => m.ContactTypeId == id);
            _context.ContactTypes.Remove(contactType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactTypeExists(int id)
        {
            return _context.ContactTypes.Any(e => e.ContactTypeId == id);
        }
    }
}
