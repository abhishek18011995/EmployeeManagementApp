using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementApp.Common
{
    public class Helpers: IHelpers
    {
        static  IHostingEnvironment hostingEnvironment;
        public Helpers(IHostingEnvironment _hostingEnvironment)
        {
            hostingEnvironment = _hostingEnvironment;
        }

        public string copyImage(IFormFile Photo)
        {
            var folderPath = Path.Combine(hostingEnvironment.WebRootPath, "images");
            string uniqueFileName = Guid.NewGuid() + "_" + Photo.FileName;
            string filePath = Path.Combine(folderPath, uniqueFileName);
            Photo.CopyTo(new FileStream(filePath, FileMode.Create));
            return uniqueFileName;
        }
    }
}
