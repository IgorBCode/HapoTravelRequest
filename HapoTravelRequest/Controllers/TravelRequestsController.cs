using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HapoTravelRequest.Data;
using HapoTravelRequest.Models.TravelRequest;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace HapoTravelRequest.Controllers
{
    [Authorize]
    public class TravelRequestsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public TravelRequestsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
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
        public async Task<IActionResult> Create()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user is null)
            {
                return NotFound();
            }

            var model = new TravelRequestCreateVM
            {
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DateOfBirth = user.DateOfBirth,
                PhoneNumber = user.PhoneNumber,
                Department = user.Department,
                PositionTitle = user.PositionTitle,
                DepartmentDirector = user.DepartmentDirector
            };

            return View(model);
        }

        // POST: TravelRequests/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TravelRequestCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            var user = await _userManager.GetUserAsync (User);
            if (user is null)
            {
                return NotFound();
            }

            // update user info if changed
            bool userUpdated = false;

            if (user.FirstName != model.FirstName && !string.IsNullOrWhiteSpace(model.FirstName))
            {
                user.FirstName = model.FirstName;
                userUpdated = true;
            }

            if (user.LastName != model.LastName && !string.IsNullOrWhiteSpace(model.LastName))
            {
                user.LastName = model.LastName;
                userUpdated = true;
            }

            if (user.DateOfBirth != model.DateOfBirth)
            {
                user.DateOfBirth = model.DateOfBirth;
                userUpdated = true;
            }

            if (user.PhoneNumber != model.PhoneNumber)
            {
                user.PhoneNumber = model.PhoneNumber;
                userUpdated = true;
            }

            if (user.Department != model.Department)
            {
                user.Department = model.Department;
                userUpdated = true;
            }

            if (user.PositionTitle != model.PositionTitle)
            {
                user.PositionTitle = model.PositionTitle;
                userUpdated = true;
            }

            if (user.DepartmentDirector != model.DepartmentDirector)
            {
                user.DepartmentDirector = model.DepartmentDirector;
                userUpdated = true;
            }

            if (userUpdated)
            {
                await _userManager.UpdateAsync(user);
            }

            var travelRequest = new TravelRequest
            {
                UserId = user.Id,
                PurposeOfTravel = model.PurposeOfTravel,
                NonEmployeeGuests = model.NonEmployeeGuests,
                NonEmployeeLegalName = model.NonEmployeeLegalName,
                NonEmployeeDOB = model.NonEmployeeDOB,
                ConferenceDescription = model.ConferenceDescription,
                ConferenceLink = model.ConferenceLink,
                AlternativeText = model.AlternativeText,
                Location = model.Location,
                CostOfConference = model.CostOfConference,
                ConferenceStartDate = model.ConferenceStartDate,
                ConferenceEndDate = model.ConferenceEndDate,
                DepartureDate = model.DepartureDate,
                ReturnDate = model.ReturnDate,
                EmployeesAttending = model.EmployeesAttending,
                EmployeesAttendingNames = model.EmployeesAttendingNames,
                ConferenceHotelName = model.ConferenceHotelName,
                PreferredLodgingInfo = model.PreferredLodgingInfo,
                SpecialTravelRequest = model.SpecialTravelRequest,
                TransportationMode = model.TransportationMode,
                AirlineDetails = model.AirlineDetails,
                FlightCost = model.FlightCost,
                GroundTransportation = model.GroundTransportation,
                MileageReimbursement = model.MileageReimbursement,
                MileageRoundTrip = model.MileageRoundTrip,
                MIE = model.MIE,
                DailyMIEAmount = model.DailyMIEAmount,
                DaysForMIE = model.DaysForMIE,
                DepositAccount = model.DepositAccount,
                AccountType = model.AccountType,
                CorporateCard = model.CorporateCard,
                ValueExplination = model.ValueExplination,
                EmergencyContactname = model.EmergencyContactname,
                EmergencyContactPhoneNumber = model.EmergencyContactPhoneNumber,
                TSANumber = model.TSANumber,
                GroundOptions = model.GroundOptions,
                RegisteredForConference = model.RegisteredForConference,
                Registered = model.Registered,
                ApprovalStatus = Models.ApprovalStatus.Pending
            };
            
            _context.TravelRequests.Add(travelRequest);
            await _context.SaveChangesAsync();

            //if (!string.IsNullOrWhiteSpace(model.CommentContent))
            //{
            //    var comment = new Comment
            //    {
            //        Content = model.CommentContent,
            //        CreatedTime = DateTime.UtcNow,
            //        UserId = user.Id,
            //        TravelRequestId = travelRequest.Id
            //    };
            //    _context.Comments.Add(comment);
            //    await _context.SaveChangesAsync();
            //}

            return RedirectToAction("Index", "Home");

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
