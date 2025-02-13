using System.ComponentModel.DataAnnotations.Schema;

namespace HapoTravelRequest.Data
{
    public class TravelRequest
    {
        public Guid Id { get; set; }

        [MaxLength(300)]
        public string PurposeOfTravel { get; set; }

        bool NonEmployeeGuests { get; set; }

        [MaxLength(100)]
        public string NonEmployeeLegalName { get; set; }

        public DateOnly NonEmployeeDOB { get; set; }

        [MaxLength(300)]
        public string ConferenceDescription { get; set; }

        [MaxLength(100)]
        public string ConferenceLink { get; set; }

        [MaxLength(200)]
        public string AlternativeText { get; set; }

        [MaxLength(200)]
        public string Location { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal CostOfConference { get; set; }

        [DataType(DataType.Date)]
        public DateOnly ConferenceStartDate { get; set; }

        [DataType(DataType.Date)]
        public DateOnly ConferenceEndDate { get; set; }

        [DataType(DataType.Date)]
        public DateOnly DepartureDate { get; set; }

        [DataType(DataType.Date)]
        public DateOnly ReturnDate { get; set; }

        public int EmployeesAttending { get; set; }

        [MaxLength(500)]
        public string EmployeesAttendingNames { get; set; }

        [MaxLength(50)]
        public string ConferenceHotelName { get; set; }

        [MaxLength(200)]
        public string PreferredLodgingInfo { get; set; }

        [MaxLength(300)]
        public string SpecialTravelRequest { get; set; }

        [MaxLength(50)]
        public string TransportationMode { get; set; }

        [MaxLength(500)]
        public string AirlineDetails { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal FlightCost { get; set; }

        [MaxLength(100)]
        public string GroundTransportation  { get; set; }

        public int MileageReimbursement { get; set; } // What datatype is this?

        public int MileageRoundTrip { get; set; }

        public bool MIE { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal DailyMIEAmount { get; set; }

        public int DaysForMIE { get; set; }

        [MaxLength(20)]
        public string DepositAccount { get; set; }

        [MaxLength(20)]
        public string AccountType { get; set; }

        public string ApprovalStatus { get; set; }

        public bool ApprovedByVP { get; set; }

        public bool ApprovedByCEO { get; set; }

        public bool Booked { get; set; }

        // creator data
        public ApplicationUser User { get; set; }
        public Guid UserId { get; set; }// Foreign key for user who created request

        // travel request comments
        public List<Comment> Comments { get; set; } = new List<Comment>();


    }
}
