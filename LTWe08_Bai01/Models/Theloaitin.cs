namespace LTWe08_Bai01.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Theloaitin")]
    public partial class Theloaitin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDLoai { get; set; }

        [StringLength(100)]
        public string Tentheloai { get; set; }
    }
}
