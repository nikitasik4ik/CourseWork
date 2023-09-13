using CourseWork.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CourseWork.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost] // Обработка POST запроса
        public IActionResult VerifyAccess(string role, string accessCode)
        {
            // Проверка кода доступа
            if (role == "Manager" && accessCode == "managerCode")
            {
                // Действия для роли Менеджер
                return RedirectToAction("Index", "Manager");
            }
            else if (role == "Administrator" && accessCode == "adminCode")
            {
                // Действия для роли Администратор
                return RedirectToAction("Index", "Admin");
            }
            else if (role == "Analyst" && accessCode == "analystCode")
            {
                // Действия для роли Аналитик
                return RedirectToAction("Index", "Analyst");
            }
            else
            {
                // Неправильный код доступа, возвращаем обратно на страницу выбора роли
                return RedirectToAction("Index");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}