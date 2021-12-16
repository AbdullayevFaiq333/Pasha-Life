using AdminPanel.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PasaLife.DAL;
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


    public class IconButtonController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;

        public IconButtonController(AppDbContext db, IWebHostEnvironment _env)
        {
            _db = db;
            this._env = _env;
        }

        #region Index
        public async Task<IActionResult> Index()
        {

            List<IconButton> iconButtons = await _db.IconButtons.ToListAsync();
            return View(iconButtons);

        }
        #endregion

        #region Update
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();
            IconButton iconButton = await _db.IconButtons.FirstOrDefaultAsync(x => x.Id == id);
            if (iconButton == null)
                return NotFound();
            return View(iconButton);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, IconButton iconButton)
        {
            if (!ModelState.IsValid)
                return NotFound();
            if (id == null)
                return NotFound();
            IconButton dbIconButton = await _db.IconButtons.FirstOrDefaultAsync(x => x.Id == id);
            if (dbIconButton == null)
                return NotFound();

            if (iconButton.Icon != null)
            {
                if (!iconButton.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Select photo.");
                    return View();
                }

                if (!iconButton.Photo.IsSizeAllowed(2048))
                {
                    ModelState.AddModelError("Photo", "Max size is 2 MB.");
                    return View();
                }

                var path = Path.Combine(_env.WebRootPath, "style", "img", dbIconButton.Icon);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }


                var imgPath = Path.Combine(_env.WebRootPath, "style", "img");
                var fileName = await FileUtil.GenerateFileAsync(imgPath, iconButton.Photo);
                iconButton.Icon = fileName;

                dbIconButton.Icon = iconButton.Icon;


            }






            dbIconButton.AzName= iconButton.AzName;
            dbIconButton.RuName = iconButton.RuName;
            dbIconButton.EnName = iconButton.EnName;            
            dbIconButton.URL = iconButton.URL;

            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        #endregion     


    }
}
