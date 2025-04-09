using System.ComponentModel.DataAnnotations.Schema;

namespace HapoTravelRequest.Models.TravelRequest;

public class TravelRequestReadOnlyVM
{
    public int Id { get; set; }

    //****************** User data ******************
    public string UserId { get; set; }

    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [Display(Name = "Last Name")]
    public string LastName { get; set; }

    [Display(Name = "Date Of Birth")]
    public DateOnly DateOfBirth { get; set; }

    [Display(Name = "Phone Number")]
    public string PhoneNumber { get; set; }

    [Display(Name = "Department")]
    public string Department { get; set; }

    [Display(Name = "Position/Title")]
    public string PositionTitle { get; set; }

    [Display(Name = "Dept. Director Email")]
    public string DepartmentDirector { get; set; }

    //****************** Travel Request ******************
    [Display(Name = "Purpose of Travel")]
    public string? PurposeOfTravel { get; set; }

    [Display(Name = "Non Employee Guest?")]
    public bool NonEmployeeGuests { get; set; }

    [Display(Name = "Non Employee Legal Name")]
    public string? NonEmployeeLegalName { get; set; }

    [Display(Name = "Non Employee DOB")]
    public DateTime? NonEmployeeDOB { get; set; }

    [Display(Name = "Conference Description")]
    public string? ConferenceDescription { get; set; }

    [Display(Name = "Conference Link")]
    public string? ConferenceLink { get; set; }

    [Display(Name = "Alternative Text (optional)")]
    public string? AlternativeText { get; set; }

    [Display(Name = "Location")]
    public string? Location { get; set; }

    [Display(Name = "Cost of Conference")]
    public decimal? CostOfConference { get; set; }

    [Display(Name = "Conference Start Date")]
    public DateTime? ConferenceStartDate { get; set; }

    [Display(Name = "Conference End Date")]
    public DateTime? ConferenceEndDate { get; set; }

    [Display(Name = "Registration Deadline")]
    public DateTime? RegistrationDeadline { get; set; }

    [Display(Name = "Departure Date")]
    public DateTime DepartureDate { get; set; }

    [Display(Name = "Return Date")]
    public DateTime ReturnDate { get; set; }

    [Display(Name = "How many HAPO employees attending")]
    public int EmployeesAttending { get; set; }

    [Display(Name = "Employee Attending Names")]
    public string? EmployeesAttendingNames { get; set; }

    [Display(Name = "Conference Hotel Name")]
    public string? ConferenceHotelName { get; set; }

    [Display(Name = "Preferred Lodging Info")]
    public string? PreferredLodgingInfo { get; set; }

    [Display(Name = "Special Travel Request")]
    public string? SpecialTravelRequest { get; set; }

    [Display(Name = "Transportation Type")]
    public string? TransportationMode { get; set; }

    [Display(Name = "Airline Details")]
    public string? AirlineDetails { get; set; }

    [Display(Name = "Flight Cost")]
    public decimal? FlightCost { get; set; }

    [Display(Name = "Ground Transportation")]
    public string? GroundTransportation { get; set; }

    public bool MileageReimbursement { get; set; }

    [Display(Name = "Mileage Round Trip")]
    public int? MileageRoundTrip { get; set; }

    public bool MIE { get; set; }

    [Display(Name = "Daily MIE Amount")]
    public decimal? DailyMIEAmount { get; set; }

    [Display(Name = "Days for MIE")]
    public int? DaysForMIE { get; set; }

    [Display(Name = "Deposit Account")]
    public string? DepositAccount { get; set; }

    [Display(Name = "Account Type")]
    public string? AccountType { get; set; }

    [Display(Name = "Corporate Card?")]
    public bool CorporateCard { get; set; }

    [Display(Name = "Briefly explain how the conference is beneficial")]
    public string? ValueExplination { get; set; }

    [Display(Name = "Emergency Contact Name")]
    public string EmergencyContactname { get; set; }

    [Display(Name = "Emergency Contact Phone")]
    public string EmergencyContactPhoneNumber { get; set; }

    [Display(Name = "TSA Number")]
    public string? TSANumber { get; set; }

    [Display(Name = "Ground options")]
    public string? GroundOptions { get; set; }

    [Display(Name = "Are you registered for this conference?")]
    public bool RegisteredForConference { get; set; }

    [Display(Name = "Are you registered?")]
    public bool Registered { get; set; }
}
