using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NYCTaxiViewer.Models
{
    public class TaxiTrip
    {
        public int ID { get; set; }
        public int VendorId { get; set; }
        public string tpep_pickup_datetime { get; set; }
        public string tpep_dropoff_datetime { get; set; }
        public int passenger_count { get; set; }
        public float trip_distance { get; set; }
        public double pickup_longitude { get; set; }
        public double pickup_latitude { get; set; }
        public int RatecodeID { get; set; }
        public string store_and_fwd_flag { get; set; }
        public double dropoff_longitude { get; set; }
        public double dropoff_latitude { get; set; }
        public int payment_type { get; set; }
        public float fare_amount { get; set; }
        public float extra { get; set; }
        public float mta_tax { get; set; }
        public float tip_amount { get; set; }
        public float tolls_amount { get; set; }
        public float improvement_surcharge { get; set; }
        public float total_amount { get; set; }
    }
}
