using MyDashboard.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDashboard.BL.Interfaces
{
    public interface ICountryRep
    {
        IEnumerable<Country> Get();

        Country GetById(int id);

    }
}
