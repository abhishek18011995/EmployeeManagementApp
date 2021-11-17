using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementApp.Utilities
{
    public class VaildEmailDomainAttribute: ValidationAttribute
    {
        private readonly string allowedDomain;

        public VaildEmailDomainAttribute(string allowedDomain)
        {
            this.allowedDomain = allowedDomain;
        }

        public override bool IsValid(object value)
        {
            string domainName = (value.ToString().Split("@"))[1];
            return domainName.ToUpper() == allowedDomain.ToUpper();
        }
    }
}
