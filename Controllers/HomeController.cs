using Final.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Controllers
{
    public class HomeController : Controller
    {
        private IRepository repo { get; set; }

        public HomeController(IRepository temp)
        {
            repo = temp;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ViewEntertainers()
        {
            var x = repo.Entertainers.ToList();
            return View(x);
        }

        public IActionResult Info(long id)
        {
            var e = repo.Entertainers.Single(x => x.EntertainerId == id);
            return View(e);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View("Form");
        }
        [HttpPost]
        public IActionResult Add(Entertainers e)
        {
            repo.AddEntertainer(e);
            repo.Save();
            return RedirectToAction("ViewEntertainers");
        }

        [HttpGet]
        public IActionResult Edit(long id)
        {
            var e = repo.Entertainers.Single(x => x.EntertainerId == id);
            return View("Form", e);
        }

        [HttpPost]
        public IActionResult Edit(Entertainers e)
        {
            repo.UpdateEntertainer(e);
            repo.Save();
            return RedirectToAction("Info", e.EntertainerId);
        }

        public IActionResult Delete(long id)
        {
            var e = repo.Entertainers.Single(x => x.EntertainerId == id);
            repo.DeleteEntertainer(e);
            repo.Save();
            return RedirectToAction("ViewEntertainers");
        }


    }
}
