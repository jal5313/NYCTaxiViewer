using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NYCTaxiViewer.Data;
using System.IO;

namespace NYCTaxiViewer.Models
{
    public static class DbInitializer
    {
        public static void Initialize(TaxiContext context)
        {

            var test = importTaxiTrips();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            
            if (context.TaxiTrips.Any())
            {
                return;
            }

            //add test data if the database is empty.

            var taxiTrips = importTaxiTrips();

           /* var taxiTrips = new TaxiTrip[]
             */
            foreach (TaxiTrip s in taxiTrips)
            {
                context.TaxiTrips.Add(s);
            }
            context.SaveChanges();
        }

        private static TaxiTrip[] importTaxiTrips()
        {
            var reader = new StreamReader(File.OpenRead(@"..\..\data\jan02Small.csv"));
            
            List<string> values = new List<string>();
            List<TaxiTrip> loadedTrips = new List<TaxiTrip>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();

                string[] split = line.Split(',');

                TaxiTrip addingTrip = new TaxiTrip();
                addingTrip.VendorId = int.Parse(split[0]);
                addingTrip.tpep_pickup_datetime = split[1];
                addingTrip.tpep_dropoff_datetime = split[2];
                addingTrip.passenger_count = int.Parse(split[3]);
                addingTrip.trip_distance = float.Parse(split[4]);
                addingTrip.pickup_longitude = double.Parse(split[5]);
                addingTrip.pickup_latitude = double.Parse(split[6]);
                addingTrip.RatecodeID = int.Parse(split[7]);
                addingTrip.store_and_fwd_flag = split[8];
                addingTrip.dropoff_longitude = double.Parse(split[9]);
                addingTrip.dropoff_latitude = double.Parse(split[10]);
                addingTrip.payment_type = int.Parse(split[11]);
                addingTrip.fare_amount = float.Parse(split[12]);
                addingTrip.extra = float.Parse(split[13]);
                addingTrip.mta_tax = float.Parse(split[14]);
                addingTrip.tip_amount = float.Parse(split[15]);
                addingTrip.tolls_amount = float.Parse(split[16]);
                addingTrip.improvement_surcharge = float.Parse(split[17]);
                addingTrip.total_amount = float.Parse(split[18]);

                loadedTrips.Add(addingTrip);
            }

            return loadedTrips.ToArray();
        }
    }
}
