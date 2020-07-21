using Identity.DAL;
using Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;

namespace Identity.Controllers
{
    public class AuthController : Controller
    {

        private readonly DataContext _data;

        public AuthController()
        {
            _data = new DataContext();
        }
        // GET: Autht

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(User user)
        {
            var login = _data.Users.FirstOrDefault(x => x.Username == user.Username );
            if (login !=null&& Crypto.VerifyHashedPassword(login.Password, user.Password))
            {
                login.Token = Guid.NewGuid().ToString();
                _data.SaveChanges();


                HttpCookie cookie = new HttpCookie("token", login.Token);
                cookie.Expires = DateTime.Now.AddDays(2);
                cookie.HttpOnly = true;
                Response.SetCookie(cookie);
                return RedirectToAction("Index", "Home");

            }
        

          
            return View();
          


            
           
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            bool isUsernameExists = _data.Users.Any(x => x.Username == user.Username);
            if (isUsernameExists)
            {
                ModelState.AddModelError("Username", "Bu istifadəçi adı artıq mövcuddur");

            }
            bool isEmailExists = _data.Users.Any(x => x.Email == user.Email);
            if (isEmailExists)
            {
                ModelState.AddModelError("Email", "Bu e-poçt ünvanı artıq istifadə edilmişdir");

            }
            user.Password = Crypto.HashPassword(user.Password);
            user.Token = Guid.NewGuid().ToString();
            _data.Users.Add(user);
            _data.SaveChanges();


            HttpCookie cookie = new HttpCookie("token", user.Token);
            cookie.Expires = DateTime.Now.AddDays(2);
            cookie.HttpOnly = true;
            Response.SetCookie(cookie);
            return RedirectToAction("Index","Home");
        }

        public ActionResult Logout()
        {
            HttpCookie cookie = Response.Cookies.Get("token");
            if (cookie==null)
            {
                return RedirectToAction("Index","Home");
            }

            var user = _data.Users.FirstOrDefault(u => u.Token == cookie.Value);
            if (user==null)
            {
                Response.Cookies.Remove("token");
                return RedirectToAction("Index", "Home");
            }
            user.Token = null;
            _data.SaveChanges();
            Response.Cookies.Remove("token");
            return RedirectToAction("Index", "Home");
        }
    }
   
}