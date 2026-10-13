using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Team_Project_1.Models;

namespace Team_Project_1.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Details() 
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";

            return View(ViewBag.Action);
        }
        [HttpPost]
        public IActionResult Add(AddModel model)
        {
            if (ModelState.IsValid)
            {
                Contact contact = model.CreateContact();
            }
            ViewBag.Action = "Add";
            return View(ViewBag.Action);
        }

        [HttpGet]
        public IActionResult Edit()
        {
            ViewBag.Action = "Edit";
            
            return View(ViewBag.Action);
        }
        [HttpPost]
        public IActionResult Edit(EditModel model)
        {
            if (ModelState.IsValid)
            {
                Contact contact = model.UpdateContact();
            }
            ViewBag.Action = "Edit";
            return View(ViewBag.Action);
        }

        public IActionResult Delete() {
            return View();
        }
    }
}
