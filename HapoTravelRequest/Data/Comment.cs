namespace HapoTravelRequest.Data
{
    public class Comment
    {
        public Guid Id { get; set; }

        public string Content { get; set; }
        public DateTime CreatedTime { get; set; }

        // foreign key linking comment to travel request
        [Required]
        public TravelRequest TravelRequest { get; set; }
        public Guid TravelRequestId { get; set; }

        // foreign key linking comment to user who posted it
        public ApplicationUser User { get; set; }
        public Guid UserId { get; set; }

    }
}
