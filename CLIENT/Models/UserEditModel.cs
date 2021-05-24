using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CLIENT.Models
{
    public class UserEditModel
    {
        [Required(ErrorMessage = "Họ tên không được để trống !!!")]
        public string HoTen { get; set; }
        [Required(ErrorMessage = "Tên đăng nhập không được để trống !!!")]
        public string TenDangNhap { get; set; }
        [Required(ErrorMessage = "Mật khẩu không được để trống !!!")]
        public int? SoDT { get; set; }
        public bool? GioiTinh { get; set; }
        [Required(ErrorMessage = "Email không được để trống !!!")]
        public string Email { get; set; }
        public string MatKhau { get; set; }
        public string MatKhauCu { get; set; }
    }   
}