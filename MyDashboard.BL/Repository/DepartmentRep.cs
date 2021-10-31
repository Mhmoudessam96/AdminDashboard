using MyDashboard.BL.Interfaces;
using MyDashboard.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDashboard.DAL.Database;
using MyDashboard.BL.Models;

namespace MyDashboard.BL.Repository
{
    public class DepartmentRep : IDepartmentRep
    {
        private readonly MyDashboardContext db;

        public DepartmentRep(MyDashboardContext db)
        {
            this.db = db;
        }

        public IEnumerable<Department> Get()
        {
            var data = db.Department.Select(a => a);
            return data;

        }

        public Department GetById(int id)
        {
            var data = db.Department.Where(a => a.Id == id).FirstOrDefault(); 
            return data;
        }
        public void Create(Department obj)
        {
          
            db.Department.Add(obj);
            db.SaveChanges();
        }

      

        public void update(Department obj)
        {


            db.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(Department obj)
        {
            
            db.Department.Remove(obj);
            db.SaveChanges();
        }

        public IEnumerable<Department> SearchByName(string Name)
        {
            var data = db.Department.Where(a => a.DepartmentName == Name).Select(a => a);
            return data;
        }
    }
}
