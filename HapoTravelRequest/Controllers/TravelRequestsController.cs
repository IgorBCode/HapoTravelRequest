using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HapoTravelRequest.Data;
using HapoTravelRequest.Models.TravelRequest;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using HapoTravelRequest.Services;
using System.Runtime.ConstrainedExecution;

namespace HapoTravelRequest.Controllers
{
    [Authorize]
    public class TravelRequestsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSender _emailSender;

        public TravelRequestsController(
            ApplicationDbContext context, 
            UserManager<ApplicationUser> userManager,
            IEmailSender emailSender
            )
        {
            _context = context;
            _userManager = userManager;
            _emailSender = emailSender;
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

        public async Task<IActionResult> Approval(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travelRequest = await _context.TravelRequests
                .Include(tr => tr.User)
                .FirstOrDefaultAsync(tr => tr.Id == id);

            if (travelRequest == null || travelRequest.User == null)
            {
                return NotFound();
            }

            var user = travelRequest.User;

            var model = new TravelRequestReadOnlyVM
            {
                // User info ***********************************
                Id = travelRequest.Id,
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Department = user.Department,
                PhoneNumber = user.PhoneNumber,
                PositionTitle = user.PositionTitle,
                DepartmentDirector = user.DepartmentDirector,

                // Travel request info *************************
                PurposeOfTravel = travelRequest.PurposeOfTravel,
                NonEmployeeGuests = travelRequest.NonEmployeeGuests,
                NonEmployeeLegalName = travelRequest.NonEmployeeLegalName,
                NonEmployeeDOB = travelRequest.NonEmployeeDOB,
                ConferenceDescription = travelRequest.ConferenceDescription,
                ConferenceLink = travelRequest.ConferenceLink,
                AlternativeText = travelRequest.AlternativeText,
                Location = travelRequest.Location,
                CostOfConference = travelRequest.CostOfConference,
                ConferenceStartDate = travelRequest.ConferenceStartDate,
                ConferenceEndDate = travelRequest.ConferenceEndDate,
                RegistrationDeadline = travelRequest.RegistrationDeadline,
                DepartureDate = travelRequest.DepartureDate ?? DateTime.MinValue,
                ReturnDate = travelRequest.ReturnDate ?? DateTime.MinValue,
                EmployeesAttending = travelRequest.EmployeesAttending,
                EmployeesAttendingNames = travelRequest.EmployeesAttendingNames,
                ConferenceHotelName = travelRequest.ConferenceHotelName,
                PreferredLodgingInfo = travelRequest.PreferredLodgingInfo,
                SpecialTravelRequest = travelRequest.SpecialTravelRequest,
                TransportationMode = travelRequest.TransportationMode,
                AirlineDetails = travelRequest.AirlineDetails,
                FlightCost = travelRequest.FlightCost,
                GroundTransportation = travelRequest.GroundTransportation,
                MileageReimbursement = travelRequest.MileageReimbursement,
                MileageRoundTrip = travelRequest.MileageRoundTrip,
                MIE = travelRequest.MIE,
                DailyMIEAmount = travelRequest.DailyMIEAmount,
                DaysForMIE = travelRequest.DaysForMIE,
                DepositAccount = travelRequest.DepositAccount,
                AccountType = travelRequest.AccountType,
                CorporateCard = travelRequest.CorporateCard,
                ValueExplination = travelRequest.ValueExplination,
                EmergencyContactname = travelRequest.EmergencyContactname,
                EmergencyContactPhoneNumber = travelRequest.EmergencyContactPhoneNumber,
                TSANumber = travelRequest.TSANumber,
                GroundOptions = travelRequest.GroundOptions,
                RegisteredForConference = travelRequest.RegisteredForConference,
                Registered = travelRequest.Registered
            };


            return View(model);
        }

        public async Task<IActionResult> Overview(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travelRequest = await _context.TravelRequests
                .Include(tr => tr.User)
                .FirstOrDefaultAsync(tr => tr.Id == id);

            if (travelRequest == null || travelRequest.User == null)
            {
                return NotFound();
            }

            var user = travelRequest.User;

            var model = new TravelRequestReadOnlyVM
            {
                // User info ***********************************
                Id = travelRequest.Id,
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Department = user.Department,
                PhoneNumber = user.PhoneNumber,
                PositionTitle = user.PositionTitle,
                DepartmentDirector = user.DepartmentDirector,

                // Travel request info *************************
                PurposeOfTravel = travelRequest.PurposeOfTravel,
                NonEmployeeGuests = travelRequest.NonEmployeeGuests,
                NonEmployeeLegalName = travelRequest.NonEmployeeLegalName,
                NonEmployeeDOB = travelRequest.NonEmployeeDOB,
                ConferenceDescription = travelRequest.ConferenceDescription,
                ConferenceLink = travelRequest.ConferenceLink,
                AlternativeText = travelRequest.AlternativeText,
                Location = travelRequest.Location,
                CostOfConference = travelRequest.CostOfConference,
                ConferenceStartDate = travelRequest.ConferenceStartDate,
                ConferenceEndDate = travelRequest.ConferenceEndDate,
                RegistrationDeadline = travelRequest.RegistrationDeadline,
                DepartureDate = travelRequest.DepartureDate ?? DateTime.MinValue,
                ReturnDate = travelRequest.ReturnDate ?? DateTime.MinValue,
                EmployeesAttending = travelRequest.EmployeesAttending,
                EmployeesAttendingNames = travelRequest.EmployeesAttendingNames,
                ConferenceHotelName = travelRequest.ConferenceHotelName,
                PreferredLodgingInfo = travelRequest.PreferredLodgingInfo,
                SpecialTravelRequest = travelRequest.SpecialTravelRequest,
                TransportationMode = travelRequest.TransportationMode,
                AirlineDetails = travelRequest.AirlineDetails,
                FlightCost = travelRequest.FlightCost,
                GroundTransportation = travelRequest.GroundTransportation,
                MileageReimbursement = travelRequest.MileageReimbursement,
                MileageRoundTrip = travelRequest.MileageRoundTrip,
                MIE = travelRequest.MIE,
                DailyMIEAmount = travelRequest.DailyMIEAmount,
                DaysForMIE = travelRequest.DaysForMIE,
                DepositAccount = travelRequest.DepositAccount,
                AccountType = travelRequest.AccountType,
                CorporateCard = travelRequest.CorporateCard,
                ValueExplination = travelRequest.ValueExplination,
                EmergencyContactname = travelRequest.EmergencyContactname,
                EmergencyContactPhoneNumber = travelRequest.EmergencyContactPhoneNumber,
                TSANumber = travelRequest.TSANumber,
                GroundOptions = travelRequest.GroundOptions,
                RegisteredForConference = travelRequest.RegisteredForConference,
                Registered = travelRequest.Registered
            };


            return View(model);
        }

        public async Task<IActionResult> MyRequests()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound();
            }

            // get all travel requests
            var travelRequests = await _context.TravelRequests
                .Where(q => q.UserId == user.Id)
                .Include(q => q.User)
                .OrderByDescending(q => q.ConferenceStartDate)
                .Select(q => new TravelRequestListVM
                {
                    Id = q.Id,
                    FirstName = q.User.FirstName,
                    LastName = q.User.LastName,
                    Location = q.Location,
                    ConferenceStartDate = q.ConferenceStartDate,
                    ConferenceEndDate = q.ConferenceEndDate,
                    TransportationMode = q.TransportationMode,
                    CostOfConference = q.CostOfConference,
                    ApprovalStatus = q.ApprovalStatus
                })
                .ToListAsync();

            return View(travelRequests);
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

            string emailSubject = $"New travel request from {user.FirstName} {user.LastName}";
            string msg = $"<p>{user.FirstName} {user.LastName} has submitted a new travel request.</p><hr>" +
                $@"<p><strong>Dates:</strong> {model.ConferenceStartDate} - {model.ConferenceEndDate}" +
                $@"<p><strong>Location:</strong> {model.Location}" +
                $@"<p><strong>Conference Fee:</strong> ${model.CostOfConference}" +
                "<br><br><p>Log into the travel request system to approve/deny the request.</p>";
            await _emailSender.SendEmailAsync(user.DepartmentDirector, emailSubject, msg);

            return RedirectToAction("Index", "Home");

        }

        [HttpPost]
        public async Task<IActionResult> ApproveOrDeny(int id, string decision)
        {
            string emailSubject = "";
            string msg = "";

            var request = await _context.TravelRequests.FindAsync(id);

            if (request == null)
            {
                return NotFound();
            }

            string userEmailAddress = request.User.Email;

            // if vp approved the request
            if (decision == "approve" && User.IsInRole("VP"))
            {
                request.ApprovalStatus = Models.ApprovalStatus.ApprovedByVP;

                // send email to CEO
                var ceos = await _userManager.GetUsersInRoleAsync("CEO"); // get first user with ceo role in database
                var ceo = ceos.FirstOrDefault();
                string CEOemailAddress = ceo?.Email ?? "CEO@localhost.com"; // if no ceo found a place holder email is used.
                emailSubject = $"Travel request for {request.User.FirstName} {request.User.LastName} waiting for approval";

                msg = $"<p>{request.User.FirstName} {request.User.LastName} has submitted a new travel request.</p><hr>" +
                $@"<p><strong>Dates:</strong> {request.ConferenceStartDate} - {request.ConferenceEndDate}" +
                $@"<p><strong>Location:</strong> {request.Location}" +
                $@"<p><strong>Conference Fee:</strong> ${request.CostOfConference}" +
                "<br><br><p>Log into the travel request system to approve/deny the request.</p>";

                try
                {
                    await _emailSender.SendEmailAsync(CEOemailAddress, emailSubject, msg);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error sending email: {ex.ToString()}");
                }

                // set up email for user
                emailSubject = "Travel request approved by VP";

                msg = $"<p>Your request for:</p><hr>" +
                $@"<p><strong>Dates:</strong> {request.ConferenceStartDate} - {request.ConferenceEndDate}" +
                $@"<p><strong>Location:</strong> {request.Location}" +
                "has been approved by your manager. Currently awaiting CEO Approval.";
            }
            // if ceo approved request
            else if (decision == "approve" && User.IsInRole("CEO"))
            {
                request.ApprovalStatus = Models.ApprovalStatus.ApprovedByCEO;

                // send email to processor
                var processors = await _userManager.GetUsersInRoleAsync("Processor");
                var processor = processors.FirstOrDefault(); // get first user with processor role in database
                string processorEmail = processor.Email;
                emailSubject = $"Booking required for {request.User.FirstName} {request.User.LastName}'s travel request";

                msg = $"<p>{request.User.FirstName} {request.User.LastName}'s travel request has been approved and is waiting for booking'.</p><hr>" +
                $@"<p><strong>Dates:</strong> {request.ConferenceStartDate} - {request.ConferenceEndDate}" +
                $@"<p><strong>Location:</strong> {request.Location}" +
                $@"<p><strong>Conference Fee:</strong> ${request.CostOfConference}" +
                "<br><br><p>Log into the travel request system to book the request.</p>";

                try
                {
                    await _emailSender.SendEmailAsync(processorEmail, emailSubject, msg);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error sending email: {ex.ToString()}");
                }

                // set up email for user
                emailSubject = "Travel request approved by CEO";

                msg = $"<p>Your request for:</p><hr>" +
                $@"<p><strong>Dates:</strong> {request.ConferenceStartDate} - {request.ConferenceEndDate}" +
                $@"<p><strong>Location:</strong> {request.Location}" +
                "has been approved by the CEO. Currently awaiting booking.";
            }
            else if (decision == "deny")
            {
                request.ApprovalStatus = Models.ApprovalStatus.Denied;

                // set up email for user
                emailSubject = "Travel request denied";

                msg = $"<p>Your request for:</p><hr>" +
                $@"<p><strong>Dates:</strong> {request.ConferenceStartDate} - {request.ConferenceEndDate}" +
                $@"<p><strong>Location:</strong> {request.Location}" +
                "has been denied.";
            }

            // send approval status email to user

            try
            {
                await _emailSender.SendEmailAsync(userEmailAddress, emailSubject, msg);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.ToString()}");
            }

            await _context.SaveChangesAsync();

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
        [Authorize(Roles = "Admin,User,VP,CEO,Processor")]
        public async Task<IActionResult> ViewTravelRequests()
        {
            var requests = await _context.TravelRequests
                .Include(r => r.User)
                .Select(r => new TravelRequestListVM
                {
                    Id = r.Id,
                    FirstName = r.User.FirstName,
                    LastName = r.User.LastName,
                    ConferenceDescription = r.ConferenceDescription,
                    Location = r.Location,
                    ConferenceStartDate = r.ConferenceStartDate,
                    ConferenceEndDate = r.ConferenceEndDate,
                    TransportationMode = r.TransportationMode,
                    CostOfConference = r.CostOfConference,
                    ApprovalStatus = r.ApprovalStatus
                })
                .ToListAsync();

            return View(requests);
        }
    }
}
