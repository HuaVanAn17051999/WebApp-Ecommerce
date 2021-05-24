using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CLIENT.Models
{
    public class ThongTinDiaChiModel
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public string hoten { get; set; }
        public string sdt { get; set; }
        public string diachi { get; set; }
        public int idXaPhuong { get; set; }
        public string TinhThanh { get; set; }
        public int TinhThanhId { get; set; }
        public string QuanHuyen { get; set; }
        public int QuanHuyenId { get; set; }
        public string XaPhuong { get; set; }
        public bool? isDefault { get; set; }
    }
}