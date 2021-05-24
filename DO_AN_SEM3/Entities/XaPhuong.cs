namespace DO_AN_SEM3.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XaPhuong")]
    public partial class XaPhuong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public XaPhuong()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Ten { get; set; }

        [StringLength(20)]
        public string Loai { get; set; }

        public int? TinhThanhID { get; set; }

        public int? QuanHuyenID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        public virtual QuanHuyen QuanHuyen { get; set; }

        public virtual TinhThanh TinhThanh { get; set; }
    }
}
