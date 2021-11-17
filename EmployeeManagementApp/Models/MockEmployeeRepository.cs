using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagementApp.Models
{
    public class MockEmployeeRepository 
    {
        private List<Employee> employeesList;
        public MockEmployeeRepository()
        {
            employeesList = new List<Employee>();
            employeesList.Add(new Employee() { Id = 1, Name = "Abhi", Department = Dept.IT, Email = "abhi@g.com"});
            employeesList.Add(new Employee() { Id = 2, Name = "Suraj", Department = Dept.Payroll, Email = "suraj@g.com" });
            employeesList.Add(new Employee() { Id = 3, Name = "Anuj", Department = Dept.IT, Email = "anuj@g.com" });
            employeesList.Add(new Employee() { Id = 4, Name = "Ravi", Department = Dept.HR, Email = "ravi@g.com" });
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return employeesList;
        }

        public Employee GetEmployee(int _id)
        {
            return employeesList.FirstOrDefault(emp => emp.Id == _id);
        }
    }
}
