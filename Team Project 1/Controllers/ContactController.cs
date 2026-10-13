using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Team_Project_1.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Details() 
        {
            return View();
        }

        public IActionResult Add()
        {
            ViewBag.Action = "Add";

            return View(ViewBag.Action);
        }

        public IActionResult Edit()
        {
            ViewBag.Action = "Edit";
            
            return View(ViewBag.Action);
        }

        public IActionResult Delete() {
            return View();
        }
    }
}
