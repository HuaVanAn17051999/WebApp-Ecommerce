using CLIENT.Models;
using DO_AN_SEM3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CLIENT.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        anhvDbContext db = new anhvDbContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ProductGetById(int? id)
        {
            if(id == null)
            {
                return HttpNotFound();
            }
            var product = db.Products.Where(x => x.CategoryId == id).ToList();

            if(product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        public ActionResult ProductDetails(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var productDetails = db.Products.Find(id);

            if (productDetails == null)
            {
                return HttpNotFound();
            }

            var seletedGia = db.Products.Where(x => x.Id == id).Select(x => x.Price).SingleOrDefault();

            ViewBag.ListSanPhamCungGia = db.Products.Where(x => x.Price == seletedGia).Take(10).ToList();

            ViewBag.ThongTinSanPham = db.ThongTinSanPhams.Where(x => x.productId == id).SingleOrDefault();

            ViewBag.FeddBacks = db.FeedBacks
                .Where(x => x.ProductId == id)
                .Select(a => new FeeBackModel()
                {
                    UserName = a.User.TenDangNhap,
                    Date_of_question = a.DateCreate,
                    feedBack = a.Feedback1
                }).ToList();

            return View(productDetails);
        }
        [HttpGet]
        public ActionResult Search(string inputSearch)
        {
            var result = db.Products.Where(x => x.Name.Contains(inputSearch.Trim())).SingleOrDefault();
            return View(result);
        }
    }
}