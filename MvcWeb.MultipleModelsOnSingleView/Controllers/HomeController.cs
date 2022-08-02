using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcWeb.MultipleModelsOnSingleView.Models;

namespace MvcWeb.MultipleModelsOnSingleView.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        // Way 1 using View Model 
        public ActionResult Index()
        {
            IndexViewModel objIvm = new IndexViewModel();
            objIvm.employees = GetEmployees();
            objIvm.students = GetStudents();
            return View(objIvm);
        }

        // Way 2 using Dynamic Model 
        public ActionResult Index2()
        {
           
             var employees = GetEmployees();
             var students = GetStudents();

            dynamic Model = new ExpandoObject();
            Model.Employees = employees;
            Model.Students = students;


            return View(Model);
        }

        // Way 3 using Tuples 
        public ActionResult Index3()
        {

            var employees = GetEmployees();
            var students = GetStudents();

            dynamic Model = new Tuple<List<Employee>, List<Student>, string>(employees, students,"Swapnil");
           
            return View(Model);
        }

        // Way 4 using ViewBags 
        public ActionResult Index4()
        {

            var employees = GetEmployees();
            var students = GetStudents();

            ViewBag.Employees = employees;
            ViewBag.Students = students;

            return View();
        }

        // Way 5 using ViewData 
        public ActionResult Index5()
        {

            var employees = GetEmployees();
            var students = GetStudents();

            ViewData["Employees"] = employees;
            ViewData["Students"] = students;

            return View();
        }


        // Way 6 using partial views 
        public ActionResult Index6()
        {

            return View();

        }

        [ChildActionOnly]
        public PartialViewResult Employees()
        {
            var employees = GetEmployees();
            return PartialView("_EmployeeData", employees);

        }
        [ChildActionOnly]
        public PartialViewResult Students()
        {
            var students = GetStudents();
            return PartialView("_StudentData", students);

        }



        private List<Employee> GetEmployees()
        {
            return new List<Employee>()
            {
                new Employee() {ID = 1,Name = "Swapnil", Email = "Swapnil@gmail.com"},
                new Employee() {ID = 2,Name = "Sachin", Email = "Sachin@gmail.com"},
                new Employee() {ID = 3,Name = "Vinay", Email = "Vinay@gmail.com"},
            };
        }

        private List<Student> GetStudents()
        {
            return new List<Student>()
            {
                new Student() {ID = 1,Name = "john", Email = "john@gmail.com"},
                new Student() {ID = 2,Name = "Mark", Email = "Mark@gmail.com"},
                new Student() {ID = 3,Name = "Jenney", Email = "Jenney@gmail.com"}, 
            };
        }
    }
}