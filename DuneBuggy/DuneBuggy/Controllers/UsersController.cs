using System.Web.Mvc;
using DuneBuggy.Businesslayer.Models;
using DuneBuggy.Businesslayer.Helpers;
using DuneBuggy.Datalayer.UnitOfWork;
using System.Web.Security;

namespace DuneBuggy.Controllers
{    
    public class UsersController : BaseController
    {
        UnitOfWork _context = new UnitOfWork();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            string passwordHash = PasswordHelper.GetSHA512Hash(user.Password);            

            var dbUser = _context.User.GetSingle(u => u.Username == user.Username && u.Password == passwordHash);
            if (dbUser != null)
            {
                FormsAuthentication.SetAuthCookie(user.Username, true);               
                return RedirectToAction("Index", "Products");
            }           

            ModelState.AddModelError("LoginError", "Login failed");
            return View(user);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}