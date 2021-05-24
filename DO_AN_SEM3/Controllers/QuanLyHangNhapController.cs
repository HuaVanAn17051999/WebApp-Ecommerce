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
    public class QuanLyHangNhapController : Controller
    {
        anhvDbContext db = new anhvDbContext();
        [HttpGet]
        public ActionResult Index()
        {
            var DonHangNhap = db.Products
                .Select(x => new QuangLyHangNhapModel()
                {
                    NgayNhap = x.DateCreate,
                    TenSP = x.Name,
                    AnhSP = x.ImagePath,
                    Gia = x.Price,
                    SoLuong = x.Amount
                }).ToList();

            return View(DonHangNhap);
        }
    }
}