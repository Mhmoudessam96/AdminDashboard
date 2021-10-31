using MyDashboard.BL.Models;
using MyDashboard.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDashboard.BL.Interfaces
{
    public interface IEmployeeRep
    {
        IEnumerable<Employee> Get();
        Employee GetById(int id);
        IEnumerable<Employee> Paging(int Index,int PageSize);
        Employee Create(Employee obj);
        Employee update(Employee obj);
        Employee Delete(Employee obj);
    }
}
