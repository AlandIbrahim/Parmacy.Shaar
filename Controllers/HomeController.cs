using Microsoft.AspNetCore.Mvc;
using Parmacy.Shaar.Data;
using Parmacy.Shaar.Models;
using System.Diagnostics;
using System.Text;

namespace Parmacy.Shaar.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public ApplicationDbContext db;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            this.db = db;
        }

        public IActionResult Index()
        {
            User admin = new User
            {
                ID = 1,
                Name = "admin",
                Password = Convert.ToBase64String(System.Security.Cryptography.SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes("admin"))),
                permission = "admin",
                Salary = 999999999,
            };
            Console.WriteLine(admin.Password);
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