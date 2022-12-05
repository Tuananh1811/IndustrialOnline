using System;
using System.Collections.Generic;
using System.Text;

namespace CNCIndustrial.Data.Entities
{
   public class NewsTable
    {
       
        public int Id { get; set; }
       
        public string Title { get; set; }
      
        public DateTime? NgayTao { get; set; }

       
        public DateTime? NgayCapNhat { get; set; }
        
        public string HinhAnhMinhHoa { get; set; }

        public int ViewCount { get; set; }

        public List<NewsTranslation> NewsTranslations { get; set; }

    }
}
