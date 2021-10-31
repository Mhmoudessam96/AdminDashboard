using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyDashboard.DAL.Entity
{
    [Table("Department")]
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        [Required]
        public string DepartmentName { get; set; }

        [StringLength(50)]
        [Required]
        public string DepartmentCode { get; set; }

        public ICollection<Employee> Employee { get; set; }

    }
}
