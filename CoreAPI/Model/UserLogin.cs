﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreAPI.Model
{
    [Table("UserLoginDetail")]
    public class UserLogin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
        public string UserRole { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee EmployeeDetail { get; set; }
    }
}
