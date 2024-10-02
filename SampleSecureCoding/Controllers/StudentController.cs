using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleSecureCoding.Data;
using SampleSecureCoding.Models;

namespace SampleSecureCoding.Controllers 
{

    public class StudentController : Controller
    {
        private readonly IStudent _studentData;
        public StudentController(IStudent studentData)
        {
            _studentData = studentData;
        }

         public IActionResult Create()
         {
            return View();
         }
        [HttpPost]
        public IActionResult Create(Student student){
        if (ModelState.IsValid)
        {
            try
            {
                _studentData.AddStudent(student);
                return RedirectToAction("Index");
            }
            catch (System.Exception ex)
            {
               ViewBag.Error = ex.Message;
            }
        }
        return View(student);
        }
        public IActionResult Index(){
        var students = _studentData.GetStudents();
        return View(students);
        }

        public IActionResult Edit(){
            return View();
        }
        public IActionResult Delete(){
            return View();
        }
    }
    
}