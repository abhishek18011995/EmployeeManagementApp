using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementApp.Common
{
    public interface IHelpers
    {
       string copyImage(IFormFile Photo);
    }
}
