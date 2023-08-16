using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parmacy.Shaar.Data;
using Parmacy.Shaar.Models;
using Parmacy.Shaar.Models.ViewModels;
using System.Text;

namespace Parmacy.Shaar.Controllers
{
    public class UserController : Controller
    {
        ApplicationDbContext db;
        public UserController(ApplicationDbContext _db)
        {
            db = _db;
        }
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM credentials)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string hashedPassword = Convert.ToBase64String(System.Security.Cryptography.SHA256.HashData(Encoding.UTF8.GetBytes(credentials.Password)));
                    User user = await db.users.FirstOrDefaultAsync(s => s.Name == credentials.Name && s.Password == hashedPassword);
                    if (user == null) TempData["Error"] = "Invalid Credentials";
                    else
                    {
                        HttpContext.Session.SetInt32("UID", user.ID);
                        if (user.permission == "admin") HttpContext.Session.SetInt32("Permission", 1);
                        else HttpContext.Session.SetInt32("Permission", 0);

                        if(HttpContext.Session.GetString("Redirect")!=null)
                        {
                            string redirect = HttpContext.Session.GetString("Redirect");
                            string controller = redirect.Split("/")[0];
                            string action = redirect.Split("/")[1];
                            HttpContext.Session.Remove("Redirect");
                            return RedirectToAction(action, controller);
                        }
                        return RedirectToAction(nameof(Index), new { UID = user.ID });
                    }
                }
                else TempData["Error"] = "Invalid Credentials";
            }
            catch (Exception e) { TempData["Error"] = e.Message;}
            return View();
        }
        public async Task<IActionResult> Index(int UID)
        {
            User user = await db.users.FindAsync(UID);
            UserVM userVM = new()
            {
                ID = user.ID,
                UserName = user.Name,
                Salary = user.Salary,
                Sales = await db.sellInvoices.Where(s => s.Employee_Id == UID).ToListAsync()
            };
            return View(userVM);
        }
        public async Task<IActionResult> ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //post action for "ForgotPassword"
        public async Task<IActionResult> ResetPassword()
        {
            return View();
        }
    }
}
