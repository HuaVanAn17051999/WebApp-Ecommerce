namespace DO_AN_SEM3.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FeedBack")]
    public partial class FeedBack
    {
        public int Id { get; set; }

        public int? UserId { get; set; }

        public int? ProductId { get; set; }

        [Column("Feedback")]
        public string Feedback1 { get; set; }

        public DateTime? DateCreate { get; set; }

        public int? Likes { get; set; }

        public int? Dislike { get; set; }

        public virtual Product Product { get; set; }

        public virtual User User { get; set; }
    }
}
