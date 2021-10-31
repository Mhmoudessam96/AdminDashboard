using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDashboard.DAL.Entity
{
    [Table("Country")]
    public class Country
    {
        public int Id { get; set; }

        public string CountryName { get; set; }

        public ICollection <City> City { get; set; }
    }
}
