using DO_AN_SEM3.Entities;
using DO_AN_SEM3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DO_AN_SEM3.Controllers
{
    public class LichSuMuaHangController : Controller
    {
        // GET: LichSuMuaHang
        anhvDbContext db = new anhvDbContext();
        public ActionResult Index()
        {
            var lichSuMuaHang = db.OrderDetails
                .Select(x => new LichSuMuaHangModel()
                {
                    HoVaTen = x.Order.User.HoVaTen,
                    Date = x.DateOrder,
                    ImagePath = x.Product.ImagePath,
                    Name = x.Product.Name,
                    Id = x.Id,
                    Price = x.Price,
                    Quantity = x.Quantity,
                    Satus = x.TrangThai
                }).ToList();
        
            return View(lichSuMuaHang);
        }
        [HttpPost]
        public JsonResult CapNhatTrangThai(int id, int status)
        {
            var orderDetails = db.OrderDetails.Find(id);
            orderDetails.TrangThai = status;
            db.OrderDetails.AddOrUpdate(orderDetails);
            db.SaveChanges();
            return Json(new { success = true });
        }
    }
}