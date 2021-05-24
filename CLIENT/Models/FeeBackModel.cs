using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CLIENT.Models
{
    public class FeeBackModel
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public string feedBack { get; set; }
        public string  UserName { get; set; }
        public DateTime? Date_of_question { get; set; }
    }
}