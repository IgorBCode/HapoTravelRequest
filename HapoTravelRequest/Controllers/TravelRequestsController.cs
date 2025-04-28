using Microsoft.AspNetCore.Mvc.Rendering;
using HapoTravelRequest.Models.TravelRequest;
using HapoTravelRequest.Models;
using HapoTravelRequest.Services;
using HapoTravelRequest.Models.Comment;

namespace HapoTravelRequest.Controllers
{
    [Authorize]
    public class TravelRequestsController(
        ApplicationDbContext context, 
        UserManager<ApplicationUser> userManager, 
        IEmailSender emailSender,
        TravelRequestService travelRequestService) : Controller
    {
        private readonly ApplicationDbContext _context = context;
        private readonly UserManager<ApplicationUser> _userManager = userManager;
        private readonly IEmailSender _emailSender = emailSender;
        private readonly TravelRequestService _travelRequestService = travelRequestService;

        // GET: TravelRequests
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TravelRequests.Include(t => t.User);
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

        public async Task<IActionResult> Details(int? id)
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

        public async Task<IActionResult> ViewTravelRequests()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user is null)
            {
                return NotFound();
            }

            var roles = await _userManager.GetRolesAsync(user);

            var travelRequests = new List<TravelRequestListVM>();

            if (roles.Contains("Administrator"))
            {
                // Admin sees all requests
                travelRequests = await _travelRequestService.GetTravelRequestsListAsync(query => query);
            }
            else
            {
                // Regular user sees their own requests first
                var userRequests = await _travelRequestService.GetTravelRequestsListAsync(
                    query => query.Where(q => q.UserId == user.Id));
                travelRequests.AddRange(userRequests);

                // If user is VP, add pending requests for their department
                if (roles.Contains("VP"))
                {
                    var vpRequests = await _travelRequestService.GetTravelRequestsListAsync(
                        query => query.Where(q => q.ApprovalStatus == ApprovalStatus.Pending &&
                                                  q.User.DepartmentDirector != null &&
                                                  q.User.DepartmentDirector.ToLower() == user.Email.ToLower()));
                    travelRequests.AddRange(vpRequests);
                }

                // If user is CEO, add requests approved by VP
                if (roles.Contains("CEO"))
                {
                    var ceoRequests = await _travelRequestService.GetTravelRequestsListAsync(
                        query => query.Where(q => q.ApprovalStatus == ApprovalStatus.ApprovedByVP));
                    travelRequests.AddRange(ceoRequests);
                }

                // If user is Processor, add requests approved by CEO
                if (roles.Contains("Processor"))
                {
                    var processorRequests = await _travelRequestService.GetTravelRequestsListAsync(
                        query => query.Where(q => q.ApprovalStatus == ApprovalStatus.ApprovedByCEO));
                    travelRequests.AddRange(processorRequests);
                }
            }

            // Remove duplicates from overlapping queries
            travelRequests = travelRequests.DistinctBy(q => q.Id).ToList();

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

            var user = await _userManager.GetUserAsync(User);
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

            // set correct approval status depending on who is submitting the request
            ApprovalStatus status = Models.ApprovalStatus.Pending;
            if (User.IsInRole("VP"))
            {
                status = Models.ApprovalStatus.ApprovedByVP;
            }
            if (User.IsInRole("CEO"))
            {
                status = Models.ApprovalStatus.ApprovedByCEO;
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
                ApprovalStatus = status
            };

            _context.TravelRequests.Add(travelRequest);
            await _context.SaveChangesAsync();

            // if vp created request it goes straight to ceo
            if (User.IsInRole("VP"))
            {
                // send email to CEO
                var CEOemailAddress = (await _userManager.GetUsersInRoleAsync("CEO")).FirstOrDefault()?.Email;
                string subject = $"Travel request for {travelRequest.User.FirstName} {travelRequest.User.LastName} waiting for approval";

                string message = $"<p>{travelRequest.User.FirstName} {travelRequest.User.LastName} has submitted a new travel request.</p><hr>" +
                $@"<p><strong>Dates:</strong> {travelRequest.ConferenceStartDate} - {travelRequest.ConferenceEndDate}" +
                $@"<p><strong>Location:</strong> {travelRequest.Location}" +
                $@"<p><strong>Conference Fee:</strong> ${travelRequest.CostOfConference}" +
                "<br><br><p>Log into the travel request system to approve/deny the request.</p>";

                try
                {
                    await _emailSender.SendEmailAsync(CEOemailAddress, subject, message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error sending email: {ex.ToString()}");
                }
            }
            // if CEO submitted request it is sent straight to booking
            else if (User.IsInRole("CEO"))
            {
                // send email to processor
                var processors = await _userManager.GetUsersInRoleAsync("Processor");
                var processor = processors.FirstOrDefault(); // get first user with processor role in database
                string? processorEmail = processor.Email;
                string subject = $"Booking required for {travelRequest.User.FirstName} {travelRequest.User.LastName}'s travel request";

                string message = $"<p>{travelRequest.User.FirstName} {travelRequest.User.LastName}'s travel request has been approved and is waiting for booking'.</p><hr>" +
                $@"<p><strong>Dates:</strong> {travelRequest.ConferenceStartDate} - {travelRequest.ConferenceEndDate}" +
                $@"<p><strong>Location:</strong> {travelRequest.Location}" +
                $@"<p><strong>Conference Fee:</strong> ${travelRequest.CostOfConference}" +
                "<br><br><p>Log into the travel request system to book the request.</p>";

                try
                {
                    await _emailSender.SendEmailAsync(processorEmail, subject, message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error sending email: {ex.ToString()}");
                }
            }
            else
            {
                string emailSubject = $"New travel request from {user.FirstName} {user.LastName}";
                string msg = $"<p>{user.FirstName} {user.LastName} has submitted a new travel request.</p><hr>" +
                $@"<p><strong>Dates:</strong> {model.ConferenceStartDate} - {model.ConferenceEndDate}" +
                $@"<p><strong>Location:</strong> {model.Location}" +
                $@"<p><strong>Conference Fee:</strong> ${model.CostOfConference}" +
                "<br><br><p>Log into the travel request system to approve/deny the request.</p>";

                try
                {
                    await _emailSender.SendEmailAsync(user.DepartmentDirector, emailSubject, msg);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error sending email: {ex.ToString()}");
                }
            }

            return RedirectToAction("Index", "Home");

        }

        [HttpPost]
        [Authorize(Roles = "Administrator,VP,CEO")]
        public async Task<IActionResult> ApproveOrDeny(int id, string decision, string redirectAction, string redirectController)
        {
            string emailSubject = "";
            string msg = "";

            var request = await _context.TravelRequests
                .Include(tr => tr.User)
                .FirstOrDefaultAsync(tr => tr.Id == id);

            if (request == null || request.User == null)
            {
                return NotFound();
            }

            string? userEmailAddress = request.User.Email;

            // if vp or admin approved the request 
            if (decision == "approve" && (User.IsInRole("VP") || User.IsInRole("Administrator")) && request.ApprovalStatus == ApprovalStatus.Pending)
            {
                request.ApprovalStatus = Models.ApprovalStatus.ApprovedByVP;
                _context.Update(request);
                await _context.SaveChangesAsync();

                // send email to CEO
                var CEOemailAddress = (await _userManager.GetUsersInRoleAsync("CEO")).FirstOrDefault()?.Email;
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
                $@"<p><strong>Location:</strong> {request.Location}</p>" +
                "<p>has been approved by your manager. Currently awaiting CEO Approval.</p>";
            }
            // if ceo or admin approved request
            else if (decision == "approve" && (User.IsInRole("CEO") || User.IsInRole("Administrator")) && request.ApprovalStatus == ApprovalStatus.ApprovedByVP)
            {
                request.ApprovalStatus = Models.ApprovalStatus.ApprovedByCEO;
                _context.Update(request);
                await _context.SaveChangesAsync();

                // send email to processor
                var processors = await _userManager.GetUsersInRoleAsync("Processor");
                var processor = processors.FirstOrDefault(); // get first user with processor role in database
                string? processorEmail = processor.Email;
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
                $@"<p><strong>Location:</strong> {request.Location}</p>" +
                "<p>has been approved by the CEO. Currently awaiting booking.</p>";
            }
            else if (decision == "deny")
            {
                request.ApprovalStatus = Models.ApprovalStatus.Denied;
                _context.Update(request);
                await _context.SaveChangesAsync();

                // set up email for user
                emailSubject = "Travel request denied";

                msg = $"<p>Your request for:</p><hr>" +
                $@"<p><strong>Dates:</strong> {request.ConferenceStartDate} - {request.ConferenceEndDate}" +
                $@"<p><strong>Location:</strong> {request.Location} </p>" +
                "<p>has been denied.</p>";
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

            return RedirectToAction(redirectAction, redirectController);
        }

        [HttpGet]
        [Authorize(Roles = "Processor,Administrator")]
        public async Task<IActionResult> Book(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.TravelRequests
                .Include(tr => tr.User)
                .FirstOrDefaultAsync(tr => tr.Id == id);

            if (request == null || request.User == null)
            {
                return NotFound();
            }

            // Map TravelRequest data to the ViewModel
            var viewModel = new TravelRequestBookVM
            {
                Id = request.Id,
                UserId = request.User.Id,
                FirstName = request.User.FirstName,
                LastName = request.User.LastName,
                DateOfBirth = request.User.DateOfBirth,
                PhoneNumber = request.User.PhoneNumber,
                Department = request.User.Department,
                PositionTitle = request.User.PositionTitle,
                DepartmentDirector = request.User.DepartmentDirector,

                PurposeOfTravel = request.PurposeOfTravel,
                NonEmployeeGuests = request.NonEmployeeGuests,
                NonEmployeeLegalName = request.NonEmployeeLegalName,
                NonEmployeeDOB = request.NonEmployeeDOB,
                ConferenceDescription = request.ConferenceDescription,
                ConferenceLink = request.ConferenceLink,
                AlternativeText = request.AlternativeText,
                Location = request.Location,
                CostOfConference = request.CostOfConference,
                ConferenceStartDate = request.ConferenceStartDate,
                ConferenceEndDate = request.ConferenceEndDate,
                RegistrationDeadline = request.RegistrationDeadline,
                DepartureDate = request.DepartureDate,
                ReturnDate = request.ReturnDate,
                EmployeesAttending = request.EmployeesAttending,
                EmployeesAttendingNames = request.EmployeesAttendingNames,
                ConferenceHotelName = request.ConferenceHotelName,
                PreferredLodgingInfo = request.PreferredLodgingInfo,
                SpecialTravelRequest = request.SpecialTravelRequest,
                TransportationMode = request.TransportationMode,
                AirlineDetails = request.AirlineDetails,
                FlightCost = request.FlightCost,
                GroundTransportation = request.GroundTransportation,
                MileageReimbursement = request.MileageReimbursement,
                MileageRoundTrip = request.MileageRoundTrip,
                MIE = request.MIE,
                DailyMIEAmount = request.DailyMIEAmount,
                DaysForMIE = request.DaysForMIE,
                DepositAccount = request.DepositAccount,
                AccountType = request.AccountType,
                CorporateCard = request.CorporateCard,
                ValueExplination = request.ValueExplination,
                EmergencyContactname = request.EmergencyContactname,
                EmergencyContactPhoneNumber = request.EmergencyContactPhoneNumber,
                TSANumber = request.TSANumber,
                GroundOptions = request.GroundOptions,
                RegisteredForConference = request.RegisteredForConference,
                Registered = request.Registered
            };

            // Render the view with the populated ViewModel
            return View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator,Processor")]
        public async Task<IActionResult> Book(int? id, TravelRequestBookVM model, string redirectAction, string redirectController)
        {
            var request = await _context.TravelRequests
            .Include(q => q.User)
            .FirstOrDefaultAsync(q => q.Id == id);
            if (request == null)
            {
                return NotFound();
            }

            request.CostOfConference = model.CostOfConference;
            request.ConferenceStartDate = model.ConferenceStartDate;
            request.ConferenceEndDate = model.ConferenceEndDate;
            request.DepartureDate = model.DepartureDate;
            request.ReturnDate = model.ReturnDate;
            request.ConferenceHotelName = model.ConferenceHotelName;
            request.TransportationMode = model.TransportationMode;
            request.AirlineDetails = model.AirlineDetails;
            request.FlightCost = model.FlightCost;
            request.GroundTransportation = model.GroundTransportation;
            request.MileageReimbursement = model.MileageReimbursement;
            request.MileageRoundTrip = model.MileageRoundTrip;
            request.MIE = model.MIE;
            request.DailyMIEAmount = model.DailyMIEAmount;
            request.DaysForMIE = model.DaysForMIE;
            request.DepositAccount = model.DepositAccount;
            request.AccountType = model.AccountType;
            request.CorporateCard = model.CorporateCard;
            request.GroundOptions = model.GroundOptions;
            request.RegisteredForConference = model.RegisteredForConference;
            request.Registered = model.Registered;
            request.ApprovalStatus = ApprovalStatus.Booked;

            await _context.SaveChangesAsync();

            // send email to user
            string emailSubject = $"Trip to {request.Location} booked.";
            string emailAddress = request.User.Email;
            string msg = $"<p>Your trip has been to {request.Location} has been booked</p>";

            if (!string.IsNullOrWhiteSpace(model.TransportationMode))
            {
                msg += "<p><strong>Transportation:</strong></p>";
            }
            if (!string.IsNullOrWhiteSpace(model.AirlineDetails))
            {
                msg += $"<p><strong>Airline Details:</strong> {model.AirlineDetails}</p>";
            }
            if (!string.IsNullOrWhiteSpace(model.GroundTransportation))
            {
                msg += $"<p><strong>Ground Transportation:</strong> {model.GroundTransportation}</p>";
            }
            if (model.MIE == true)
            {
                msg += "<p><strong>Meals & Incidentals:</strong> Yes</p>" +
                    $"<p><strong>Daily M&IE amount:</strong> {model.DailyMIEAmount}</p>" +
                    $"<p><strong>Days for M&IE:</strong> {model.DaysForMIE}</p>";

            }

            msg += $"<hr><p>Log into the travel request system to see full details</p>";

            try
            {
                await _emailSender.SendEmailAsync(emailAddress, emailSubject, msg);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.ToString()}");
            }

            return RedirectToAction(redirectAction, redirectController);
        }

        [HttpPost]
        public async Task<IActionResult> Cancel(int? id, string? redirectAction, string? redirectController)
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

            travelRequest.ApprovalStatus = Models.ApprovalStatus.Cancelled;

            await _context.SaveChangesAsync();

            return RedirectToAction(redirectAction, redirectController);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddComment(TravelRequestReadOnlyVM model)
        {
            if (!string.IsNullOrWhiteSpace(model.NewComment))
            {
                var user = await _userManager.GetUserAsync(User);

                var comment = new Comment
                {
                    Content = model.NewComment,
                    CreatedTime = DateTime.UtcNow,
                    UserId = user.Id,
                    TravelRequestId = model.Id
                };

                _context.Comments.Add(comment);
                await _context.SaveChangesAsync();
                Console.WriteLine("Success");
            }

            return RedirectToAction("Approval", new { id = model.Id });
        }

        [HttpGet]
        public async Task<IActionResult> GetComments(int id)
        {
            var comments = await _context.Comments
                .Where(c => c.TravelRequestId == id)
                .OrderBy(c => c.CreatedTime)
                .Select(c => new CommentVM
                {
                    Content = c.Content,
                    CreateTime = c.CreatedTime,
                    AuthorName = c.User.FirstName + " " + c.User.LastName
                })
                .ToListAsync();
            return PartialView("_CommentsPartial", comments);
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

        //[Authorize(Roles = "Administrator,VP,CEO,Processor")]
        //public async Task<IActionResult> ViewTravelRequests()
        //{
        //    var user = await _userManager.GetUserAsync(User);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }
        //    bool isVP = await _userManager.IsInRoleAsync(user, "VP");
        //    bool isCEO = await _userManager.IsInRoleAsync(user, "CEO");
        //    bool isProcessor = await _userManager.IsInRoleAsync(user, "Processor");
        //    bool isAdmin = await _userManager.IsInRoleAsync(user, "Administrator");

        //    // Lists for all other travel requests
        //    List<TravelRequestListVM> trList = new List<TravelRequestListVM>();

        //    // VP APPROVAL LIST
        //    if (isVP)
        //    {
        //        // get travel requests that need to be approved by ceo and 
        //        // where the requesting employees vp is the logged in user
        //        trList = await _context.TravelRequests
        //        .Where(q => q.ApprovalStatus == ApprovalStatus.Pending &&
        //                    q.User.DepartmentDirector.ToLower() == user.Email.ToLower())
        //        .Include(q => q.User)
        //        .OrderByDescending(q => q.ConferenceStartDate)
        //        .Select(q => new TravelRequestListVM
        //        {
        //            Id = q.Id,
        //            FirstName = q.User.FirstName,
        //            LastName = q.User.LastName,
        //            Location = q.Location,
        //            ConferenceStartDate = q.ConferenceStartDate,
        //            ConferenceEndDate = q.ConferenceEndDate,
        //            TransportationMode = q.TransportationMode,
        //            CostOfConference = q.CostOfConference,
        //            ApprovalStatus = q.ApprovalStatus
        //        })
        //        .ToListAsync();
        //    }

        //    // CEO APPROVAL LIST
        //    if (isCEO)
        //    {
        //        trList = await _context.TravelRequests
        //        .Where(q => q.ApprovalStatus == ApprovalStatus.ApprovedByVP)
        //        .Include(q => q.User)
        //        .OrderByDescending(q => q.ConferenceStartDate)
        //        .Select(q => new TravelRequestListVM
        //        {
        //            Id = q.Id,
        //            FirstName = q.User.FirstName,
        //            LastName = q.User.LastName,
        //            Location = q.Location,
        //            ConferenceStartDate = q.ConferenceStartDate,
        //            ConferenceEndDate = q.ConferenceEndDate,
        //            TransportationMode = q.TransportationMode,
        //            CostOfConference = q.CostOfConference,
        //            ApprovalStatus = q.ApprovalStatus
        //        })
        //        .ToListAsync();
        //    }

        //    // NEED TO BE BOOKED LIST
        //    if (isProcessor)
        //    {
        //        trList = await _context.TravelRequests
        //        .Where(q => q.ApprovalStatus == ApprovalStatus.ApprovedByCEO)
        //        .Include(q => q.User)
        //        .OrderByDescending(q => q.ConferenceStartDate)
        //        .Select(q => new TravelRequestListVM
        //        {
        //            Id = q.Id,
        //            FirstName = q.User.FirstName,
        //            LastName = q.User.LastName,
        //            Location = q.Location,
        //            ConferenceStartDate = q.ConferenceStartDate,
        //            ConferenceEndDate = q.ConferenceEndDate,
        //            TransportationMode = q.TransportationMode,
        //            CostOfConference = q.CostOfConference,
        //            ApprovalStatus = q.ApprovalStatus
        //        })
        //        .ToListAsync();
        //    }

        //    if (isAdmin)
        //    {
        //        trList = await _context.TravelRequests
        //            .Include(q => q.User)
        //            .OrderByDescending(q => q.ConferenceStartDate)
        //            .Select(q => new TravelRequestListVM
        //            {
        //                Id = q.Id,
        //                FirstName = q.User.FirstName,
        //                LastName = q.User.LastName,
        //                Location = q.Location,
        //                ConferenceStartDate = q.ConferenceStartDate,
        //                ConferenceEndDate = q.ConferenceEndDate,
        //                TransportationMode = q.TransportationMode,
        //                CostOfConference = q.CostOfConference,
        //                ApprovalStatus = q.ApprovalStatus
        //            })
        //            .ToListAsync();
        //    }

        //    return View(trList);
        //}
    }
}
