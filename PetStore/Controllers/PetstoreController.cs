using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetStore.Controllers
{
    public class PetstoreController : Controller
    {
        // GET: Petstore
        public ActionResult Index()
        {
            return View();
        }
    }
}