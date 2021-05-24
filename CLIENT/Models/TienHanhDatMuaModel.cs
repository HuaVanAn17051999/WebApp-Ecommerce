using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CLIENT.Models
{
    public class TienHanhDatMuaModel
    {
        public string To { get; set; }
        public string Form { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public int OrderId  { get; set; }
        public List<OrderDetailModel> OrderDetails { get; set; }

    }
}