using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreMVCRepositoryDepdencyInjectionApplication.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public static List<Employee> employees = new List<Employee>()
        {
            new Employee() { EmployeeId=1001, Name="King Kochhar", Gender="Male", Designation="Manager" },
            new Employee() { EmployeeId=1002, Name="Sarah Bowling", Gender="Female", Designation="Developer" },
            new Employee() { EmployeeId=1003, Name="Shreya Sharma", Gender="Female", Designation="Tester" },
            new Employee() { EmployeeId=1004, Name="Roger Lee", Gender="Male", Designation="Manager" },
        };
        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }
        public Employee GetEmployeeById(int employeeId)
        {
            return employees.Where(e => e.EmployeeId == employeeId).FirstOrDefault();
        }
        public IList<Employee> GetEmployees()
        {
            return employees;
        }
    }
}
