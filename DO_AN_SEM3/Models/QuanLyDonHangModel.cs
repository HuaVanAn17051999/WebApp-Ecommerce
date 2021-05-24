using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DO_AN_SEM3.Models
{
    public class QuanLyDonHangModel
    {
        public string KhachHang { get; set; }
        public DateTime NgayBanHang { get; set; }
        public string DiaChi  { get; set; }
        public string QuanHuyen  { get; set; }
        public string TinhThanh  { get; set; }
        public string XaPhuong  { get; set; }
        public double TongTien { get; set; }
        public int? TrangThai { get; set; }
        public string Sodt { get; set; }
    }
}