using DO_AN_SEM3.Entities;
using DO_AN_SEM3.Models.Common;
using DO_AN_SEM3.Models.Product;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DO_AN_SEM3.Controllers
{
    [Authorize(Roles = "Administrator, Super Admin")]
    public class ProductController : Controller
    {
        anhvDbContext db = new anhvDbContext();
        public ActionResult Index(int id)
        {
            var product = db.Products.Where(x => x.CategoryId == id).ToList();
            return View(product);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Category = db.Categories.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(ProductModel model)
        {
            ViewBag.Category = db.Categories.ToList();

            if (ValidateBeforeSaving(model))
            {
                try
                {
                    var product = new Product()
                    {
                        Amount = model.Amount,
                        Name = model.Name,
                        Price = model.Price,
                        DateCreate = DateTime.Now,
                        CategoryId = model.CategoryId,
                        ImagePath = SaveFile(model.ImageFile),
                        ImageSize = model.ImageFile.ContentLength,
                        Discount = model.Discount,
                        Seotitle = FriendlyUrlHelper.GetFriendlyTitle(model.Name),
                        Status = model.TrangThai
                    };
                    ViewBag.Category = db.Categories.ToList();
                    db.Products.Add(product);
                    db.SaveChanges();
                }
                catch (Exception ex) { }

                return Json(new { success = true });
            }
            return View(model);
        }
        private bool ValidateBeforeSaving(ProductModel model)
        {
            var isName = db.Products.Any(x => x.Name == model.Name);

            if (isName)
            {
                ModelState.AddModelError("", "Tên sản phẩm đã tồn tại !!!");
            }
            return ModelState.IsValid;
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return HttpNotFound();
            }
            var product = db.Products.Where(x => x.Id == id)
                .Select(x => new ProductModel()
                {
                    Amount = x.Amount,
                    Name = x.Name,
                    Price = x.Price,
                    Discount = x.Discount,
                    TrangThai = x.Status,
                    CategoryId = x.CategoryId,
                    ImagePath = x.ImagePath
                }).SingleOrDefault();

            ViewBag.Category = new SelectList(db.Categories.ToList(), "Id", "Name");
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(int? id, ProductModel model)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            if(ModelState.IsValid)
            {
                var checkTenSanPham = db.Products.Any(x => x.Name.Contains(model.Name) && x.Id != id);

                if(checkTenSanPham)
                {
                    ModelState.AddModelError("", "Tên sản phẩm đã được sử dụng !!!");
                }
                else
                {
                    var product = db.Products.Find(id);

                    string oldfilePath = product.ImagePath;

                    string fullPath = Request.MapPath("~/Content/UploadFile/" + oldfilePath);

                    if(System.IO.File.Exists(fullPath))
                    {
                        System.IO.File.Delete(fullPath);
                    }
                    product.Price = model.Price;
                    product.Name = model.Name;
                    product.Seotitle = FriendlyUrlHelper.GetFriendlyTitle(model.Name);
                    product.Discount = model.Discount;
                    product.ImagePath = SaveFile(model.ImageFile);
                    product.Status = model.TrangThai;
                    product.CategoryId = model.CategoryId;
                    product.ImageSize = model.ImageFile.ContentLength;

                    db.Products.AddOrUpdate(product);
                    db.SaveChanges();

                    return Json(new { success = true });
                }
            }
            ViewBag.Category = new SelectList(db.Categories.ToList(), "Id", "Name");
            return View();

        }
        private string SaveFile(HttpPostedFileBase file)
        {
            if (file.ContentLength > 0)
            {
                string _FileName = Guid.NewGuid() + Path.GetFileName(file.FileName);
                string _path = Path.Combine(Server.MapPath("~/Content/UploadFile"), _FileName);
                file.SaveAs(_path);

                return _FileName;
            }
            return null;
        }
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var productDetails = db.Products.Where(x => x.Id == id)
                .Select(x => new ProductModel()
                {
                    Amount = x.Amount,
                    Discount = x.Discount,
                    Price = x.Price,
                    LoaiSanPham = x.Category.Name,
                    TrangThai = x.Status,
                    Name = x.Name,
                    ImagePath = x.ImagePath
                }).FirstOrDefault();

            return View(productDetails);
        }
    }
}