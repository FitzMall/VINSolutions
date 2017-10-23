using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VINSolutionsAPI.Models
{
    public class NhtsaResponse
    {
        public bool status { get; set; }
        public int number_of_recalls { get; set; }
        public string make { get; set; }
        public string vin { get; set; }
        public DateTime refresh_date { get; set; }
        public List<recall> recalls { get; set; }
        public int manufacturer_id { get; set; }
        public bool recalls_available { get; set; }
        public string model { get; set; }
    }

    public class recall
    {
        public string mfr_recall_number { get; set; }
        public string mfr_recall_status { get; set; }
        public string mfr_notes { get; set; }
        public string safety_risk_description { get; set; }
        public string  recall_description { get; set; }
        public string remedy_description { get; set; }
        public DateTime refresh_date { get; set; }
        public string nhtsa_recall_number { get; set; }
        public DateTime recall_date { get; set; }
          
    }

}