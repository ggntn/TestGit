using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Testweb2.Models.db; //call my project
using Testweb2.Models;


namespace Testweb2.Controllers
{
    public class ProductController : Controller
    {
        NorthwindContext db = new NorthwindContext();
        public IActionResult Index()
        {

            var data = from pro in db.Products
                       join cat in db.Categories on pro.CategoryId equals cat.CategoryId
                       select new pro
                       {
                         ID= pro.ProductId,
                          ProName=pro.ProductName,
                         
                        CatName=cat.CategoryName

                       };
                      // select pro; 
            //ViewData["CategoryId"] = new SelectList(db.Categories, "CategoryId", "CategoryName");
            //ViewData["SupplierId"] = new SelectList(db.Suppliers, "SupplierId", "CompanyName");
            //var ps = from p in edm.Products select p; //show data from product class
            //return View(ps);
            return View(data);
        }

        public IActionResult SearchProducts(string q)
        {
            if (string.IsNullOrEmpty(q))
            {
                return View("Index", db.Products.ToList());
            }
            else
            {
                return View("Index", db.Products.Where(p => p.ProductName.Contains(q)).ToList());
            }
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Index(Products products)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        edm.Add(products);
        //        await edm.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["CategoryId"] = new SelectList(edm.Categories, "CategoryId", "CategoryName", products.CategoryId);
        //    ViewData["SupplierId"] = new SelectList(edm.Suppliers, "SupplierId", "CompanyName", products.SupplierId);
        //    return View(products);
        //}
    }
}