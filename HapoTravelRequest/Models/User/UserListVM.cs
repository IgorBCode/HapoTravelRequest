namespace HapoTravelRequest.Models.User;

public class UserListVM
{
    public string UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PositionTitle { get; set; }
    public string CurrentRole { get; set; }
    public List<string> AvailableRoles { get; set; }
}
