using DO_AN_SEM3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CLIENT.Controllers
{
    public class HomeController : Controller
    {
        anhvDbContext db = new anhvDbContext();
        public ActionResult Index()
        {
            var sanPhamMoiNhat = db.Products
                 .OrderByDescending(x => x.DateCreate)
                 .Take(12)
                 .ToList();

            return View(sanPhamMoiNhat);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult GioiThieu()
        {
            return View();
        }
    }
}