using Microsoft.AspNetCore.Mvc;

namespace CourseWork.Controllers
{
    public class ManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
