namespace DO_AN_SEM3.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateOrder { get; set; }

        public int? UserId { get; set; }

        [StringLength(250)]
        public string HoTen { get; set; }

        [StringLength(11)]
        public string Sdt { get; set; }

        public int? XaPhuongId { get; set; }

        [StringLength(250)]
        public string DiaChi { get; set; }

        public bool? IsDefault { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public virtual User User { get; set; }

        public virtual XaPhuong XaPhuong { get; set; }
    }
}
