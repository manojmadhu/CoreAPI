using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreAPI.Model
{
    [Table("EmployeeDetail")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }
        [Required]
        [StringLength(250)]
        public string? FullName { get; set; }
        [Required]
        [StringLength(250)]
        public string? EmailAddress { get; set; }
        public double Salary { get; set; }
        public DateTime JoinDate { get; set; }


    }
}
