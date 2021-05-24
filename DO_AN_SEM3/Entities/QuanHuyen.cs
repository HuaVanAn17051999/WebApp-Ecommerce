namespace DO_AN_SEM3.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QuanHuyen")]
    public partial class QuanHuyen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QuanHuyen()
        {
            XaPhuongs = new HashSet<XaPhuong>();
        }

        public int ID { get; set; }

        [StringLength(100)]
        public string Ten { get; set; }

        [StringLength(20)]
        public string Loai { get; set; }

        public int? TinhThanhID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XaPhuong> XaPhuongs { get; set; }

        public virtual TinhThanh TinhThanh { get; set; }
    }
}
