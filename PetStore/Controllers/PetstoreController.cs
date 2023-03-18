using PetStore.Models;
using System;
using PagedList;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace PetStore.Controllers
{
    public class PetstoreController : Controller
    {
        private DataContext data = new DataContext();
        // GET: Petstore
        public ActionResult Index()
        {
            return View();
        }
    }
}