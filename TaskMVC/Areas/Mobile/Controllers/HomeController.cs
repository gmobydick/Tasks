using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaskMVC.Areas.Mobile.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Mobile/Home/

        public ActionResult Index()
        {
            return View();
        }

    }
}
