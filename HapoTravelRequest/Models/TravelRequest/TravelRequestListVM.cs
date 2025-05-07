namespace HapoTravelRequest.Models.TravelRequest;

public class TravelRequestListVM
{
    // user info
    public required string FirstName { get; set; }
    public required string LastName { get; set; }

    // travel request info
    public int Id { get; set; }
    public required string ConferenceDescription { get; set; }
    public required string Location { get; set; }
    public DateTime ConferenceStartDate { get; set; }
    public DateTime ConferenceEndDate { get; set; }
    public string? TransportationMode { get; set; }
    public decimal? CostOfConference { get; set; }
    public ApprovalStatus ApprovalStatus { get; set; }
}
