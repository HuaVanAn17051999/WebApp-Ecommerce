namespace DO_AN_SEM3.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThongTinSanPham")]
    public partial class ThongTinSanPham
    {
        public int Id { get; set; }

        [StringLength(250)]
        public string PhuKienDiKem { get; set; }

        [StringLength(250)]
        public string LoaiCongNgheManHinh { get; set; }

        [StringLength(250)]
        public string KichThuocManHinh { get; set; }

        [StringLength(150)]
        public string DoPhanGiai { get; set; }

        [StringLength(150)]
        public string CameraTruoc { get; set; }

        [StringLength(150)]
        public string CameraSau { get; set; }

        [StringLength(250)]
        public string TinhNangCamera { get; set; }

        [StringLength(250)]
        public string DenFlash { get; set; }

        [StringLength(250)]
        public string QuayPhim { get; set; }

        [StringLength(150)]
        public string Ram { get; set; }

        [StringLength(150)]
        public string Rom { get; set; }

        [StringLength(150)]
        public string TrongLuong { get; set; }

        [StringLength(150)]
        public string KichThuoc { get; set; }

        [StringLength(150)]
        public string ChipSet { get; set; }

        [StringLength(250)]
        public string ChipDoHoa { get; set; }

        [StringLength(150)]
        public string LoaiPin { get; set; }

        public int? productId { get; set; }

        public virtual Product Product { get; set; }
    }
}
