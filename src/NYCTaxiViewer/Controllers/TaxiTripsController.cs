using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NYCTaxiViewer.Data;
using NYCTaxiViewer.Models;

namespace NYCTaxiViewer.Controllers
{
    public class TaxiTripsController : Controller
    {
        private readonly TaxiContext _context;

        public TaxiTripsController(TaxiContext context)
        {
            _context = context;
        }

        // GET: TaxiTrips
        public async Task<IActionResult> Index()
        {
            return View(await _context.TaxiTrips.ToListAsync());
        }

        public async Task<IActionResult> GetAllJson()
        {
            return Json(await _context.TaxiTrips.ToListAsync());
        }

        public async Task<IActionResult> GetTripsSorted()
        {
            var trips = from trip in _context.TaxiTrips
                        select trip;

            trips = trips.OrderBy(trip => trip.passenger_count);
            return Json(trips.ToList());
        }

        public async Task<IActionResult> GetTripsFiltered(String cutoffEndInput)
        {
            DateTime cutoffEnd = DateTime.Parse(cutoffEndInput);
            DateTime cutoffStart = cutoffEnd.AddHours(-1);

            var trips = from trip in _context.TaxiTrips
                        where Convert.ToDateTime(trip.tpep_dropoff_datetime) <= cutoffEnd
                        where Convert.ToDateTime(trip.tpep_dropoff_datetime) >= cutoffStart
                        select trip;
            
            return Json(trips.ToList());
        }

        public async Task<IActionResult> Visualization()
        {
            return View(await _context.TaxiTrips.ToListAsync());
        }

        // GET: TaxiTrips/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxiTrip = await _context.TaxiTrips.SingleOrDefaultAsync(m => m.ID == id);
            if (taxiTrip == null)
            {
                return NotFound();
            }

            return View(taxiTrip);
        }

        // GET: TaxiTrips/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TaxiTrips/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,dropOffLat,pdropOffLat,pickUpLat,pickUpLon")] TaxiTrip taxiTrip)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taxiTrip);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(taxiTrip);
        }

        // GET: TaxiTrips/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxiTrip = await _context.TaxiTrips.SingleOrDefaultAsync(m => m.ID == id);
            if (taxiTrip == null)
            {
                return NotFound();
            }
            return View(taxiTrip);
        }

        // POST: TaxiTrips/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,dropOffLat,pdropOffLat,pickUpLat,pickUpLon")] TaxiTrip taxiTrip)
        {
            if (id != taxiTrip.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taxiTrip);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaxiTripExists(taxiTrip.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(taxiTrip);
        }

        // GET: TaxiTrips/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxiTrip = await _context.TaxiTrips.SingleOrDefaultAsync(m => m.ID == id);
            if (taxiTrip == null)
            {
                return NotFound();
            }

            return View(taxiTrip);
        }

        // POST: TaxiTrips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taxiTrip = await _context.TaxiTrips.SingleOrDefaultAsync(m => m.ID == id);
            _context.TaxiTrips.Remove(taxiTrip);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TaxiTripExists(int id)
        {
            return _context.TaxiTrips.Any(e => e.ID == id);
        }
    }
}
