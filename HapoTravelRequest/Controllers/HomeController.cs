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
            };

            // VP list
            if (roles.Contains("VP") || roles.Contains("Administrator"))
            {
                if (roles.Contains("VP"))
                {
                    model.VPApprovalList = await _travelRequestService.GetTravelRequestsListAsync(
                        query => query.Where(q => q.ApprovalStatus == ApprovalStatus.Pending &&
                                                  q.User.DepartmentDirector.ToLower() == user.Email!.ToLower()), 3);
                }
                else if (roles.Contains("Administrator")) // get requests that are waiting approval from any vp
                {
                    model.VPApprovalList = await _travelRequestService.GetTravelRequestsListAsync(
                        query => query.Where(q => q.ApprovalStatus == ApprovalStatus.Pending), 3);
                }

            }

            // CEO list
            if (roles.Contains("CEO") || roles.Contains("Administrator"))
            {
                model.CEOApprovalList = await _travelRequestService.GetTravelRequestsListAsync(
                        query => query.Where(q => q.ApprovalStatus == ApprovalStatus.ApprovedByVP), 3);
            }

            if (roles.Contains("Processor") || roles.Contains("Administrator"))
            {
                model.ProcessorList = await _travelRequestService.GetTravelRequestsListAsync(
                        query => query.Where(q => q.ApprovalStatus == ApprovalStatus.ApprovedByCEO), 3);
            }

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
