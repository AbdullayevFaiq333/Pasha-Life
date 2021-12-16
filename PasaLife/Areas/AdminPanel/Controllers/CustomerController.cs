using AdminPanel.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PasaLife.DAL;
using PasaLife.Helpers;
using PasaLife.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PasaLife.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize]



    public class CustomerController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public CustomerController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        #region Index
        public async Task<IActionResult> Index()
        {
            List<Customer> customers = await _db.Customers.ToListAsync();
            return View(customers);
        }
        #endregion

        #region Detail
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
                return NotFound();

            var customer = await _db.Customers.FindAsync(id);
            return View(customer);
        }
        #endregion

        #region Create
        public IActionResult Create(int? proId)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int proId, Customer customer)
        {
            if (!ModelState.IsValid)
                return NotFound();

            if (customer.Photo == null)
            {
                ModelState.AddModelError("Photo", "Photo cannot be empty");
                return View();
            }
            if (!customer.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "You must choose only Image");
                return View();
            }
            if (!customer.Photo.IsSizeAllowed(2048))
            {
                ModelState.AddModelError("Photo", "Image size can be 2 MB");
                return View();
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            var imgPath = Path.Combine(_env.WebRootPath, "images");
            var fileName = await FileUtil.GenerateFileAsync(imgPath, customer.Photo);
            customer.Image = fileName;
            customer.ProductId= proId;



            await _db.AddRangeAsync(customer);
            await _db.SaveChangesAsync();

            return RedirectToAction("Index", "Product");

        }
        #endregion

        #region Update
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();
            Customer customer = await _db.Customers.FirstOrDefaultAsync(x => x.Id == id);
            if (customer == null)
                return NotFound();

            return View(customer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id,Customer customer)
        {
            if (!ModelState.IsValid)
                return NotFound();
            if (id == null)
                return NotFound();
            Customer dBcustomer = await _db.Customers.FirstOrDefaultAsync(x => x.Id == id);
            if (dBcustomer == null)
                return NotFound();



            if (customer.Photo!=null)
            {

            if (!customer.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Select photo.");
                return View();
            }

            if (!customer.Photo.IsSizeAllowed(2048))
            {
                ModelState.AddModelError("Photo", "Max size is 2 MB.");
                return View();
            }
            var path = Path.Combine(_env.WebRootPath, "images", dBcustomer.Image);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

                var imgPath = Path.Combine(_env.WebRootPath, "images");
                var fileName = await FileUtil.GenerateFileAsync(imgPath, customer.Photo);
                customer.Image = fileName;

                dBcustomer.Image = customer.Image;

            }


            dBcustomer.Name = customer.Name;
            dBcustomer.Work = customer.Work;
            dBcustomer.AzDescription = customer.AzDescription;
            dBcustomer.RuDescription = customer.RuDescription;
            dBcustomer.EnDescription = customer.EnDescription;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Product");

        }
        #endregion
         
        #region Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            Customer customer = await _db.Customers.FirstOrDefaultAsync(x => x.Id == id);
            if (customer == null)
                return NotFound();
            customer.IsDeactive = true;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Product");
        }
        public async Task<IActionResult> Activate(int? id)
        {
            if (id == null)
                return NotFound();
            Customer customer = await _db.Customers.FirstOrDefaultAsync(x => x.Id == id);
            if (customer == null)
                return NotFound();
            customer.IsDeactive = false;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Product");

        }
        #endregion

        #region Remove
        public async Task<IActionResult> Remove(int? id)
        {
            if (id == null)
                return NotFound();

            var customer = await _db.Customers.FindAsync(id);

            if (customer == null) 
                return NotFound();

            _db.Customers.Remove(customer);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Product");
        }
        #endregion

    }
}
