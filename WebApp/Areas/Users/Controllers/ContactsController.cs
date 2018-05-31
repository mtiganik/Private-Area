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
using System.Threading;

namespace WebApp.Areas.Users.Controllers
{
    //[Authorize(Roles = "Marketer, Admin")]
    [Area("Users")]
    public class ContactsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactsController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        // GET: Contacts/Edit/5
        public async Task<IActionResult> Edit(int? id, int? fromProject)
        {
            if (id == null)
            {
                return NotFound();
            }
            if(fromProject != null)
            {
                ViewBag.fromProject = fromProject;
            }

            var contact = await _context.Contacts.SingleOrDefaultAsync(m => m.ContactId == id);
            if (contact == null)
            {
                return NotFound();
            }
            ViewData["CompanyWorkerSelectList"] = new SelectList(_context.CompanyWorkers.Where(u => u.CompanyId == contact.ProjectId), "CompanyWorkerId", "WorkerName",contact.CompanyWorkerId);
            ViewData["ProjectSelectList"] = new SelectList(_context.Projects, "ProjectId", IsEnglish() ? "ProjectName" : "ProjectNameEst", contact.ProjectId);
            ViewData["ContactTypeSelectList"] = new SelectList(_context.ContactTypes, "ContactTypeId", IsEnglish() ? "ContactTypeName" : "ContactTypeNameEst", contact.ContactTypeId);

            return View(contact);
        }

        // POST: Contacts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,int? fromProject, [Bind("ContactId,ContactTypeId,ApplicationUserId,CompanyId,CompanyWorkerId,ProjectId,IsNewContactNeeded,NewContactDate,NewContactType,Comments")] Contact contact)
        {
            if (id != contact.ContactId)
            {
                return NotFound();
            }
            contact.ContactDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactExists(contact.ContactId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                if(fromProject != null)
                {
                    return RedirectToAction("Details", "Companies", new { id = fromProject });
                }
                return RedirectToAction("Index", "Companies");
            }
            //ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "CompanyId", contact.CompanyId);
            ViewData["ContactTypeId"] = new SelectList(_context.ContactTypes, "ContactTypeId", "ContactTypeId", contact.ContactTypeId);
            return View(contact);
        }

        // GET: Contacts/Delete/5
        public async Task<IActionResult> Delete(int? id, int? fromProject)
        {
            if (id == null)
            {
                return NotFound();
            }
            if(fromProject != null)
            {
                ViewBag.fromProject = fromProject;
            }

            var contact = await _context.Contacts
                .Include(c => c.ContactType)
                .SingleOrDefaultAsync(m => m.ContactId == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, int? fromProject)
        {
            var contact = await _context.Contacts.SingleOrDefaultAsync(m => m.ContactId == id);
            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Companies", new { id = fromProject });
        }

        private bool ContactExists(int id)
        {
            return _context.Contacts.Any(e => e.ContactId == id);
        }

        private bool IsEnglish()
        {
            if (Thread.CurrentThread.CurrentUICulture.Name.ToString() == "en-GB")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
