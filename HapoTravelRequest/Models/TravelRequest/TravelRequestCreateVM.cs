﻿using HapoTravelRequest.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HapoTravelRequest.Models.TravelRequest;

public class TravelRequestCreateVM
{
    public TravelRequestCreateVM()
    {
        // default dates
        DepartureDate = DateTime.Today;
        ReturnDate = DateTime.Today.AddDays(1);
        ConferenceStartDate = DateTime.Today;
        ConferenceEndDate = DateTime.Today.AddDays(1);

        // initialize non-nullable string properties
        UserId = string.Empty;
        FirstName = string.Empty;
        LastName = string.Empty;
        PhoneNumber = string.Empty;
        Department = string.Empty;
        PositionTitle = string.Empty;
        DepartmentDirector = string.Empty;
    }

    public int Id { get; set; }

    //****************** User data ******************
    [Required]
    public string UserId { get; set; }

    [Required, MaxLength(100)]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [Required, MaxLength(100)]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [Display(Name = "Date Of Birth")]
    public DateOnly DateOfBirth { get; set; }

    [Required]
    [DataType(DataType.PhoneNumber)]
    [Display(Name = "Phone Number")]
    public string PhoneNumber { get; set; }

    [Required]
    [Display(Name = "Department")]
    public string Department { get; set; }

    [Required]
    [Display(Name = "Position/Title")]
    public string PositionTitle { get; set; }

    [Required]
    [Display(Name = "Dept. Director Email")]
    public string DepartmentDirector { get; set; }

    //****************** Travel Request ******************
    [Required]
    [MaxLength(300)]
    [Display(Name = "Purpose of Travel")]
    public required string PurposeOfTravel { get; set; }

    [Display(Name = "Non Employee Guest?")]
    public bool NonEmployeeGuests { get; set; }

    [MaxLength(100)]
    [Display(Name = "Non Employee Legal Name")]
    public string? NonEmployeeLegalName { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Non Employee DOB")]
    public DateTime? NonEmployeeDOB { get; set; }

    [Required]
    [MaxLength(300)]
    [Display(Name = "Conference Description")]
    public required string ConferenceDescription { get; set; }

    [MaxLength(100)]
    [Display(Name = "Conference Link")]
    public string? ConferenceLink { get; set; }

    [MaxLength(200)]
    [Display(Name = "Alternative Text (optional)")]
    public string? AlternativeText { get; set; }

    [Required]
    [MaxLength(200)]
    [Display(Name = "Location")]
    public required string Location { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    [DataType(DataType.Currency)]
    [Display(Name = "Cost of Conference")]
    public decimal? CostOfConference { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Conference Start Date")]
    [Required]
    public DateTime ConferenceStartDate { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Conference End Date")]
    [Required]
    public DateTime ConferenceEndDate { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Registration Deadline")]
    public DateTime? RegistrationDeadline { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Departure Date")]
    public DateTime? DepartureDate { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Return Date")]
    public DateTime? ReturnDate { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    [Display(Name = "How many HAPO employees attending")]
    public int EmployeesAttending { get; set; }

    [MaxLength(500)]
    [Display(Name = "Employee Attending Names")]
    public string? EmployeesAttendingNames { get; set; }

    [MaxLength(50)]
    [Display(Name = "Conference Hotel Name")]
    public string? ConferenceHotelName { get; set; }

    [MaxLength(200)]
    [Display(Name = "Preferred Lodging Info")]
    public string? PreferredLodgingInfo { get; set; }

    [MaxLength(300)]
    [Display(Name = "Special Travel Request")]
    public string? SpecialTravelRequest { get; set; }

    [MaxLength(50)]
    [Display(Name = "Transportation Type")]
    public string? TransportationMode { get; set; }

    [MaxLength(500)]
    [Display(Name = "Airline Details")]
    public string? AirlineDetails { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    [DataType(DataType.Currency)]
    [Display(Name = "Flight Cost")]
    public decimal? FlightCost { get; set; }

    [MaxLength(100)]
    [Display(Name = "Ground Transportation")]
    public string? GroundTransportation { get; set; }

    [Display(Name = "Mileage Reimbursement")]
    public bool MileageReimbursement { get; set; }

    [Display(Name = "Mileage Round Trip")]
    public int? MileageRoundTrip { get; set; }

    [Display(Name = "Meals & Incidental Expenses")]
    public bool MIE { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    [DataType(DataType.Currency)]
    [Display(Name = "Daily MIE Amount")]
    public decimal? DailyMIEAmount { get; set; }

    [Display(Name = "Days for MIE")]
    public int? DaysForMIE { get; set; }

    [MaxLength(20)]
    [Display(Name = "Deposit Account")]
    public string? DepositAccount { get; set; }

    [MaxLength(20)]
    [Display(Name = "Account Type")]
    public string? AccountType { get; set; }

    [Display(Name = "Corporate Card?")]
    public bool CorporateCard { get; set; }

    [Display(Name = "Briefly explain how the conference is beneficial")]
    public string? ValueExplanation { get; set; }

    [MaxLength(100)]
    [Display(Name = "Emergency Contact Name")]
    public string? EmergencyContactName { get; set; }

    [MaxLength(20)]
    [DataType(DataType.PhoneNumber)]
    [Display(Name = "Emergency Contact Phone")]
    public string? EmergencyContactPhoneNumber { get; set; }

    [Display(Name = "TSA Number")]
    public string? TSANumber { get; set; }

    [Display(Name = "Ground options")]
    public string? GroundOptions { get; set; }

    [Display(Name = "Are you registered for this conference?")]
    public bool RegisteredForConference { get; set; }

    [Display(Name = "Are you registered?")]
    public bool Registered { get; set; }
}