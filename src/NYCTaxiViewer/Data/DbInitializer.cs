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
                new TaxiTrip{pickUpLat=12, pickUpLon=123, dropOffLat=1.2f, pdropOffLat=12},
                new TaxiTrip{pickUpLat=17, pickUpLon=124, dropOffLat=1.6f, pdropOffLat=17},
                new TaxiTrip{pickUpLat=124, pickUpLon=17, dropOffLat=12, pdropOffLat=1.2f}
            };
            foreach (TaxiTrip s in taxiTrips)
            {
                context.TaxiTrips.Add(s);
            }
            context.SaveChanges();
        }
    }
}
