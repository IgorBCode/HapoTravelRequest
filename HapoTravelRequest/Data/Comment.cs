namespace HapoTravelRequest.Data
{
    public class Comment
    {
        public int Id { get; set; }

        public string Content { get; set; }
        public DateTime CreatedTime { get; set; }

        // foreign key linking comment to user who posted it
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        // foreign key linking comment to travel request
        public int TravelRequestId { get; set; }
        public TravelRequest TravelRequest { get; set; }
    }
}
