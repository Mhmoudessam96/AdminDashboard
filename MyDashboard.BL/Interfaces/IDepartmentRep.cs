using MyDashboard.BL.Models;
using MyDashboard.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDashboard.BL.Interfaces
{
    public interface IDepartmentRep
    {
        IEnumerable<Department> Get();
        Department GetById(int id);
        IEnumerable<Department> SearchByName( string Name);
        void Create(Department obj);
        void update(Department obj);
        void Delete(Department obj);
    }
}
