namespace DO_AN_SEM3.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrderDetail
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public double? Price { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOrder { get; set; }

        public int Id { get; set; }

        public int? TrangThai { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}
