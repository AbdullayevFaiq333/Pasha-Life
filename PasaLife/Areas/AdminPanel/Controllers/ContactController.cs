using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PasaLife.DAL;
using PasaLife.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PasaLife.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize]


    public class ContactController : Controller
    {
        private readonly AppDbContext _db;
        public ContactController(AppDbContext db)
        {
            _db = db;
        }

        #region Index
        public async Task<IActionResult> Index()
        {

            List<Contact> contacts = await _db.Contact.ToListAsync();
            return View(contacts);

        }
        #endregion

        #region Detail
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
                return NotFound();

            var contact = await _db.Contact.FindAsync(id);
            return View(contact);
        }
        #endregion

        #region Update
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();
            Contact contact = await _db.Contact.FirstOrDefaultAsync(x => x.Id == id);
            if (contact == null)
                return NotFound();
            return View(contact);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Contact contact)
        {
            if (!ModelState.IsValid)
                return NotFound();
            if (id == null)
                return NotFound();
            Contact dbContact = await _db.Contact.FirstOrDefaultAsync(x => x.Id == id);
            if (dbContact == null)
                return NotFound();
            dbContact.AzTitle = contact.AzTitle;
            dbContact.RuTitle = contact.RuTitle;
            dbContact.EnTitle = contact.EnTitle;
            dbContact.AzDescription = contact.AzDescription;
            dbContact.RuDescription = contact.RuDescription;
            dbContact.EnDescription = contact.EnDescription;
            dbContact.AzAddress = contact.AzAddress;
            dbContact.RuAddress = contact.RuAddress;
            dbContact.EnAddress = contact.EnAddress;
            dbContact.ContactNumber = contact.ContactNumber;

            dbContact.AzSeoTitle = contact.AzSeoTitle;
            dbContact.RuSeoTitle = contact.RuSeoTitle;
            dbContact.EnSeoTitle = contact.EnSeoTitle;
            dbContact.AzSeoDescription = contact.AzSeoDescription;
            dbContact.RuSeoDescription = contact.RuSeoDescription;
            dbContact.EnSeoDescription = contact.EnSeoDescription;

            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        #endregion

    }
}
