using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoTema_WPF_Offline_App.Models
{
    public class GeoDataModel
    {
        public int ID { get; set; }
        public int PostalCode { get; set; }
        public string City { get; set; }
        public int Population { get; set; }
        public double Temperature { get; set; }
    }
}
