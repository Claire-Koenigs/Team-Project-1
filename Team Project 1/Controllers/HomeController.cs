using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Team_Project_1.Models;
using Microsoft.EntityFrameworkCore;

namespace Team_Project_1.Controllers
{
    public class HomeController : Controller
    {
        private ContactContext context { get; set; }
        public HomeController(ContactContext ctx) => context = ctx;

        public IActionResult Index()
        {
            var contacts = context.Contacts.Include(c => c.Category).OrderBy(c => c.LastName).ToList();
            return View(contacts);
        }
    }
}
