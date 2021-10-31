using MyDashboard.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDashboard.BL.Helper
{
    public class ApiResponse<TEntity> where TEntity : class
    {

        public Respons Respons { get; set; }
        public IEnumerable<TEntity> Records { get; set; }
        public TEntity Record { get; set; }

    }
}
