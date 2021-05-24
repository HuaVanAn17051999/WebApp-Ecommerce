using DO_AN_SEM3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CLIENT.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        anhvDbContext db = new anhvDbContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult _Menu()
        {
            return PartialView(db.Categories.ToList());
        }
    }
}