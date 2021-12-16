using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PasaLife.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PasaLife.Controllers
{
    public class StructureController : Controller
    {
        private readonly AppDbContext _db;
        
        public StructureController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            var structure = await _db.Structures.FirstOrDefaultAsync();

            return View(structure);
        }
    }
}
