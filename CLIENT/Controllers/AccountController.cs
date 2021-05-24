using CLIENT.Models;
using DO_AN_SEM3.Entities;
using DO_AN_SEM3.Models.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CLIENT.Controllers
{
    public class AccountController : Controller
    {
        anhvDbContext db = new anhvDbContext();
        [HttpGet]
        public ActionResult Login()
        {
            var a = db.ThongTinSanPhams.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var login = db.Users.Any(x => x.TenDangNhap == loginModel.UserName && x.PassWord == loginModel.Password);
                if (login)
                {
                    var userId = db.Users.Where(x => x.TenDangNhap == loginModel.UserName).Select(x => x.Id).FirstOrDefault();
                    var listSession = new Models.InforSession()
                    {
                        UserId = userId,
                        UserName = loginModel.UserName
                    };
                    Session["InforSession"] = listSession;
                    FormsAuthentication.SetAuthCookie(loginModel.UserName, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không chính xác !!!");
                }
            }
            return View(loginModel);
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var exitUserName = db.Users.Any(x => x.TenDangNhap.Contains(model.TenDangNhap));
                if (exitUserName)
                {
                    ModelState.AddModelError("", "Tên đăng nhập đă được sử dụng !!!");
                }
                else
                {
                    var listRole = new List<UserRole>();

                    listRole.Add(new UserRole()
                    {
                        RoleId = model.RoleId
                    });
                    var user = new User()
                    {
                        HoVaTen = model.HoTen,
                        TenDangNhap = model.TenDangNhap,
                        Sdt = model.SoDT,
                        GioiTinh = model.GioiTinh,
                        PassWord = model.MatKhau,
                        UserRoles = listRole,
                        Email = model.Email
                    };
                    db.Users.Add(user);
                    db.SaveChanges();

                    return RedirectToAction("Login", "Account");
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Logout()
        {
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (id > 0)
            {
                var user = db.Users.Where(x => x.Id == id)
                    .Select(x => new UserEditModel()
                    {
                        Email = x.Email,
                        GioiTinh = x.GioiTinh,
                        HoTen = x.HoVaTen,
                        SoDT = x.Sdt,
                        TenDangNhap = x.TenDangNhap
                    }).SingleOrDefault();

                return View(user);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Edit(int id, UserEditModel model)
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.Find(id);

                var checkUserName = db.Users.Any(x => x.TenDangNhap == model.TenDangNhap && x.Id != id);

                if (model.MatKhau != null)
                {
                    var checkPass = user.PassWord.Contains(model.MatKhauCu);

                    if (!checkPass)
                    {
                        ModelState.AddModelError("", "Mật khẩu không chính xác !!!");
                    }
                }
                if (checkUserName)
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã được sử dụng !!!");
                }
                else
                {
                    if(model.MatKhau != null)
                    {
                        user.PassWord = model.MatKhau;
                    }
                    user.HoVaTen = model.HoTen;
                    user.TenDangNhap = model.TenDangNhap;
                    user.Email = model.Email;
                    user.Sdt = model.SoDT;

                    db.Users.AddOrUpdate(user);
                    db.SaveChanges();

                    ViewData["Success"] = "Cập nhật thông tin người dùng thành công !!!";
                }
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult LichSuMuaHang()
        {
            var sessionInfo = (CLIENT.Models.InforSession)Session["InforSession"];
            if (sessionInfo != null)
            {
                var userId = sessionInfo.UserId;
                var lichSuMuaHang = db.OrderDetails.Where(x => x.Order.UserId == userId)
                    .Select(a => new LichSuMuaHangModel()
                    {
                      Id = a.Id,
                      Name = a.Product.Name,
                      Date = a.DateOrder,
                      ImagePath = a.Product.ImagePath,
                      Price = a.Price,
                      Quantity = a.Quantity,
                      Satus = a.TrangThai
                    }).ToList();

                return View(lichSuMuaHang);
            }
            return View();
        }
        [HttpPost]
        public ActionResult LichSuMuaHang(int id)
        {
            var ls = db.OrderDetails.Find(id);
            ls.TrangThai = 2;

            db.OrderDetails.AddOrUpdate(ls);
            db.SaveChanges();

            return Json(new { success = true });
        }
    }
}