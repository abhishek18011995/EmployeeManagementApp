using System;
using System.IO;
using EmployeeManagementApp.Models;
using EmployeeManagementApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManagementApp.Controllers
{   
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IHostingEnvironment hostingEnvironment;

        public HomeController(IEmployeeRepository _employeeRepository, IHostingEnvironment _hostingEnvironment)
        {
            employeeRepository = _employeeRepository;
            hostingEnvironment = _hostingEnvironment;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var assemblyName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            var employeeList = employeeRepository.GetAllEmployees();
            return View(employeeList);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Details(int id)
        {
            //throw new Exception("Error occured in details page");
            var employee = employeeRepository.GetEmployee(id);

            if (employee == null)
            {
                Response.StatusCode = 404;
                return View("EmployeeNotFound", id);
            }

            return View(employee);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateViewModel employee)
        {
            string uniqueFileName = null;

            if (ModelState.IsValid)
            {
                if (!employeeRepository.EmployeeAlreadyExists(employee.Email))
                {
                    if (employee.Photo != null)
                    {
                        uniqueFileName = ProcessUploadedFile(employee.Photo);
                    }

                    var _employee = new Employee()
                    {
                        Id = employee.Id,
                        Email = employee.Email,
                        Department = employee.Department,
                        PhotoPath = uniqueFileName,
                        Name = employee.Name
                    };

                    var employeeResp = employeeRepository.AddEmployee(_employee);
                    return RedirectToAction("Details", new { id = employeeResp.Id });
                }
                ModelState.AddModelError("DublicateEmail", "Employee already exists");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var employee = employeeRepository.GetEmployee(id);
            var _employee = new UpdateViewModel()
            {
                Id = employee.Id,
                Email = employee.Email,
                Department = employee.Department,
                Name = employee.Name,
                ExistingPhotoPath = employee.PhotoPath
            };
            return View(_employee);
        }

        [HttpPost]
        public IActionResult Update(UpdateViewModel updateEmployee)
        {
            if (ModelState.IsValid)
            {
                var employee = new Employee()
                {
                    Id = updateEmployee.Id,
                    Email = updateEmployee.Email,
                    Department = updateEmployee.Department,
                    Name = updateEmployee.Name,
                    PhotoPath = updateEmployee.ExistingPhotoPath
                };

                if (updateEmployee.Photo != null)
                {
                    if (employee.PhotoPath != null)
                    {
                        string deletionPath = Path.Combine(hostingEnvironment.WebRootPath, "images", employee.PhotoPath);
                        System.IO.File.Delete(deletionPath);
                    }
                    employee.PhotoPath = ProcessUploadedFile(updateEmployee.Photo);
                }
                employeeRepository.UpdateEmployee(employee);
                return RedirectToAction("details", new { id = employee.Id });
            }

            return View();
        }

        private string ProcessUploadedFile(IFormFile Photo)
        {
            var folderPath = Path.Combine(hostingEnvironment.WebRootPath, "images");
            string uniqueFileName = Guid.NewGuid() + "_" + Photo.FileName;
            string filePath = Path.Combine(folderPath, uniqueFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                Photo.CopyTo(fileStream);
            }
            return uniqueFileName;
        }
    }
}
