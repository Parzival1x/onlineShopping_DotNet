using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Onlineshopping.Models
{
    [Table("cart")]
    public partial class Cart
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("product")]
        [StringLength(255)]
        public string Product { get; set; }
        [Column("quantities")]
        public int? Quantities { get; set; }
        [Column("user")]
        [StringLength(255)]
        public string User { get; set; }
    }
}
