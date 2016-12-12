using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NYCTaxiViewer.Data;

namespace NYCTaxiViewer.Models
{
    public static class DbInitializer
    {
        public static void Initialize(TaxiContext context)
        {
            context.Database.EnsureCreated();
            
            if (context.TaxiTrips.Any())
            {
                return;
            }

            //add test data if the database is empty.
            var taxiTrips = new TaxiTrip[]
            {
                new TaxiTrip
                {
                    VendorId = 2,
                    tpep_pickup_datetime = "1/1/2016 0:00:00",
                    tpep_dropoff_datetime = "1/1/2016 0:00:00",
                    passenger_count = 2,
                    trip_distance = 1.1f,
                    pickup_longitude = -73.9903717,
                    pickup_latitude = 40.73469543,
                    RatecodeID = 1,
                    store_and_fwd_flag = 'N',
                    dropoff_longitude = -73.98184204,
                    dropoff_latitude = 40.73240662,
                    payment_type = 2,
                    fare_amount = 7.5f,
                    extra = 0.5f,
                    mta_tax = 0.5f,
                    tip_amount = 0,
                    tolls_amount = 0,
                    improvement_surcharge = .03f,
                    total_amount = 8.8f
                }
            };
            foreach (TaxiTrip s in taxiTrips)
            {
                context.TaxiTrips.Add(s);
            }
            context.SaveChanges();
        }
    }
}
