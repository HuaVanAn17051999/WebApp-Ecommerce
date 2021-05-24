using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CLIENT.Models
{
    public class DiaChiModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int userId { get; set; }
        public string HoTen { get; set; }
        public string Sodt { get; set; }
        public string DiaChi { get; set; }
        public int XaPhuongId { get; set; }
        public bool isDefault { get; set; }
    }
}