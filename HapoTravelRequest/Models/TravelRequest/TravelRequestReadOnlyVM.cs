﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HapoTravelRequest.Models.Comment;

namespace HapoTravelRequest.Models.TravelRequest;

public class TravelRequestReadOnlyVM
{
    public int Id { get; set; }

    //****************** User data ******************
    public required string UserId { get; set; }

    [Display(Name = "First Name")]
    public required string FirstName { get; set; }

    [Display(Name = "Last Name")]
    public required string LastName { get; set; }

    [Display(Name = "Date Of Birth")]
    public DateOnly DateOfBirth { get; set; }

    [Display(Name = "Phone Number")]
    public required string PhoneNumber { get; set; }

    [Display(Name = "Department")]
    public required string Department { get; set; }

    [Display(Name = "Position/Title")]
    public required string PositionTitle { get; set; }

    [Display(Name = "Dept. Director Email")]
    public required string DepartmentDirector { get; set; }

    //****************** Travel Request ******************
    [Display(Name = "Purpose of Travel")]
    public required string PurposeOfTravel { get; set; }

    [Display(Name = "Conference Link")]
    public string? ConferenceLink { get; set; }

    [Display(Name = "Non Employee Guest?")]
    public bool NonEmployeeGuests { get; set; }

    [Display(Name = "Non Employee Legal Name")]
    public string? NonEmployeeLegalName { get; set; }

    [Display(Name = "Non Employee DOB")]
    public DateTime? NonEmployeeDOB { get; set; }

    [Display(Name = "Conference Description")]
    public required string ConferenceDescription { get; set; }

    [Display(Name = "Alternative Text (optional)")]
    public string? AlternativeText { get; set; }

    [Display(Name = "Location")]
    public required string Location { get; set; }

    [Display(Name = "Cost of Conference")]
    public decimal? CostOfConference { get; set; }

    [Display(Name = "Conference Start Date")]
    public DateTime ConferenceStartDate { get; set; }

    [Display(Name = "Conference End Date")]
    public DateTime ConferenceEndDate { get; set; }

    [Display(Name = "Registration Deadline")]
    public DateTime? RegistrationDeadline { get; set; }

    [Display(Name = "Departure Date")]
    public DateTime? DepartureDate { get; set; }

    [Display(Name = "Return Date")]
    public DateTime? ReturnDate { get; set; }

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

    [Display(Name = "Mileage Reimbursement")]
    public bool MileageReimbursement { get; set; }

    [Display(Name = "Mileage Round Trip")]
    public int? MileageRoundTrip { get; set; }

    [Display(Name = "Meals & Incidentals")]
    public bool MIE { get; set; }

    [Display(Name = "Daily MIE Amount")]
    public decimal? DailyMIEAmount { get; set; }

    [Display(Name = "Days for MIE")]
    public int? DaysForMIE { get; set; }

    [Display(Name = "Deposit Account")]
    public string? DepositAccount { get; set; }

    [Display(Name = "Account Type")]
    public string? AccountType { get; set; }

    [Display(Name = "Corporate Card")]
    public bool CorporateCard { get; set; }

    [Display(Name = "Value Explanation")]
    public string? ValueExplanation { get; set; }

    [Display(Name = "Emergency Contact Name")]
    public string? EmergencyContactName { get; set; }

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

    [Display(Name = "Approval Status")]
    public ApprovalStatus ApprovalStatus { get; set; }

    //****************** Comment ******************
    [Display(Name = "Add comment")]
    public string? NewComment { get; set; }

    public List<CommentVM>? RequestComments { get; set; }
}