using HapoTravelRequest.Models.TravelRequest;
using Microsoft.EntityFrameworkCore;

namespace HapoTravelRequest.Services;

public class TravelRequestService
{
    private readonly ApplicationDbContext _context;

    public TravelRequestService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<TravelRequestListVM>> GetTravelRequestsListAsync(
    Func<IQueryable<TravelRequest>, IQueryable<TravelRequest>> filter,
    int take = int.MaxValue)
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
}
