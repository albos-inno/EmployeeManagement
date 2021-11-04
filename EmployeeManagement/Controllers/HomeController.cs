using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }


        //public JsonResult Index(){return Json(new {id = 1, name = "Albos"});}
        public string Index()
        {
            string tempString = "";

            foreach(Employee singleEmployee in _employeeRepository.GetAllEmployees())
            {
                tempString = tempString + "\n\r" + "Id = " + singleEmployee.Id ;
            }
                    

            return tempString;
            //return _employeeRepository.GetEmployee(3).Name;
        }


        //public JsonResult Details()
        //{
        //    Employee model = _employeeRepository.GetEmployee(1);
        //    return Json(model);
        //}

        //public ObjectResult Details()
        //{
        //    Employee model = _employeeRepository.GetEmployee(1);
        //    return new ObjectResult(model);
        //}


        //public ViewResult Details()
        public ViewResult Details(int? id)
        {
            Console.WriteLine("THIS IS AN ID = " + id.ToString());

            Employee model = _employeeRepository.GetEmployee((int)id);

            ViewData["Employee"] = model;
            ViewData["PageTitle"] = "Employee Details";



            return View("FinalTest");




            //return View(model); // as well as return View() looks for a view file with the same name as the action method, in our case /details



            //return View("Test"); // in this case the absolute path does not need to be specified, it knows by defult that it's in folder Views and the file has the suffix .cshtml

            //return View("MyViews/Test.cshtml"); // in the case where the .cshtml file is NOT located in the defualt folder Views,
            //                                    // but in another folder in the SAME HREARCHY LEVEL as Views folder,
            //                                    // we need to specify the absolute path as well as the suffix .cshtml .
            //                                    // This type of absolute path works as well "~/MyViews/Test.cshtml"

            //return View("../RelativeFolder/Test"); // in the case where the .cshtml file is NOT located in the defualt folder Views,
            //                                     // but in another folder INSIDE Views folder,
            //                                     // we need to specify the relative path but NOT the suffix .cshtml .
            //                                     // If we want to relatively jump on MyViews folder and use the Test.cshtml file there,
            //                                     // We can do so by using this type of string folder path "../../MyViews/Test"






        }



        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public RedirectToActionResult Create(Employee employee)
        {
            Console.WriteLine("REACHED");
            
            Employee newEmployee = _employeeRepository.Add(employee);


            Console.WriteLine(newEmployee.Id);
            Console.WriteLine(newEmployee.Name);
            Console.WriteLine(newEmployee.Email);
            Console.WriteLine(newEmployee.Departament);


            return RedirectToAction("details", new { id = newEmployee.Id });
        }

    }
}
