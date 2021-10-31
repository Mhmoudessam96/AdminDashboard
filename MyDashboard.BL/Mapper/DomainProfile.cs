using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MyDashboard.BL.Models;
using MyDashboard.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDashboard.BL.Mapper
{
    public class DomainProfile : Profile
    {

        public DomainProfile()
        {
            CreateMap<Department,DepartmentVM>();
            CreateMap<DepartmentVM, Department>();

            CreateMap<Employee, EmployeeVM>();
            CreateMap<EmployeeVM, Employee>();

            CreateMap<Country, CountryVM>();
            CreateMap<CountryVM, Country>();

            CreateMap<City, CityVM>();
            CreateMap<CityVM, City>();

            CreateMap<District, DistrictVM>();
            CreateMap<DistrictVM, District>();

            CreateMap<IdentityUser, RegistrationVM>();
            CreateMap<RegistrationVM, IdentityUser>();
        }
    }
}
