namespace HapoTravelRequest.Models.TravelRequest
{
    public class TravelRequestReadOnlyVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Department { get; set; }
        public string PositionTitle { get; set; }
        public string DepartmentDirector { get; set; }
        public string PurposeOfTravel { get; set; }
        public string ConferenceDescription { get; set; }
        public string ConferenceLink { get; set; }
        public string Location { get; set; }
        public decimal? FlightCost { get; set; }
        public string TransportationMode { get; set; }
        public DateTime? ConferenceStartDate { get; set; }
        public DateTime? ConferenceEndDate { get; set; }
        public DateTime? DepartureDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }

        public bool IsProcessor { get; set; }
        public bool IsApprover { get; set; }

        public string? ItineraryNumber { get; set; }
        public string? ConfirmationNumber { get; set; }

    }
}
