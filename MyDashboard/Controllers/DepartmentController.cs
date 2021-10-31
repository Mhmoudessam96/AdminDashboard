using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyDashboard.BL.Interfaces;
using MyDashboard.BL.Models;
using MyDashboard.BL.Repository;
using MyDashboard.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDashboard.Controllers
{
    public class DepartmentController : Controller
    {
        #region Fields
        IDepartmentRep Department;
        private readonly IMapper mapper;
        #endregion

        #region Constructor
        public DepartmentController(IDepartmentRep _Department , IMapper _mapper)
        {
            Department = _Department;
            mapper = _mapper;
        }
        #endregion

        #region Actions
        public IActionResult Index()
        {
            var Result = Department.Get();
            var data = mapper.Map<IEnumerable<DepartmentVM>>(Result);
            
            return View(data);
        }






        // ************************************ create Function *******************************
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DepartmentVM model)
        {
            try
            {
                if (ModelState.IsValid) 
                {
                    var data = mapper.Map<Department>(model);
                    Department.Create(data);
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (Exception )
            {
                return View();
                
            }
            
        }

        // ************************************ End create Function *******************************

        // ************************************ Update Function *******************************
        [HttpGet]
        public IActionResult Edit( int id)
        {
             var data = mapper.Map<DepartmentVM>(Department.GetById(id));
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(DepartmentVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Department>(model);
                    Department.update(data);
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (Exception)
            {
                return View();

            }
        }
        // ************************************ End Update Function *******************************

        // ************************************ Delete Function *******************************
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = mapper.Map<DepartmentVM>(Department.GetById(id));
            return View(data);
        }


        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {


            try
            {
                var OldData = Department.GetById(id);
                Department.Delete(OldData);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                var data = mapper.Map<DepartmentVM>(Department.GetById(id));
                return View(data);
            }
        }

        // ************************************ End Delete Function *******************************

        // ************************************    Details Function *******************************
       
        public IActionResult Details(int id)
        {
            var data = mapper.Map<DepartmentVM>(Department.GetById(id));
            return View(data);
        }

        #endregion


    }
}
