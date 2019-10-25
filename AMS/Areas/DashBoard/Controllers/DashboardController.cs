using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AMS.Areas.DashBoard.Controllers
{
    public class DashboardController : Controller
    {
        // GET: DashBoard/Dashboard
       // [Authorize(Roles ="Administrator")]
        public ActionResult Index()
        {
            return View();
        }
    }
}