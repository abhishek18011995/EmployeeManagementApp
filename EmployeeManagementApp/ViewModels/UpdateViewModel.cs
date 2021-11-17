using EmployeeManagementApp.Models;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementApp.ViewModels
{
    public class UpdateViewModel: CreateViewModel
    {
        public string ExistingPhotoPath { get; set; }
    }
}
