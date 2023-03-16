using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetStore.Areas.Admin.Controllers
{
    public class DashbroadController : Controller
    {
        // GET: Admin/Dashbroad
        public ActionResult Index()
        {
            return View();
        }
    }
}