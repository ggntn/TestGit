using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Testweb2.Models;

namespace Testweb2.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Index(Formtest form)
        {
            if (ModelState.IsValid)
            {
                return View("finish",form);
            }

            return View(form);
        }
        //[Route("guy")] //กำหนดชื่อ url
        //public IActionResult Index()
        //{
        //    Test t = new Test();
        //    t.testid = "1";
        //    t.testname = "sdgdsg";
        //    return View(t);
        //    //return View();
        //}

        // [Route("test2")] //กำหนดชื่อ url


        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
