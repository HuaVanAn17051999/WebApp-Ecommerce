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
    public class QuanLyHoaDonController : Controller
    {
        anhvDbContext db = new anhvDbContext();
        public ActionResult Index()
        {
            var DonHang = db.OrderDetails
                .Select(x => new QuanLyDonHangModel()
                {
                   KhachHang = x.Order.HoTen,
                   DiaChi = x.Order.DiaChi,
                   Sodt = x.Order.Sdt,
                   QuanHuyen = x.Order.XaPhuong.QuanHuyen.Ten,
                   XaPhuong = x.Order.XaPhuong.Ten,
                   TinhThanh = x.Order.XaPhuong.TinhThanh.Ten,
                   NgayBanHang = x.DateOrder,
                   TongTien = (double)(x.Quantity * x.Price),
                   TrangThai = x.TrangThai
                }).ToList();
            return View( DonHang);
        }
    }
}