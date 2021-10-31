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
    public class DistrictRep : IDistrictRep
    {
        private readonly MyDashboardContext db;

        public DistrictRep(MyDashboardContext db)
        {
            this.db = db;
        }

        public IEnumerable<District> Get()
        {
            var data = db.District.Select(a => a);
            return data;

        }

        public District GetById(int id)
        {
            var data = db.District.Where(a => a.Id == id).FirstOrDefault();
            return data;
        }
    }
}
