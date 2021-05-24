using CLIENT.Models;
using DO_AN_SEM3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CLIENT.Controllers
{
    public class BaseController : Controller
    {
        anhvDbContext db = new anhvDbContext();
        public List<ThongTinDiaChiModel> Address(int userId)
        {
            var thongtindiachi = db.Orders.Where(x => x.UserId == userId)
                .Select(a => new ThongTinDiaChiModel()
                {
                    Id = a.Id,
                    diachi = a.DiaChi,
                    hoten = a.HoTen,
                    QuanHuyen = a.XaPhuong.QuanHuyen.Ten,
                    XaPhuong = a.XaPhuong.Ten,
                    TinhThanh = a.XaPhuong.QuanHuyen.TinhThanh.Ten,
                    sdt = a.Sdt,
                    TinhThanhId = a.XaPhuong.QuanHuyen.TinhThanh.ID,
                    QuanHuyenId = a.XaPhuong.QuanHuyen.ID,
                    idXaPhuong = a.XaPhuong.Id,
                    isDefault = a.IsDefault
                }).ToList();

            return thongtindiachi;
        }
        public ThongTinDiaChiModel GetAddressisDefault(int userId)
        {
            var thongtindiachi = db.Orders.Where(x => x.UserId == userId)
             .Where(b => b.IsDefault == true)
             .Select(a => new ThongTinDiaChiModel()
             {
                 Id = a.Id,
                 diachi = a.DiaChi,
                 hoten = a.HoTen,
                 QuanHuyen = a.XaPhuong.QuanHuyen.Ten,
                 XaPhuong = a.XaPhuong.Ten,
                 TinhThanh = a.XaPhuong.QuanHuyen.TinhThanh.Ten,
                 sdt = a.Sdt,
                 TinhThanhId = a.XaPhuong.QuanHuyen.TinhThanh.ID,
                 QuanHuyenId = a.XaPhuong.QuanHuyen.ID,
                 idXaPhuong = a.XaPhuong.Id,
                 isDefault = a.IsDefault
             }).SingleOrDefault();

            return thongtindiachi;
        }
    }
}