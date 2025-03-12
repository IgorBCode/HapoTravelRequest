using System.ComponentModel.DataAnnotations.Schema;

namespace HapoTravelRequest.Models.TravelRequest;

public class TravelRequestCreateVM
{
    public int Id { get; set; }

    //****************** User data ******************
    public string UserId { get; set; }

    [Required, MaxLength(100)]
    public string FirstName { get; set; }

    [Required, MaxLength(100)]
    public string LastName { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateOnly DateOfBirth { get; set; }

    [Required]
    [DataType(DataType.PhoneNumber)]
    public string PhoneNumber { get; set; }

    [Required]
    public string Department { get; set; }

    [Required]
    public string PositionTitle { get; set; }

    [Required]
    public string DepartmentDirector { get; set; }

    //****************** Travel Request ******************
    [MaxLength(300)]
    public string PurposeOfTravel { get; set; }

    public bool NonEmployeeGuests { get; set; }

    [MaxLength(100)]
    public string? NonEmployeeLegalName { get; set; }

    [DataType(DataType.Date)]
    public DateTime? NonEmployeeDOB { get; set; }

    [MaxLength(300)]
    public string ConferenceDescription { get; set; }

    [MaxLength(100)]
    public string ConferenceLink { get; set; }

    [MaxLength(200)]
    public string? AlternativeText { get; set; }

    [MaxLength(200)]
    public string Location { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    [DataType(DataType.Currency)]
    public decimal CostOfConference { get; set; }

    [DataType(DataType.Date)]
    public DateTime ConferenceStartDate { get; set; }

    [DataType(DataType.Date)]
    public DateTime ConferenceEndDate { get; set; }

    [DataType(DataType.Date)]
    public DateTime DepartureDate { get; set; }

    [DataType(DataType.Date)]
    public DateTime ReturnDate { get; set; }

    public int EmployeesAttending { get; set; }

    [MaxLength(500)]
    public string EmployeesAttendingNames { get; set; }

    [MaxLength(50)]
    public string ConferenceHotelName { get; set; }

    [MaxLength(200)]
    public string? PreferredLodgingInfo { get; set; }

    [MaxLength(300)]
    public string? SpecialTravelRequest { get; set; }

    [MaxLength(50)]
    public string TransportationMode { get; set; }

    [MaxLength(500)]
    public string? AirlineDetails { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    [DataType(DataType.Currency)]
    public decimal? FlightCost { get; set; }

    [MaxLength(100)]
    public string? GroundTransportation { get; set; }

    public int? MileageReimbursement { get; set; }

    public int? MileageRoundTrip { get; set; }

    public bool MIE { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    [DataType(DataType.Currency)]
    public decimal? DailyMIEAmount { get; set; }

    public int? DaysForMIE { get; set; }

    [MaxLength(20)]
    public string? DepositAccount { get; set; }

    [MaxLength(20)]
    public string? AccountType { get; set; }

    public bool CorporateCard { get; set; }

    public string? ValueExplination { get; set; }

    [MaxLength(100)]
    public string EmergencyContactname { get; set; }

    [MaxLength(20)]
    [DataType(DataType.PhoneNumber)]
    public string EmergencyContactPhoneNumber { get; set; }

    public string? TSANumber { get; set; }

    public string? GroundOptions { get; set; }

    public bool RegisteredForConference { get; set; }

    public bool Registered { get; set; }
}
