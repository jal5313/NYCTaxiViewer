using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NYCTaxiViewer.Models
{
    public class TaxiTrip
    {
        public int ID { get; set; }
        public float pickUpLat { get; set; }
        public float pickUpLon { get; set; }
        public float dropOffLat { get; set; }
        public float pdropOffLat { get; set; }
    }
}
