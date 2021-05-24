using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DO_AN_SEM3.Models.Product
{
    public class ProductModel
    {
        [Required(ErrorMessage = "Tên sản phẩm không được để trống !!!.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Số lượng không được để trống !!!")]
        public int Amount { get; set; }
        public int? Discount { get; set; }
        [Required(ErrorMessage = "Giá sản phẩm không được để trống !!!")]
        public double Price { get; set; }
        public int CategoryId { get; set; }
        //[Required(ErrorMessage = "Ảnh sản phẩm không được để trống.")]
        public HttpPostedFileBase ImageFile { get; set; }
        public bool TrangThai{ get; set; }
        public string LoaiSanPham { get; set; }
        public string  ImagePath { get; set; }
        public string SeletecLoaiSPJson { get; set; }
    }
}