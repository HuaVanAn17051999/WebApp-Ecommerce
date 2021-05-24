using DO_AN_SEM3.Entities;
using DO_AN_SEM3.Models.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DO_AN_SEM3.Controllers
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
            var listCategory = db.Categories.ToList();
            return PartialView(listCategory);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CategoryModel model)
        {
            if(ModelState.IsValid)
            {

            }

            return View(model);
        }

    }
}