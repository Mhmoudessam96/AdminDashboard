using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyDashboard.BL.Helper;
using MyDashboard.BL.Interfaces;
using MyDashboard.BL.Models;
using MyDashboard.BL.Repository;
using MyDashboard.DAL.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyDashboard.Controllers
{
    public class EmployeesController : Controller
    {
        #region Fields
        private readonly IEmployeeRep Employee ;
        private readonly IDepartmentRep department;
        private readonly ICountryRep country;
        private readonly ICityRep city;
        private readonly IDistrictRep district;
        private readonly IMapper mapper;

        #endregion

        #region Constructor
        public EmployeesController(IEmployeeRep _Employee , IDepartmentRep _Department, ICountryRep _Country, ICityRep _City, IDistrictRep _District, IMapper _mapper)
        {
            Employee = _Employee;
            department = _Department;
            country = _Country;
            city = _City;
            district = _District;
            mapper = _mapper;
        }

        #endregion

        #region Actions
        public IActionResult Index()
        {
            var Result = Employee.Get();
            var data = mapper.Map<IEnumerable<EmployeeVM>>(Result);
            return View(data);
        }


        public IActionResult Create()
        {
            ViewBag.DepartmentList = new SelectList(department.Get(), "Id", "DepartmentName");
            ViewBag.CountryList = new SelectList(country.Get(), "Id", "CountryName");

            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {


                    var PhotoName = FilesUpload.UploadFiles("/Files/Photos/" , model.PhotoURL);
                    var CVName = FilesUpload.UploadFiles("/Files/Docx/" , model.CVURL);
                    var data = mapper.Map<Employee>(model);
                    data.Photo = PhotoName;
                    data.CV = CVName;
                    Employee.Create(data);
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (Exception)
            {
                ViewBag.DepartmentList = new SelectList(department.Get(), "Id", "DepartmentName");
                ViewBag.CountryList = new SelectList(country.Get(), "Id", "CountryName");
                return View(model);

            }
            
        }

        public IActionResult Edit(int id)
        {
            var data = mapper.Map<EmployeeVM>(Employee.GetById(id));
            ViewBag.DepartmentList = new SelectList(department.Get(), "Id", "DepartmentName",data.DepartmentId);

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Employee>(model);
                    Employee.update(data);
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (Exception)
            {
                ViewBag.DepartmentList = new SelectList(department.Get(), "Id", "DepartmentName", model.DepartmentId);

                return View();

            }

        }

        public IActionResult Delete(int id)
        {
            var data = mapper.Map<EmployeeVM>(Employee.GetById(id));
            ViewBag.DepartmentList = new SelectList(department.Get(), "Id", "DepartmentName", data.DepartmentId);
            return View(data);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {


            try
            {

                var OldData = Employee.GetById(id);



                FilesUpload.DeleteFiles("/Files/Photos/", OldData.Photo);
                FilesUpload.DeleteFiles("/Files/Docx/", OldData.CV);


                Employee.Delete(OldData);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                var data = Employee.GetById(id);
                return View(data);
            }
        }

        public IActionResult Details(int id)
        {
            var data = mapper.Map<EmployeeVM>(Employee.GetById(id));
            return View(data);
        }

        #endregion

        #region Ajax 
        // Get All Citeis by Country Id
        [HttpPost]
        public JsonResult GetAllCiteis(int CntryId)
        {
            var data = city.Get().Where(a => a.CountryId == CntryId);
            return Json(data);

        }

        // Get All Districts by City Id
        [HttpPost]
        public JsonResult GetAllDistricts(int CtyId)
        {
            var data = district.Get().Where(a => a.CityId == CtyId);
            return Json(data);

        }
        #endregion
    }
}
