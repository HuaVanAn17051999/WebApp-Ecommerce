using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CLIENT.Models
{
    public class LichSuMuaHangModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        public int? Satus { get; set; }
        public double? Price { get; set; }
        public string ImagePath { get; set; }
    }
}