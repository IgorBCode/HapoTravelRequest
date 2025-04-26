using System.Diagnostics;
using HapoTravelRequest.Models;
using HapoTravelRequest.Models.TravelRequest;
using HapoTravelRequest.Services;

namespace HapoTravelRequest.Controllers
{
    [Authorize]
    public class HomeController(
        ILogger<HomeController> logger, 
        ApplicationDbContext context, 
        UserManager<ApplicationUser> userManager,
        TravelRequestService travelRequestService) : Controller
    {
        private readonly ILogger<HomeController> _logger = logger;
        private readonly ApplicationDbContext _context = context;
        private readonly UserManager<ApplicationUser> _userManager = userManager;
        private readonly TravelRequestService _travelRequestService = travelRequestService;

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return RedirectToPage("/Account/Login");
            }

            var roles = await _userManager.GetRolesAsync(user);

            var model = new HomePageVM
            {
                UserTravelRequests = await _travelRequestService.GetTravelRequestsListAsync(
                    query => query.Where(q => q.UserId == user.Id), 3),

                VPApprovalList = roles.Contains("VP") || roles.Contains("Admin")
                    ? await _travelRequestService.GetTravelRequestsListAsync(
                        query => query.Where(q => q.ApprovalStatus == ApprovalStatus.Pending &&
                                                  q.User.DepartmentDirector.ToLower() == user.Email!.ToLower()), 3)
                    : [],

                CEOApprovalList = roles.Contains("CEO") || roles.Contains("Admin")
                    ? await _travelRequestService.GetTravelRequestsListAsync(
                        query => query.Where(q => q.ApprovalStatus == ApprovalStatus.ApprovedByVP), 3)
                    : [],

                ProcessorList = roles.Contains("Processor") || roles.Contains("Admin")
                    ? await _travelRequestService.GetTravelRequestsListAsync(
                        query => query.Where(q => q.ApprovalStatus == ApprovalStatus.ApprovedByCEO), 3)
                    : [],

                AdminApprovalList = roles.Contains("Admin")
                    ? await _travelRequestService.GetTravelRequestsListAsync(
                        query => query.Where(q => q.ApprovalStatus == ApprovalStatus.ApprovedByVP ||
                                                  q.ApprovalStatus == ApprovalStatus.ApprovedByCEO), 3)
                    : []
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
