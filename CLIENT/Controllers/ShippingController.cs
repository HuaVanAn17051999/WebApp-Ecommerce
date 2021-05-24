using CLIENT.Models;
using DO_AN_SEM3.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CLIENT.Controllers
{
    public class ShippingController : BaseController
    {
        anhvDbContext db = new anhvDbContext();
        public JsonResult Index()
        {
            var sessionInfo = (CLIENT.Models.InforSession)Session["InforSession"];
            if (sessionInfo != null)
            {
                var userId = sessionInfo.UserId;

                var data = Address(userId);
                var json = JsonConvert.SerializeObject(data);

                return Json(json, JsonRequestBehavior.AllowGet);
            }
            return null;
        }
        public JsonResult UpdateAddress(int id)
        {
            var address = db.Orders.Where(x => x.Id == id).SingleOrDefault();
            return Json(new { data = address, JsonRequestBehavior.AllowGet });
        }
        [HttpPost]
        public ActionResult UpdateAddress(DiaChiModel model)
        {
             if(model != null)
             {
                //var checkIsDefault = db.Orders.Any(x => x.Id != model.Id && model.isDefault == true);
                //if(checkIsDefault)
                //{
                     
                //}
                var order = db.Orders.Find(model.userId);
                order.HoTen = model.HoTen;
                order.Sdt = model.Sodt;
                order.DiaChi = model.DiaChi;
                order.XaPhuongId = model.XaPhuongId;
                order.IsDefault = model.isDefault;

                db.Orders.AddOrUpdate(order);
                db.SaveChanges();

                return Json(new { success = true });
             }
            return null;
        }
        [HttpPost]
        public ActionResult ThemDiaChiMoi(DiaChiModel model)
        {
            var data = new Order()
            {
                UserId = model.userId,
                DateOrder = DateTime.Now,
                HoTen = model.HoTen,
                Sdt = model.Sodt,
                XaPhuongId = model.XaPhuongId,
                DiaChi = model.DiaChi,
                IsDefault = model.isDefault
            };
            db.Orders.Add(data);
            db.SaveChanges();

            return Json(new { success = true });
        }
        [HttpPost]
        public JsonResult XoaDiaChi(int id)
        {
            var diachi = db.Orders.Find(id);
            db.Orders.Remove(diachi);
            db.SaveChanges();

            return Json(new { success = true });
        }
    }
}