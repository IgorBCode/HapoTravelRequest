using System.Diagnostics;
using HapoTravelRequest.Models;
using HapoTravelRequest.Models.TravelRequest;

namespace HapoTravelRequest.Controllers
{
    [Authorize]
    public class HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager) : Controller
    {
        private readonly ILogger<HomeController> _logger = logger;
        private readonly ApplicationDbContext _context = context;
        private readonly UserManager<ApplicationUser> _userManager = userManager;

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return RedirectToPage("/Account/Login");
            }

            var userRoles = new Dictionary<string, bool>
            {
                ["VP"] = await _userManager.IsInRoleAsync(user, "VP"),
                ["CEO"] = await _userManager.IsInRoleAsync(user, "CEO"),
                ["Processor"] = await _userManager.IsInRoleAsync(user, "Processor"),
                ["Admin"] = await _userManager.IsInRoleAsync(user, "Admin")
            };

            var model = new HomePageVM
            {
                UserTravelRequests = await GetTravelRequestsListAsync(query => query.Where(q => q.UserId == user.Id), 3),
                VPApprovalList = userRoles["VP"]
                    ? await GetTravelRequestsListAsync(query => query.Where(q => q.ApprovalStatus == ApprovalStatus.Pending && q.User.DepartmentDirector.ToLower() == user.Email!.ToLower()), 3)
                    : [],
                CEOApprovalList = userRoles["CEO"]
                    ? await GetTravelRequestsListAsync(query => query.Where(q => q.ApprovalStatus == ApprovalStatus.ApprovedByVP), 3)
                    : [],
                ProcessorList = userRoles["Processor"]
                    ? await GetTravelRequestsListAsync(query => query.Where(q => q.ApprovalStatus == ApprovalStatus.ApprovedByCEO), 3)
                    : [],
                AdminApprovalList = userRoles["Admin"]
                    ? await GetTravelRequestsListAsync(query => query.Where(q => q.ApprovalStatus == ApprovalStatus.ApprovedByCEO || q.ApprovalStatus == ApprovalStatus.ApprovedByVP), 3)
                    : []
            };

            return View(model);
        }

        private async Task<List<TravelRequestListVM>> GetTravelRequestsListAsync(
            Func<IQueryable<TravelRequest>, IQueryable<TravelRequest>> filter,
            int take)
        {
            return await filter(_context.TravelRequests)
                .Include(q => q.User)
                .OrderByDescending(q => q.ConferenceStartDate)
                .Take(take)
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
