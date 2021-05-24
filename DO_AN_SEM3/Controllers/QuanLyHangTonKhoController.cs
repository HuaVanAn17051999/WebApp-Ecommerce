using DO_AN_SEM3.Entities;
using DO_AN_SEM3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DO_AN_SEM3.Controllers
{
    [Authorize(Roles = "Administrator, Super Admin")]
    public class QuanLyHangTonKhoController : Controller
    {
        anhvDbContext db = new anhvDbContext();
        [HttpGet]
        public ActionResult Index()
        {
            var HangTonKho = db.Products
                .Select(x => new QuanLyHangTonKhoModel()
                {
                    AnhSP = x.ImagePath,
                    SoLuongBanDau = x.Amount,
                    Gia = x.Price,
                    TenSP = x.Name,
                    DaBan = x.OrderDetails.Select(b => b.Quantity).ToList()
                }).ToList();

            return View(HangTonKho);
        }
        [HttpPost]
        public ActionResult Index(int id)
        {
            

            return View();
        }
    }
}