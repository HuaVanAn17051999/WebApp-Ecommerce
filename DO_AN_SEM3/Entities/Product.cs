namespace DO_AN_SEM3.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            FeedBacks = new HashSet<FeedBack>();
            OrderDetails = new HashSet<OrderDetail>();
            ThongTinSanPhams = new HashSet<ThongTinSanPham>();
        }

        public int Id { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateCreate { get; set; }

        public bool Status { get; set; }

        public int CategoryId { get; set; }

        public double Price { get; set; }

        public int? Discount { get; set; }

        public string ImagePath { get; set; }

        public int Amount { get; set; }

        public long? ImageSize { get; set; }

        [StringLength(250)]
        public string Seotitle { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FeedBack> FeedBacks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThongTinSanPham> ThongTinSanPhams { get; set; }
    }
}
