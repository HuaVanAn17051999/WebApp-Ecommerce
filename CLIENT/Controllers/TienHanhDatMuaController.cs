using CLIENT.Models;
using DO_AN_SEM3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace CLIENT.Controllers
{
    public class TienHanhDatMuaController : Controller
    {
        anhvDbContext db = new anhvDbContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult Index(TienHanhDatMuaModel model)
        {
            if (model.OrderDetails.Count > 0)
            {
                MailMessage mm = new MailMessage("anhuavan9x@gmail.com", model.To);
                mm.Subject = model.Subject;
                mm.Body = model.Body;
                mm.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;

                NetworkCredential nc = new NetworkCredential("anhuavan9x@gmail.com", "huavanan9x");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = nc;
                smtp.Send(mm);

                foreach (var item in model.OrderDetails)
                {
                    var orderDetails = new OrderDetail()
                    {
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        Price = item.Price,
                        DateOrder = DateTime.Now,
                        TrangThai = 1
                    };
                    orderDetails.OrderId = model.OrderId;
                    db.OrderDetails.Add(orderDetails);
                    db.SaveChanges();
                }
                return Json(new { success = true });
            }
            return View();
        }
    }
}