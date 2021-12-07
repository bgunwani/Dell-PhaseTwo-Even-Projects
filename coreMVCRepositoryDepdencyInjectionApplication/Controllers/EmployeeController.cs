using coreMVCRepositoryDepdencyInjectionApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreMVCRepositoryDepdencyInjectionApplication.Controllers
{
    public class EmployeeController : Controller
    {

        // EmployeeRepository employeeRepository = new EmployeeRepository();

        IEmployeeRepository employeeRepository;
        public EmployeeController(IEmployeeRepository repository)
        {
            employeeRepository = repository;
        }

        public IActionResult Index()
        {
            return View(employeeRepository.GetEmployees());
        }

        public IActionResult Details(int id)
        {
            return View(employeeRepository.GetEmployeeById(id));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            employeeRepository.AddEmployee(employee);
            return RedirectToAction("Index");
        }

        public IActionResult Data([FromServices]IEmployeeRepository repository)
        {
            return View(repository.GetEmployees());
        }

        public IActionResult Info()
        {
            var service = this.HttpContext.RequestServices;
            var _repository = (IEmployeeRepository)service.GetService(typeof(IEmployeeRepository));
            var employees = _repository.GetEmployees();
            return View(employees);
        }
    }
}
