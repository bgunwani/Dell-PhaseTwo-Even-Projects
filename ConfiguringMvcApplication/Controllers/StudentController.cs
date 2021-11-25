using ConfiguringMvcApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfiguringMvcApplication.Controllers
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
            ViewBag.Message = "Manage Students";
            ViewBag.StudentCount = students.Count;
            ViewBag.StudentList = students;
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
