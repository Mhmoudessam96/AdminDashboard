﻿using MyDashboard.BL.Interfaces;
using MyDashboard.DAL.Database;
using MyDashboard.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDashboard.BL.Repository
{
    public class CountryRep : ICountryRep
    {
        private readonly MyDashboardContext db;

        public CountryRep(MyDashboardContext db)
        {
            this.db = db;
        }

        public IEnumerable<Country> Get()
        {
            var data = db.Country.Select(a => a);
            return data;

        }

        public Country GetById(int id)
        {
            var data = db.Country.Where(a => a.Id == id).FirstOrDefault();
            return data;
        }
    }
}
