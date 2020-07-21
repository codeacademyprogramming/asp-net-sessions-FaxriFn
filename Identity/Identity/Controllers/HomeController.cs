using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Identity.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (Request.Cookies.Get("token")==null)
            {
                return RedirectToAction("Index", "Auth");
            }
            return View();
        }
     
      
    }
}