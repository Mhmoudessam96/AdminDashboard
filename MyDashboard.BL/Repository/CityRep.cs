using MyDashboard.BL.Interfaces;
using MyDashboard.DAL.Database;
using MyDashboard.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDashboard.BL.Repository
{
    public class CityRep : ICityRep
    {
        private readonly MyDashboardContext db;

        public CityRep(MyDashboardContext db)
        {
            this.db = db;
        }

        public IEnumerable<City> Get()
        {
            var data = db.City.Select(a => a);
            return data;

        }

        public City GetById(int id)
        {
            var data = db.City.Where(a => a.Id == id).FirstOrDefault();
            return data;
        }
    }
}
