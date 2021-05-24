using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DO_AN_SEM3.Models.Category
{
    public class CategoryModel
    {
        [Required]
        public string Name { get; set; }
    }
}