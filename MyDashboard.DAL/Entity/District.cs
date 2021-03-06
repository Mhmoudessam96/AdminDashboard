using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDashboard.DAL.Entity
{
    [Table("District")]
    public class District
    {
        public int Id { get; set; }

        public string DistrictName { get; set; }

        public int CityId { get; set; }

        public City City { get; set; }

        public ICollection<Employee> Employee { get; set; }
    }
}
