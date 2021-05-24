using CLIENT.Models;
using DO_AN_SEM3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CLIENT.Controllers
{
    public class CartController : BaseController
    {
        public ActionResult Index()
        {
            var sessionInfo = (CLIENT.Models.InforSession)Session["InforSession"];
            if (sessionInfo != null)
            {
                var userId = sessionInfo.UserId;
                return View(GetAddressisDefault(13));
            }
            return View();
        }
    }
}