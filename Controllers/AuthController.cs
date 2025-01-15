using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using ExerciceEfCore.Models;

namespace ExerciceEfCore.Controllers
{
    public class AuthController : Controller
    {
        private static readonly List<User> Users = new()
        {
            new User {Username = "admin", Password ="admin"},
            new User {Username = "user", Password ="user"},
        };

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = Users.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user != null)
            {
                HttpContext.Session.SetString("Username", user.Username);
                return RedirectToAction("Index", "TodoTasks");
            }

            ViewBag.Message = "Nom d'utilisateur ou mdp incorrect";
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
