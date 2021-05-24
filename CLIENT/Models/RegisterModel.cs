using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CLIENT.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Họ tên không được để trống !!!")]
        public string HoTen { get; set; }
        [Required(ErrorMessage = "Tên đăng nhập không được để trống !!!")]
        [RegularExpression("^[-_,A-Za-z0-9]*$", ErrorMessage = "Tên đăng nhập không được chứa kí tự đặc biệt !!!")]
        public string TenDangNhap { get; set; }
        [DataType(DataType.PhoneNumber)]
        public int SoDT { get; set; }
        public bool? GioiTinh { get; set; }
        [Required(ErrorMessage = "Mật khẩu không được để trống !!!")]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage =("Mật khẩu chứa ít nhất một chứ cái viết hoa, ít nhất một chữ viết thường, ít nhất một chữ số, ít nhất một ký tự đặc biệt .Độ dài tối thiểu 8 !!!"))]
        public string MatKhau { get; set; }
        [Required(ErrorMessage = "Xác nhận mật khẩu không được để trống !!!")]
        [DataType(DataType.Password)]
        [Compare("MatKhau", ErrorMessage = "Xác nhận mật khẩu không chính xác !!!" )]
        public string XacNhanMatKhau { get; set; }
        [EmailAddress(ErrorMessage = "Địa chỉ email không hợp lệ !!!")]
        public string Email { get; set; }
        public int RoleId { get; set; }
        public RegisterModel()
        {
            RoleId = 1;
        }
    }
}