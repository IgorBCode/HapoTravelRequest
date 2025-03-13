using System.Diagnostics;
using HapoTravelRequest.Models;
using HapoTravelRequest.Models.TravelRequest;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace HapoTravelRequest.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            bool isVP = await _userManager.IsInRoleAsync(user, "VP");
            bool isCEO = await _userManager.IsInRoleAsync(user, "CEO");
            bool isBooker = await _userManager.IsInRoleAsync(user, "Booker");
            bool isAdmin = await _userManager.IsInRoleAsync(user, "CEO");

            // get 3 most recent travel requests for the logged in user
            var travelRequests = await _context.TravelRequests
                .Where(q => q.UserId == user.Id)
                .Include(q => q.User)
                .OrderByDescending(q => q.ConferenceStartDate)
                .Take(3)
                .Select(q => new TravelRequestListVM
                {
                    FirstName = q.User.FirstName,
                    LastName = q.User.LastName,
                    Location = q.Location,
                    ConferenceStartDate = q.ConferenceStartDate,
                    ConferenceEndDate = q.ConferenceEndDate,
                    TransportationMode = q.TransportationMode,
                    CostOfConference = q.CostOfConference
                })
                .ToListAsync();

            // Lists for all other travel requests
            List<TravelRequestListVM> vpApprovalList = new List<TravelRequestListVM>();
            List<TravelRequestListVM> ceoApprovalList = new List<TravelRequestListVM>();
            List<TravelRequestListVM> adminList = new List<TravelRequestListVM>();
            List<TravelRequestListVM> bookerList = new List<TravelRequestListVM>();
            
            // VP APPROVAL LIST
            if (isVP)
            {
                // get travel requests that need to be approved by ceo and 
                // where the requesting employees vp is the logged in user
                vpApprovalList = await _context.TravelRequests
                .Where(q => q.ApprovalStatus == ApprovalStatus.Pending &&
                            q.User.DepartmentDirector.ToLower() == user.Email.ToLower())
                .Include(q => q.User)
                .OrderByDescending(q => q.ConferenceStartDate)
                .Take(3)
                .Select(q => new TravelRequestListVM
                {
                    FirstName = q.User.FirstName,
                    LastName = q.User.LastName,
                    Location = q.Location,
                    ConferenceStartDate = q.ConferenceStartDate,
                    ConferenceEndDate = q.ConferenceEndDate,
                    TransportationMode = q.TransportationMode,
                    CostOfConference = q.CostOfConference
                })
                .ToListAsync();
            }

            // CEO APPROVAL LIST
            if (isCEO)
            {
                ceoApprovalList = await _context.TravelRequests
                .Where(q => q.ApprovalStatus == ApprovalStatus.ApprovedByVP)
                .Include(q => q.User)
                .OrderByDescending(q => q.ConferenceStartDate)
                .Take(3)
                .Select(q => new TravelRequestListVM
                {
                    FirstName = q.User.FirstName,
                    LastName = q.User.LastName,
                    Location = q.Location,
                    ConferenceStartDate = q.ConferenceStartDate,
                    ConferenceEndDate = q.ConferenceEndDate,
                    TransportationMode = q.TransportationMode,
                    CostOfConference = q.CostOfConference
                })
                .ToListAsync();
            }

            // NEED TO BE BOOKED LIST
            if (isBooker)
            {
                bookerList = await _context.TravelRequests
                .Where(q => q.ApprovalStatus == ApprovalStatus.ApprovedByCEO)
                .Include(q => q.User)
                .OrderByDescending(q => q.ConferenceStartDate)
                .Take(3)
                .Select(q => new TravelRequestListVM
                {
                    FirstName = q.User.FirstName,
                    LastName = q.User.LastName,
                    Location = q.Location,
                    ConferenceStartDate = q.ConferenceStartDate,
                    ConferenceEndDate = q.ConferenceEndDate,
                    TransportationMode = q.TransportationMode,
                    CostOfConference = q.CostOfConference
                })
                .ToListAsync();
            }

            if (isAdmin)
            {
                adminList = await _context.TravelRequests
                .Where(q => q.ApprovalStatus == ApprovalStatus.ApprovedByCEO ||
                            q.ApprovalStatus == ApprovalStatus.ApprovedByVP)
                .Include(q => q.User)
                .OrderByDescending(q => q.ConferenceStartDate)
                .Take(3)
                .Select(q => new TravelRequestListVM
                {
                    FirstName = q.User.FirstName,
                    LastName = q.User.LastName,
                    Location = q.Location,
                    ConferenceStartDate = q.ConferenceStartDate,
                    ConferenceEndDate = q.ConferenceEndDate,
                    TransportationMode = q.TransportationMode,
                    CostOfConference = q.CostOfConference
                })
                .ToListAsync();
            }

            var model = new HomePageVM
            {
                UserTravelRequests = travelRequests,
                BookerList = bookerList,
                VPApprovalList = vpApprovalList,
                CEOApprovalList = ceoApprovalList,
                AdminApprovalList = adminList
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
