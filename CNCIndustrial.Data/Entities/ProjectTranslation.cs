using System;
using System.Collections.Generic;
using System.Text;

namespace CNCIndustrial.Data.Entities
{
   public class ProjectTranslation
    {
        public int Id { set; get; }

        public int ProjectId { set; get; }

        public string LanguageId { get; set; }

        public string Name { set; get; }

        public string Description { set; get; }

        public string Details { set; get; }

        public string SeoDescription { set; get; }

        public string SeoTitle { set; get; }

        public string TotalArea { set; get; }

        public string VacantArea { set; get; }

        public string Investor { set; get; }

        public string SeoAlias { get; set; }

        public string MainFunction1 { set; get; }

        public string MainFunction2 { set; get; }

        public string MainFunction3 { set; get; }

        public string MainFunction4 { set; get; }

        public string Summary { set; get; }

        public string ProjectOverView { set; get; }

        public string AccessibilityCenter { get; set; }

        public string AccessibilityPort { get; set; }

        public string AccessibilityAirport { get; set; }

        public string AccessibilityExpressway { get; set; }

        public string Juridical { get; set; }
        
        public string TermOfSdd { get; set; }

        public string PriceProject { get; set; }

        public string ElectricityCapacity { get; set; }

        public string WaterSupplyCapacity { get; set; }

        public string WastewaterTreatmentCapacity { get; set; }

        public string Utilities { get; set; }

        public string LoadingCapacoty { get; set; }

        public string CeilingHeight { get; set; }

        public ProjectLocation Project { get; set; }

        public Language Languages { get; set; }

    }
}
