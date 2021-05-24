using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CLIENT.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Tên đăng nhập không được để trông !!!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Mật khẩu không được để trông !!!")]
        public string Password { get; set; }
    }
}