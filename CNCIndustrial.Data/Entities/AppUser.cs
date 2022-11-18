using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CNCIndustrial.Data.Entities
{
   public class AppUser : IdentityUser<Guid>
    {
        public string FullName { get; set; }
        public DateTime Dob { get; set; }
        public List<Contact> Contacts { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
