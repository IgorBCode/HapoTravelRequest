namespace HapoTravelRequest.Data
{
    public class ApplicationUser : IdentityUser
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string? PositionTitle { get; set; }
        public required string Department { get; set; }
        public required string DepartmentDirector { get; set; }

        public ICollection<TravelRequest> TravelRequests { get; set; } = new List<TravelRequest>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
