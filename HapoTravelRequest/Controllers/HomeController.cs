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
            // get 3 most recent travel requests
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

            return View(travelRequests);
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
