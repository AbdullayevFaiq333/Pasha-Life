using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PasaLife.DAL;
using PasaLife.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace PasaLife.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _db;

        public ContactController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
           

            var contact = await _db.Contact.FirstOrDefaultAsync();
            ContactModel contactModel = new ContactModel();



            contactModel.Id = contact.Id;
            contactModel.AzTitle = contact.AzTitle;
            contactModel.RuTitle = contact.RuTitle;
            contactModel.EnTitle = contact.EnTitle;
            contactModel.AzAddress = contact.AzAddress;
            contactModel.RuAddress = contact.RuAddress;
            contactModel.EnAddress = contact.EnAddress;
            contactModel.AzDescription = contact.AzDescription;
            contactModel.RuDescription = contact.RuDescription;
            contactModel.EnDescription = contact.EnDescription;
            contactModel.ContactNumber = contact.ContactNumber;


            ViewBag.AzSeoTitle = contact.AzSeoTitle;
            ViewBag.RuSeoTitle = contact.RuSeoTitle;
            ViewBag.EnSeoTitle = contact.EnSeoTitle;
            ViewBag.AzSeoDescription = contact.AzSeoDescription;
            ViewBag.RuSeoDescription = contact.RuSeoDescription;
            ViewBag.EnSeoDescription = contact.EnSeoDescription;

          



            return View(contactModel);
        }
        [HttpPost]
        public async Task<IActionResult> Index(ContactMessage contactMessage)
        {
            var contact = await _db.Contact.FirstOrDefaultAsync();
            ContactModel contactModel = new ContactModel();
            contactModel.Id = contact.Id;
            contactModel.AzTitle = contact.AzTitle;
            contactModel.RuTitle = contact.RuTitle;
            contactModel.EnTitle = contact.EnTitle;
            contactModel.AzDescription = contact.AzDescription;
            contactModel.RuDescription = contact.RuDescription;
            contactModel.EnDescription = contact.EnDescription;
            contactModel.AzAddress = contact.AzAddress;
            contactModel.RuAddress = contact.RuAddress;
            contactModel.EnAddress = contact.EnAddress;
            contactModel.ContactNumber = contact.ContactNumber;
            contactModel.ContactMessage = contactMessage;
            if (ModelState.IsValid)
            {

            }

            return View(contactModel);
        }

        public IActionResult ContactForm()
        {
            return View();
        }

    }
}
