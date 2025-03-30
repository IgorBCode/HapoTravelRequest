using HapoTravelRequest.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace HapoTravelRequest.Data
{
    public class TravelRequest
    {
        public int Id { get; set; }

        [MaxLength(300)]
        public string? PurposeOfTravel { get; set; }

        public bool NonEmployeeGuests { get; set; }

        [MaxLength(100)]
        public string? NonEmployeeLegalName { get; set; }

        public DateTime? NonEmployeeDOB { get; set; }

        [MaxLength(300)]
        public string? ConferenceDescription { get; set; }

        [MaxLength(100)]
        public string? ConferenceLink { get; set; }

        [MaxLength(200)]
        public string? AlternativeText { get; set; }

        [MaxLength(200)]
        public string? Location { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? CostOfConference { get; set; }

        [DataType(DataType.Date)]
        public DateTime? RegistrationDeadline { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ConferenceStartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ConferenceEndDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DepartureDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ReturnDate { get; set; }

        public int EmployeesAttending { get; set; }

        [MaxLength(500)]
        public string? EmployeesAttendingNames { get; set; }

        [MaxLength(50)]
        public string? ConferenceHotelName { get; set; }

        [MaxLength(200)]
        public string? PreferredLodgingInfo { get; set; }

        [MaxLength(300)]
        public string? SpecialTravelRequest { get; set; }

        [MaxLength(50)]
        public string? TransportationMode { get; set; }

        [MaxLength(500)]
        public string? AirlineDetails { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? FlightCost { get; set; }

        [MaxLength(100)]
        public string? GroundTransportation  { get; set; }

        public bool MileageReimbursement { get; set; }

        public int? MileageRoundTrip { get; set; }

        public bool MIE { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? DailyMIEAmount { get; set; }

        public int? DaysForMIE { get; set; }

        [MaxLength(20)]
        public string? DepositAccount { get; set; }

        [MaxLength(20)]
        public string? AccountType { get; set; }

        public bool CorporateCard { get; set; }

        public ApprovalStatus ApprovalStatus { get; set; }

        public string? ValueExplination { get; set; }

        [MaxLength(100)]
        public string? EmergencyContactname { get; set; }

        [MaxLength(20)]
        public string? EmergencyContactPhoneNumber { get; set; }

        public string? TSANumber { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? TotalCost { get; set; }

        public string? DepartureReturnDates { get; set; }

        public string? GroundOptions { get; set; }

        public bool RegisteredForConference { get; set; }

        public bool Registered { get; set; }

        // creator data
        public string UserId { get; set; }// Foreign key for user who created request
        public ApplicationUser User { get; set; }

        // travel request comments
        public List<Comment> Comments { get; set; } = new List<Comment>();


    }
}
