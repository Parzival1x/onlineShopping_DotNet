using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Onlineshopping.Models
{
    [Table("product")]
    public partial class Product
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        [StringLength(255)]
        public string Name { get; set; }
        [Column("description")]
        [StringLength(255)]
        public string Description { get; set; }
        [Column("imageurl")]
        [StringLength(255)]
        public string Imageurl { get; set; }
        [Column("pricing", TypeName = "decimal(18, 2)")]
        public decimal? Pricing { get; set; }
        [Column("shippingcost", TypeName = "decimal(18, 2)")]
        public decimal? Shippingcost { get; set; }
    }
}
