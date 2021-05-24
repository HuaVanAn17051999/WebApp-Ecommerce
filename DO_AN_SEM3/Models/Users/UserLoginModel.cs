using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DO_AN_SEM3.Models.Users
{
    public class UserLoginModel
    {

        [Required(ErrorMessage ="Tên đăng nhập không được để trống.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống.")]
        public string PassWord { get; set; }
    }
}