using DataPassingTechniquesApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataPassingTechniquesApplication.Controllers
{
    public class StudentController : Controller
    {
        public static List<Student> students = new List<Student>()
        {
            new Student() { StudentId=101, Name="King Kochhar", Gender="Male", City="Delhi" },
            new Student() { StudentId=102, Name="John Smith", Gender="Male", City="Mumbai" },
            new Student() { StudentId=103, Name="Sarah Bowling", Gender="Female", City="Mumbai" },
            new Student() { StudentId=104, Name="Roger Lee", Gender="Male", City="Delhi" },
            new Student() { StudentId=105, Name="Shreya Sharma", Gender="Female", City="Mumbai" }
        };
        public IActionResult Index()
        {
            ViewBag.Message = "Student Management System";
            ViewBag.StudentCount = students.Count;
            ViewBag.StudentList = students;
            return View();
        }

        public IActionResult Details()
        {
            ViewData["Message"] = "Student Management System";
            ViewData["StudentCount"] = students.Count;
            ViewData["StudentList"] = students;
            return View();
        }

        public IActionResult Info()
        {
            TempData["Message"] = "Student Management System";
            TempData["StudentCount"] = students.Count;
            TempData["StudentList"] = students;
            return View();
        }

        public IActionResult RequestA()
        {
            // Case 1:
            //TempData["Msg"] = "Hello World";
            //return RedirectToAction("RequestB");

            // Case 2:
            TempData["Msg"] = "Hello World";
            return View();
        }

        public IActionResult RequestB()
        {
            //Case 1:
            //if(TempData["Msg"] as string != null)
            //    return View();
            //return RedirectToAction("Index");

            // Case 2:
            if(TempData["Msg"] as string != null)
            {
                return View();
            }
            return RedirectToAction("Index");
        }

        public IActionResult BindData()
        {
            return View(students);
        }

    }
}
