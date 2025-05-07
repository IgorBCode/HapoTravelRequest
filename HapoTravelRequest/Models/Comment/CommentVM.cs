namespace HapoTravelRequest.Models.Comment;

public class CommentVM
{
    public required string Content { get; set; }
    public required string AuthorName { get; set; }
    public DateTime CreateTime { get; set; }
}
