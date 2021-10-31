using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MyDashboard.DAL.Entity
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        [Required]
        public string Name { get; set; }
        public double Salary { get; set; }
        [StringLength(50)]
        [Required]
        public DateTime HireDate { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public string Notes { get; set; }
        public string Photo { get; set; }
        public string CV { get; set; }

        public int DepartmentId { get; set; }

        public int DistrictId { get; set; }


        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
        public District District { get; set; }

    }
}
