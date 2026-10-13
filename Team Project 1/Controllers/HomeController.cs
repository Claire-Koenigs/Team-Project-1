using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Team_Project_1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
