using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PasaLife.DAL;
using PasaLife.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PasaLife.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _db;

        public ProductController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            List<Product> products = await _db.Products.Where(x => x.IsDeactive == false).ToListAsync();
            return View(products);
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Product product = await _db.Products.Include(x => x.FAQs)
                .Include(x => x.Customers).Include(x => x.Partners)
                .Include(x => x.ProductCharts).Include(x => x.ProductDetailTitle)
                .Include(x => x.ProductInformation).Include(x => x.SimpleProduct).Include(x=>x.ProductWords)
                .Include(x=>x.ProductItem1).Include(x => x.ProductItem2).Include(x=>x.ProductItem3)
                .Include(x=>x.ProductItem4).Include(x => x.ProductItem5)
                .FirstOrDefaultAsync(x => x.Id == id);

            ViewBag.AzSeoTitle = product.AzSeoTitle;
            ViewBag.RuSeoTitle = product.RuSeoTitle;
            ViewBag.EnSeoTitle = product.EnSeoTitle;
            ViewBag.AzSeoDescription = product.AzSeoDescription;
            ViewBag.RuSeoDescription = product.RuSeoDescription;
            ViewBag.EnSeoDescription = product.EnSeoDescription;

         

            if (product == null)
            {
                return BadRequest();
            }
            List<Product> products = await _db.Products.Where(x => x.IsDeactive == false).OrderByDescending(x=>x.Id).ToListAsync();
            var testIndexOf = products.IndexOf(product);
            bool cvalue = false;
            int? nextId = 0;
            bool isNextSimple = false;
            var nextAzName = "";
            var nextRuName = "";
            var nextEnName = "";

            if (products[0].Id == id)
            {
                cvalue = true;
            }
           
            else
            {
                Product nextProduct = products[testIndexOf-1];
                if (nextProduct != null)
                {
                    nextId = nextProduct.Id;
                    nextAzName = nextProduct.AzTitle + " " + nextProduct.AzTitle2;
                    nextRuName = nextProduct.RuTitle + " " + nextProduct.RuTitle2;
                    nextEnName = nextProduct.EnTitle + " " + nextProduct.EnTitle2;


                    if (nextProduct.IsSimple)
                    {
                        isNextSimple = true;
                    }
                    else
                    {
                        isNextSimple = false;
                    }
                }
                else
                {
                    nextId=product.Id;
                    nextAzName = product.AzTitle + " " + product.AzTitle2;
                    nextRuName = product.RuTitle + " " + product.RuTitle2;
                    nextEnName = product.EnTitle + " " + product.EnTitle2;
                }
               cvalue = false;
            }
            ViewBag.IsLast = cvalue;
            ViewBag.isNextSimple=isNextSimple;
            ViewBag.nextId = nextId;

            ViewBag.nextAzName = nextAzName;
            ViewBag.nextRuName = nextRuName;
            ViewBag.nextEnName = nextEnName;

            var productt=await _db.Products.Where(x => x.IsDeactive == false).FirstOrDefaultAsync();
            ViewBag.firstId = productt.Id;
            ViewBag.firstAzName = productt.AzTitle+" "+productt.AzTitle2;
            ViewBag.firstRuName = productt.RuTitle+" "+productt.RuTitle2;
            ViewBag.firstEnName = productt.EnTitle+" "+productt.EnTitle2;


            return View(product);
        }

        public async Task<IActionResult> SimpleDetail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Product product = await _db.Products.Include(x => x.FAQs)
                .Include(x => x.Customers).Include(x => x.Partners)
                .Include(x => x.ProductCharts).Include(x => x.ProductDetailTitle)
                .Include(x => x.ProductInformation).Include(x => x.SimpleProduct).Include(x => x.ProductWords)
                .FirstOrDefaultAsync(x => x.Id == id);

            ViewBag.AzSeoTitle = product.AzSeoTitle;
            ViewBag.RuSeoTitle = product.RuSeoTitle;
            ViewBag.EnSeoTitle = product.EnSeoTitle;
            ViewBag.AzSeoDescription = product.AzSeoDescription;
            ViewBag.RuSeoDescription = product.RuSeoDescription;
            ViewBag.EnSeoDescription = product.EnSeoDescription;



            if (product == null)
            {
                return BadRequest();
            }
            List<Product> products = await _db.Products.Where(x => x.IsDeactive == false).OrderByDescending(x => x.Id).ToListAsync();
            var testIndexOf=products.IndexOf(product);
            bool cvalue = false;
            int? nextId = 0;
            bool isNextSimple = false;
            var nextAzName = "";
            var nextRuName = "";
            var nextEnName = "";

            if (products[0].Id == id)
            {
                cvalue = true;
            }
            else
            {
               

                Product nextProduct = products[testIndexOf - 1];
                if (nextProduct != null)
                {
                    nextId = nextProduct.Id;
                    nextAzName = nextProduct.AzTitle + " " + nextProduct.AzTitle2;
                    nextRuName = nextProduct.RuTitle + " " + nextProduct.RuTitle2;
                    nextEnName = nextProduct.EnTitle + " " + nextProduct.EnTitle2;

                    if (nextProduct.IsSimple)
                    {
                        isNextSimple = true;
                    }
                    else
                    {
                        isNextSimple = false;
                    }
                }
                else
                {
                    nextId=product.Id;
                    nextAzName = product.AzTitle + " " + product.AzTitle2;
                    nextRuName = product.RuTitle + " " + product.RuTitle2;
                    nextEnName = product.EnTitle + " " + product.EnTitle2;
                }
                cvalue = false;
            }
            ViewBag.IsLast = cvalue;
            ViewBag.IsNextSimple = isNextSimple;
            ViewBag.nextId = nextId;

            ViewBag.nextAzName = nextAzName;
            ViewBag.nextRuName = nextRuName;
            ViewBag.nextEnName = nextEnName;

            return View(product);
        }
    }
}
