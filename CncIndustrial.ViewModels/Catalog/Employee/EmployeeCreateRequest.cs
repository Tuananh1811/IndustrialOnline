using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CncIndustrial.ViewModels.Catalog.Employee
{
   public class EmployeeCreateRequest
    {
        [Required(ErrorMessage = "Bạn phải nhập số điện thoại")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập email")]
        public string Email { set; get; }

        [Required(ErrorMessage = "Ảnh đại diện không được để trống")]
        public IFormFile ImagePath { get; set; }

        public string Position { set; get; }

        [Required(ErrorMessage = "Bạn phải nhập tên")]
        public string Name { set; get; }

        public string Introduce { get; set; }

        public string LanguageId { set; get; }

    }
}
