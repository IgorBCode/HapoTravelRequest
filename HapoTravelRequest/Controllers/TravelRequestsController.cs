using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HapoTravelRequest.Data;

namespace HapoTravelRequest.Controllers
{
    public class TravelRequestsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TravelRequestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TravelRequests
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TravelRequests.Include(t => t.User);
            //var closestRequests = await _context.TravelRequests
            //.Where(tr => tr.UserId == userId && tr.ConferenceStartDate >= DateTime.Today)
            //.OrderBy(tr => tr.ConferenceStartDate)
            //.Take(3)
            //.ToListAsync();
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TravelRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travelRequest = await _context.TravelRequests
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (travelRequest == null)
            {
                return NotFound();
            }

            return View(travelRequest);
        }

        // GET: TravelRequests/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: TravelRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PurposeOfTravel,NonEmployeeLegalName,NonEmployeeDOB,ConferenceDescription,ConferenceLink,AlternativeText,Location,CostOfConference,ConferenceStartDate,ConferenceEndDate,DepartureDate,ReturnDate,EmployeesAttending,EmployeesAttendingNames,ConferenceHotelName,PreferredLodgingInfo,SpecialTravelRequest,TransportationMode,AirlineDetails,FlightCost,GroundTransportation,MileageReimbursement,MileageRoundTrip,MIE,DailyMIEAmount,DaysForMIE,DepositAccount,AccountType,ApprovalStatus,ApprovedByVP,ApprovedByCEO,Booked,UserId")] TravelRequest travelRequest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(travelRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", travelRequest.UserId);
            return View(travelRequest);
        }

        // GET: TravelRequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travelRequest = await _context.TravelRequests.FindAsync(id);
            if (travelRequest == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", travelRequest.UserId);
            return View(travelRequest);
        }

        // POST: TravelRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PurposeOfTravel,NonEmployeeLegalName,NonEmployeeDOB,ConferenceDescription,ConferenceLink,AlternativeText,Location,CostOfConference,ConferenceStartDate,ConferenceEndDate,DepartureDate,ReturnDate,EmployeesAttending,EmployeesAttendingNames,ConferenceHotelName,PreferredLodgingInfo,SpecialTravelRequest,TransportationMode,AirlineDetails,FlightCost,GroundTransportation,MileageReimbursement,MileageRoundTrip,MIE,DailyMIEAmount,DaysForMIE,DepositAccount,AccountType,ApprovalStatus,ApprovedByVP,ApprovedByCEO,Booked,UserId")] TravelRequest travelRequest)
        {
            if (id != travelRequest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(travelRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TravelRequestExists(travelRequest.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", travelRequest.UserId);
            return View(travelRequest);
        }

        // GET: TravelRequests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travelRequest = await _context.TravelRequests
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (travelRequest == null)
            {
                return NotFound();
            }

            return View(travelRequest);
        }

        // POST: TravelRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var travelRequest = await _context.TravelRequests.FindAsync(id);
            if (travelRequest != null)
            {
                _context.TravelRequests.Remove(travelRequest);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TravelRequestExists(int id)
        {
            return _context.TravelRequests.Any(e => e.Id == id);
        }
    }
}
