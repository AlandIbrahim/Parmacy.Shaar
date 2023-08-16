using Microsoft.AspNetCore.Mvc;
using Parmacy.Shaar.Models.ViewModels;
using Parmacy.Shaar.Models;
using System.Text;
using Parmacy.Shaar.Data;
using Microsoft.EntityFrameworkCore;

namespace Parmacy.Shaar.Controllers
{
    public class AdminController : Controller
    {
        public ApplicationDbContext db;

        public AdminController(ApplicationDbContext _db)
        {
            db = _db;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Register()
        {
            if (HttpContext.Session.GetInt32("UID") == 1)
                return View();
            else return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Register")]
        public async Task<IActionResult> Register(LoginVM credentials)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (await db.users.AnyAsync(s => s.Name == credentials.Name)) TempData["Error"] = "User Already Exists";
                    else
                    {
                        string hashedPassword = Convert.ToBase64String(System.Security.Cryptography.SHA256.HashData(Encoding.UTF8.GetBytes(credentials.Password)));
                        User user = new()
                        {
                            Name = credentials.Name,
                            Password = hashedPassword,
                            permission = "Employee",
                            Salary = 0
                        };
                        db.users.Add(user);
                        await db.SaveChangesAsync();
                        TempData["Success"] = "User Registered Successfully";
                        return RedirectToAction(nameof(Index), new { UID = user.ID });
                    }
                }
                else TempData["Error"] = "Operation failed";
            }
            catch (Exception e) { TempData["Error"] = e.InnerException != null ? e.InnerException : e.Message; }
            return View();
        }
    }
}
