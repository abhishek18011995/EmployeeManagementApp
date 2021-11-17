using EmployeeManagementApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementApp.Extensions
{
    public static class Extenions
    {
        public static void SeedEmployeeDb(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 1,
                Name = "Mark",
                Department = Dept.IT,
                Email = "mark@pragimtech.com"
            },
           new Employee
           {
               Id = 2,
               Name = "John",
               Department = Dept.HR,
               Email = "johny@pragimtech.com"
           });
        }
    }
}
