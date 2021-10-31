using Microsoft.AspNetCore.Http;
using MyDashboard.DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDashboard.BL.Models
{
    public class EmployeeVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Employee Name Required")]
        [MinLength(3, ErrorMessage = "Min 3")]
        [MaxLength(50, ErrorMessage = "Max 50")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Salary Required")]
        [Range(2000,30000, ErrorMessage = "Range between 2000 : 30000 ")]
        public double Salary { get; set; }

        [Required(ErrorMessage = "HireDate Required")]
        public DateTime HireDate { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public string Notes { get; set; }
        
        public string Photo { get; set; }
        public string CV { get; set; }
        public IFormFile PhotoURL { get; set; }
        public IFormFile CVURL { get; set; }

        [Required(ErrorMessage = "DepartmentId Required")]
        public int DepartmentId { get; set; }
        public int DistrictId { get; set; }


        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
        public District District { get; set; }
    }
}
