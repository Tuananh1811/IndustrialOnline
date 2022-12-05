using System;
using System.Collections.Generic;
using System.Text;

namespace CNCIndustrial.Data.Entities
{
  public  class EmployeeTranslation
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public string LanguageId { get; set; }

        public string Position { set; get; }

        public string Name { set; get; }

        public string Introduce { get; set; }

        public EmployeeUser Employee { get; set; }

        public Language Languages { get; set; }



    }
}
