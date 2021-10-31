using Microsoft.EntityFrameworkCore;
using MyDashboard.BL.Interfaces;
using MyDashboard.BL.Models;
using MyDashboard.DAL.Database;
using MyDashboard.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDashboard.BL.Repository
{
    public class EmployeeRep : IEmployeeRep
    {
        private readonly MyDashboardContext db;

        public EmployeeRep(MyDashboardContext db)
        {
            this.db = db;
        }

        public IEnumerable<Employee> Get()
        {
            var data = db.Employee.Include("Department").Select(a => a);
            return data;

        }

        public Employee GetById(int id)
        {
            var data = db.Employee.Include("Department").Where(a => a.Id == id).FirstOrDefault();
            return data;
        }
        public Employee Create(Employee obj)
        {            
            db.Employee.Add(obj);
            db.SaveChanges();
            return obj;
        }



        public Employee update(Employee obj)
        {
            db.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return obj;
        } 

        public Employee Delete(Employee obj)
        {
            
            db.Employee.Remove(obj);
            db.SaveChanges();
            return obj;
        }

        public IEnumerable<Employee> Paging(int Index, int PageSize)
        {
            var data = db.Employee.Skip(Index).Take(PageSize);
            return data;
        }

        
    }
}
