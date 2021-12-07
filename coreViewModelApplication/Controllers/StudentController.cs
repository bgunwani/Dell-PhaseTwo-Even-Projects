using coreViewModelApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreViewModelApplication.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            Student student = new Student()
            {
                StudentId = 1001,
                Name = "King Kochhar",
                Gender = "Male",
                Subject = "Computer Science"
            };
            Address address = new Address()
            {
                StreetName = "Civil Lines",
                City = "Delhi",
                State = "Delhi",
                Pincode = "110088",
                Country = "India",
                StudentId = 1001
            };
            StudentAddressModel studentAddressModel = new StudentAddressModel()
            {
                Student = student,
                Address = address,
                Message = "Hello"
            };
            return View(studentAddressModel);
        }
    }
}
