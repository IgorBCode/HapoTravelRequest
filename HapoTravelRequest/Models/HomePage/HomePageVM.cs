using HapoTravelRequest.Models.TravelRequest;

namespace HapoTravelRequest.Models;

public class HomePageVM
{
    public List<TravelRequestListVM> UserTravelRequests { get; set; } = new();
    public List<TravelRequestListVM> BookerList { get; set; } = new();
    public List<TravelRequestListVM> VPApprovalList { get; set; } = new();
    public List<TravelRequestListVM> CEOApprovalList { get; set; } = new();
    public List<TravelRequestListVM> AdminApprovalList { get; set; } = new();
}
