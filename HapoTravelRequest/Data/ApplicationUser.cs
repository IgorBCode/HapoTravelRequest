namespace HapoTravelRequest.Data
{
    public class ApplicationUser : IdentityUser // FARTS
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string PositionTitle { get; set; }
        public string Department { get; set; }
        public string DepartmentDirector { get; set; }

        public List<TravelRequest> TravelRequests { get; set; } = new List<TravelRequest>();
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
