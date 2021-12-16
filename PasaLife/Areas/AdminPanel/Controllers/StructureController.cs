using AdminPanel;
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


    public class StructureController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public StructureController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        #region Index
        public IActionResult Index()
        {
            var structures = _db.Structures.ToList();
            return View(structures);
        }
        #endregion

        #region Update

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();
            Structure structure = await _db.Structures.FirstOrDefaultAsync(x => x.Id == id);
            if (structure == null)
                return NotFound();

            return View(structure);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id,  Structure structure)
        {
            if (!ModelState.IsValid)
                return NotFound();
            if (id == null)
                return NotFound();
            Structure dbStructure = await _db.Structures.FirstOrDefaultAsync(x => x.Id == id);
            if (dbStructure == null)
                return NotFound();

            if (structure.Photo!=null)
            {

            if (!structure.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Select photo.");
                return View();
            }

            if (!structure.Photo.IsSizeAllowed(2048))
            {
                ModelState.AddModelError("Photo", "Max size is 2 MB.");
                return View();
            }
            var path = Path.Combine(_env.WebRootPath, "images", dbStructure.Image);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }


            var imgPath = Path.Combine(_env.WebRootPath, "images");
            var fileName = await FileUtil.GenerateFileAsync(imgPath, structure.Photo);
            structure.Image = fileName;
            dbStructure.Image = structure.Image;
            }



            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        #endregion





    }
}
