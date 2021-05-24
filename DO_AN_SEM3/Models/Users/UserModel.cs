using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DO_AN_SEM3.Models.Users
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Họ và tên  không được để trống.")]
        public string HoVaTen { get; set; }
        [Required(ErrorMessage = "Tên đăng nhập không được để trống.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Mật khẩu không được để trống.")]
        public string PassWord { get; set; }
        public int Sdt { get; set; }
        [Compare("PassWord", ErrorMessage = "Xác nhận mật khẩu không đúng !!!")]
        public string ConfirmPass { get; set; }
        public List<string> RoleName { get; set; }
        public int RoleId { get; set; }
        [Required(ErrorMessage = "Giới tính không được để trống.")]
        public bool? GioiTinh { get; set; }

        public UserModel()
        {
            RoleId = 1;
        }
    }
}