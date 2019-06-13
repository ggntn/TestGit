using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Testweb2.Models.db; //call my project
using Testweb2.Models;

namespace Testweb2.Controllers
{
    public class TestController : Controller
    {
        NorthwindContext db = new NorthwindContext();
        // GET: Test
        public ActionResult Index()
        {
            var data = from pro in db.Products
                       join cat in db.Categories on pro.CategoryId equals cat.CategoryId
                       select new pro
                       {
                           ID = pro.ProductId,
                           ProName = pro.ProductName,

                           CatName = cat.CategoryName

                       };
            return View(data);
        }

        // GET: Test/Details/5
        public ActionResult Details(int? id)
        {

            var dataid = from pro in db.Products
                         where pro.ProductId == id
                         select new pro2
                         {
                             ID = pro.ProductId,
                             ProName = pro.ProductName,
                             Quantity = pro.QuantityPerUnit

                         };
            if (id == null)
            {
                return NotFound();
            }

            //return View();
              return View(dataid);
        }

        // GET: Test/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Test/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Test/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Test/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Test/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Test/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}