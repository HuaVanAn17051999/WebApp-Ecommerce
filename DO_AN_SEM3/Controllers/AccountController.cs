using DO_AN_SEM3.Entities;
using DO_AN_SEM3.Models.Common;
using DO_AN_SEM3.Models.Users;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DO_AN_SEM3.Controllers
{
   
    public class AccountController : Controller
    {
        // GET: Users
        anhvDbContext db = new anhvDbContext();
        public ActionResult Index()
        {
            var listUser = db.Users.Select(x => new UserModel()
            {
                Id = x.Id,
                HoVaTen = x.HoVaTen,
                UserName = x.TenDangNhap,
                GioiTinh = x.GioiTinh,
                RoleName = x.UserRoles.Select(r => r.Role.Name).ToList()
            }); ;

            return View(listUser.ToList());
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserLoginModel model)
        {
            if (ModelState.IsValid)
            {
                var login = db.Users.Any(x => x.TenDangNhap == model.UserName && x.PassWord == model.PassWord);

                if (login)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    InforSession.SessionName = model.UserName;
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng !!!!");
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var exitUserName = db.Users.Any(x => x.TenDangNhap == model.UserName);
            if (exitUserName)
            {
                ModelState.AddModelError("", "Tên đăng nhập đă được sử dụng.");
            }
            var listRole = new List<UserRole>();

            listRole.Add(new UserRole()
            {
                RoleId = model.RoleId
            });
            var user = new User()
            {
                HoVaTen = model.HoVaTen,
                TenDangNhap = model.UserName,
                Sdt = model.Sdt,
                GioiTinh = model.GioiTinh,
                PassWord = model.PassWord,
                UserRoles = listRole
            };
            db.Users.Add(user);
            db.SaveChanges();

            return RedirectToAction(nameof(Login));
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var user = db.Users.Where(x => x.Id == id)
                 .Select(b => new UserEditModel()
                 {
                     HoVaTen = b.HoVaTen,
                     GioiTinh = b.GioiTinh,
                     UserName = b.TenDangNhap,
                     Sdt = b.Sdt,
                 }).SingleOrDefault();

            return View(user);

        }
        [HttpPost]
        public ActionResult Edit(int? id, UserEditModel model)
        {
            if (ModelState.IsValid)
            {
                var checkName = db.Users.Any(x => x.TenDangNhap == model.UserName && x.Id != id);
                if(checkName)
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã được sử dụng !!!");
                }
                else
                {
                    var user = db.Users.Find(id);
                    user.HoVaTen = model.HoVaTen;
                    user.Sdt = model.Sdt;
                    user.TenDangNhap = model.UserName;
                    user.GioiTinh = model.GioiTinh;
                    db.Users.AddOrUpdate(user);
                    db.SaveChanges();

                    return RedirectToAction(nameof(Index));
                }
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction(nameof(Login));
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            var inforSession = InforSession.SessionName;

            if (inforSession == user.TenDangNhap)
            {
                return RedirectToAction(nameof(SowDoNoDelete));
            }
            if (UserRoleExitsUser(id))
            {
                db.Users.Remove(user);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();

        }

        private bool UserRoleExitsUser(int? id)
        {
            var query = db.UserRoles.Where(x => x.UserId == id).ToList();
            if (query.Count > 0)
            {
                foreach (var item in query)
                {
                    db.UserRoles.Remove(item);
                    db.SaveChanges();
                }
                return true;
            }
            return false;
        }

        public ActionResult SowDoNoDelete()
        {
            return View();
        }
        [HttpGet]
        public ActionResult PhanQuyen(int? id)
        {
            var roleAssignRequest = GetRoleAssignRequest(id);
            ViewData["TenNguoiDung"] = db.Users.Where(x => x.Id == id).Select(a => a.HoVaTen).FirstOrDefault();
            return View(roleAssignRequest);
        }
        private object GetRoleAssignRequest(int? id)
        {
            var roleObj = db.Roles.ToList();

            var query = from r in db.Roles
                        join ur in db.UserRoles on r.Id equals ur.RoleId
                        join u in db.Users on ur.UserId equals u.Id
                        where (u.Id == id)
                        select new { r };

            var listRole = query.ToList();

            var roles = new List<ListRoles>();

            foreach (var item in roleObj)
            {
                var isRoleExits = listRole.Where(x => x.r.Name == item.Name).ToList();

                if (isRoleExits.Count > 0)
                {
                    roles.Add(new ListRoles()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Seleted = true
                    });
                }
                else
                {
                    roles.Add(new ListRoles()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Seleted = false
                    });

                }
            }
            return roles;
        }
        [HttpPost]
        public ActionResult PhanQuyen(int id, List<ListRoles> model)
        {
            foreach (var item in model)
            {
                if (item.Seleted)
                {
                    var query = db.UserRoles.Where(x => x.UserId == id).Any(x => x.RoleId == item.Id);

                    if (query == false)
                    {
                        var role = new UserRole()
                        {
                            UserId = id,
                            RoleId = item.Id
                        };
                        db.UserRoles.Add(role);
                        db.SaveChanges();
                    }
                }
                else
                {
                    //var query = db.UserRoles.Where(x => x.UserId == id).Any(x => x.RoleId == item.Id);
                    var userRole = db.UserRoles.Where(x => x.UserId == id && x.RoleId == item.Id).ToList();

                    if (userRole.Count > 0)
                    {
                        foreach (var item2 in userRole)
                        {
                            db.UserRoles.Remove(item2);
                            db.SaveChanges();
                        }
                    }
                }
            }
            ViewData["success"] = "Phân quyền thành công !";
         
            return RedirectToAction(nameof(Index));
        }
    }
}