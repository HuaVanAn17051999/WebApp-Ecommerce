using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CLIENT.Models;
using DO_AN_SEM3.Entities;

namespace CLIENT.Controllers
{
    public class FeedBackController : Controller
    {
        // GET: FeedBack
        anhvDbContext db = new anhvDbContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FeeBackModel feeBackModel )
        {
            var feedBack = new FeedBack()
            {
                ProductId = feeBackModel.ProductId,
                UserId = feeBackModel.UserId,
                Feedback1 = feeBackModel.feedBack,
                DateCreate = DateTime.Now

            };

            db.FeedBacks.Add(feedBack);
            db.SaveChanges();

            return Json(new { success = true });
        }
    }
}