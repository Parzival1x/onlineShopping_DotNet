using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Onlineshopping.Models
{
    [Table("user")]
    public partial class User
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("email")]
        [StringLength(255)]
        public string Email { get; set; }
        [Column("password")]
        [StringLength(255)]
        public string Password { get; set; }
        [Column("username")]
        [StringLength(255)]
        public string Username { get; set; }
        [Column("purchasehistory")]
        [StringLength(255)]
        public string Purchasehistory { get; set; }
        [Column("shipingaddress")]
        public string Shipingaddress { get; set; }
    }
}
