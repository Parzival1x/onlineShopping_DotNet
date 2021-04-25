using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Onlineshopping.Models
{
    [Table("comment")]
    public partial class Comment
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("product")]
        [StringLength(255)]
        public string Product { get; set; }
        [Column("user")]
        [StringLength(255)]
        public string User { get; set; }
        [Column("rating")]
        [StringLength(255)]
        public string Rating { get; set; }
        [Column("imageurl")]
        [StringLength(255)]
        public string Imageurl { get; set; }
        [Column("text")]
        public string Text { get; set; }
    }
}
