using System;
using System.Collections.Generic;
using System.Text;

namespace CNCIndustrial.Data.Entities
{
   public class News
    {
       
        public int Id { get; set; }

       
        public string Title { get; set; }

       
        public string DescriShort { get; set; }

     
        public string DescriTall { get; set; }

      
        public DateTime? NgayTao { get; set; }

       
        public DateTime? NgayCapNhat { get; set; }

     
        public string TenDangNhap { get; set; }

        
        public string HinhAnhMinhHoa { get; set; }
        public List<ProjectImage> NewsImages { get; set; }
        public List<NewsTranslation> NewsTranslations { get; set; }
        // public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
