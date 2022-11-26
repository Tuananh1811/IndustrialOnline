using System;
using System.Collections.Generic;
using System.Text;

namespace CNCIndustrial.Data.Entities
{
   public class Employee
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Avatar { set; get; }
        public string Email { set; get; }
        public string Position { set; get; }
        public Guid UserId { set; get; }
        public AppUser AppUser { set; get; }
        public List<AboutUsTranslation> AboutUsTranslations { get; set; }
    }
}
