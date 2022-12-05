using System;
using System.Collections.Generic;
using System.Text;

namespace CNCIndustrial.Data.Entities
{
   public class EmployeeUser
    {
        public int Id { set; get; }
       
        public string PhoneNumber { get; set; }

        public string Email { set; get; }

        public string ImagePath { get; set; }

        public List<EmployeeTranslation> EmployeeTranslations { get; set; }
    }
}
