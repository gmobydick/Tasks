using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaskMVC.Areas.Admin.Controllers
{
    public class ProjectTaskController : Controller
    {
        //
        // GET: /Admin/ProjectTask/

        public ActionResult Index()
        {
            return View();
        }

    }
}
