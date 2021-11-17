using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagementApp.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext employeeDbContext;

        public EmployeeRepository(EmployeeDbContext _employeeDbContext)
        {
            this.employeeDbContext = _employeeDbContext;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return employeeDbContext.Employees;
        }

        public Employee GetEmployee(int id)
        {
            var employee = employeeDbContext.Employees.Find(id);
            return employee;
        }

        public Employee AddEmployee(Employee employee)
        {
            employeeDbContext.Employees.Add(employee);
            employeeDbContext.SaveChanges();
            return employee;
        }

        public Employee UpdateEmployee(Employee employee)
        {
            employeeDbContext.Employees.Update(employee);
            employeeDbContext.SaveChanges();
            return employee;
        }

        public bool EmployeeAlreadyExists(string email)
        {
            return employeeDbContext.Employees.Any(emp => emp.Email == email); ;
        }
    }
}
