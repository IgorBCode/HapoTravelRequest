using System.Diagnostics;
using HapoTravelRequest.Models;
using HapoTravelRequest.Models.TravelRequest;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HapoTravelRequest.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // get 3 most recent travel requests
            var travelRequests = await _context.TravelRequests
                .Include(tr => tr.User)
                .OrderByDescending(tr => tr.ConferenceStartDate)
                .Take(3)
                .Select(tr => new TravelRequestListVM
                {
                    FirstName = tr.User.FirstName,
                    LastName = tr.User.LastName,
                    Location = tr.Location,
                    ConferenceStartDate = tr.ConferenceStartDate,
                    ConferenceEndDate = tr.ConferenceEndDate,
                    TransportationMode = tr.TransportationMode,
                    CostOfConference = tr.CostOfConference
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
