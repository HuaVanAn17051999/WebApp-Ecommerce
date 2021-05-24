using CLIENT.Models;
using DO_AN_SEM3.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CLIENT.Controllers
{
    public class CheckOutController : BaseController
    {
        anhvDbContext db = new anhvDbContext();
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult LoadTinhThanh()
        {
            var data = db.TinhThanhs
                 .Select(x => new DiaChiModel() { Id = x.ID, Name = x.Ten })
                 .OrderBy(x => x.Name)
                 .ToList();
            var json = JsonConvert.SerializeObject(data);

            return Json(json, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult LoadQuanHuyen(int tinhthanhId)
        {
            var data = db.QuanHuyens
                .Where(x => x.TinhThanhID == tinhthanhId)
                .Select(x => new DiaChiModel() { Id = x.ID, Name = x.Ten })
                .OrderBy(x => x.Name)
                .ToList();

            var json = JsonConvert.SerializeObject(data);

            return Json(json, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult LoadXaPhuong(int quanhuyenId)
        {
            var data = db.XaPhuongs
                .Where(x => x.QuanHuyenID == quanhuyenId)
                .Select(x => new DiaChiModel() { Id = x.Id, Name = x.Ten })
                .OrderBy(x => x.Name)
                .ToList();

            var json = JsonConvert.SerializeObject(data);

            return Json(json, JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult Payment(string id)
        {
            var sessionInfo = (CLIENT.Models.InforSession)Session["InforSession"];

            if (sessionInfo != null)
            {
                ViewBag.Email = db.Users.Where(x => x.Id == sessionInfo.UserId).Select(x => x.Email).FirstOrDefault();
            }

            if (id != null)
            {
                int Id = Int32.Parse(id);
                var GiaoDenDiaChiNay = db.Orders
                    .Where(x => x.Id == Id)
                    .Select(b => new ThongTinDiaChiModel()
                    {
                        Id = b.Id,
                        diachi = b.DiaChi,
                        hoten = b.HoTen,
                        TinhThanh = b.XaPhuong.TinhThanh.Ten,
                        QuanHuyen = b.XaPhuong.QuanHuyen.Ten,
                        sdt = b.Sdt,
                        XaPhuong = b.XaPhuong.Ten
                    }).SingleOrDefault();

                return View(GiaoDenDiaChiNay);
            }
            else
            {
                var userId = sessionInfo.UserId;
                return View(GetAddressisDefault(userId));
            }
        }
        public ActionResult shipping()
        {
            var sessionInfo = (CLIENT.Models.InforSession)Session["InforSession"];
            if (sessionInfo != null)
            {
                var userId = sessionInfo.UserId;
                return View(Address(userId));
            }
            return View();
        }
    }
}