using Microsoft.AspNetCore.Mvc;

namespace CourseWork.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Clients()
        {
            return View();
        }

        public IActionResult Countries()
        {
            return View();
        }

        public IActionResult Posts()
        {
            return View();
        }
    }
}

