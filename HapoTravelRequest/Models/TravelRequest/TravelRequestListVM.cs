namespace HapoTravelRequest.Models.TravelRequest;

public class TravelRequestListVM
{
    // user info
    public string FirstName { get; set; }
    public string LastName { get; set; }

    // travel request info
    public string Location { get; set; }
    public DateTime? ConferenceStartDate { get; set; }
    public DateTime? ConferenceEndDate { get; set; }
    public string? TransportationMode { get; set; }
    public decimal? CostOfConference { get; set; }
    public ApprovalStatus ApprovalStatus { get; set; }
}
