using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DO_AN_SEM3.Models
{
    public class QuanLyHangTonKhoModel
    {
        public string  TenSP { get; set; }
        public string  AnhSP { get; set; }
        public double  Gia { get; set; }
        public int SoLuongBanDau { get; set; }
        public List<int>  DaBan { get; set; }
        public int  ConLai { get; set; }
    }
}