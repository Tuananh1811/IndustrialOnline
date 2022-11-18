using CNCIndustrial.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CNCIndustrial.Data.Entities
{
  public  class Contact
    {
        public int Id { set; get; }
        public Guid UserId { set; get; }
        public string Name { set; get; }
        public string Email { set; get; }
        public string Title { set; get; }
        public string PhoneNumber { set; get; }
        public string Message { set; get; }
        public string Iframe { set; get; }
        public string HotlineVN { set; get; }
        public string HotlineEN { set; get; }
        public string HotlineChi { set; get; }
        public string HotlineJa { set; get; }
        public string HotlineKo { set; get; }
        public Status Status { set; get; }
        public AppUser AppUser { set; get; }
    }
}
