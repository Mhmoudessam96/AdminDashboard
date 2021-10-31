using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyDashboard.DAL.Entity;
namespace MyDashboard.DAL.Database
{
    public class MyDashboardContext : IdentityDbContext
    {

        public MyDashboardContext( DbContextOptions<MyDashboardContext> opts) : base (opts)
        {

        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }

        public DbSet<Country> Country { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<District> District { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("server = . ; database = MyDashboard ; Integrated Security = true");
        //}
    }
}
