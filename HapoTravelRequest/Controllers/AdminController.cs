using HapoTravelRequest.Models;
using HapoTravelRequest.Models.User;
using Microsoft.EntityFrameworkCore;

namespace HapoTravelRequest.Controllers;

public class AdminController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AdminController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<IActionResult> UserList(string search)
    {
        var usersQuery = _userManager.Users.AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            usersQuery = usersQuery.Where(u =>
            u.FirstName.ToLower().Contains(search.ToLower()) ||
            u.LastName.ToLower().Contains(search.ToLower()) ||
            u.Email.ToLower().Contains(search.ToLower()));
        }

        //var users = await _userManager.Users.ToListAsync();
        var users = await usersQuery.ToListAsync();
        var userList = new List<UserListVM>();
        var allRoles = _roleManager.Roles.Select(r => r.Name).ToList();

        foreach (var user in users)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var currentRole = roles.FirstOrDefault() ?? "Employee";

            userList.Add(new UserListVM
            {
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PositionTitle = user.PositionTitle,
                CurrentRole = currentRole,
                AvailableRoles = allRoles
            });
        }

        ViewBag.SearchQuery = search;
        return View(userList);
    }

    [HttpPost]
    public async Task<IActionResult> ChangeRoleAjax([FromBody] ChangeRoleRequest request)
    {
        var user = await _userManager.FindByIdAsync(request.UserId);
        if (user == null)
        {
            return NotFound(new { success = false, message = "User not found" });
        }

        var currentRoles = await _userManager.GetRolesAsync(user);
        
        await _userManager.RemoveFromRolesAsync(user, currentRoles);
        await _userManager.AddToRoleAsync(user, request.NewRole);

        return Ok(new { success = true, message = "Role updated successfully" });
    }
}
