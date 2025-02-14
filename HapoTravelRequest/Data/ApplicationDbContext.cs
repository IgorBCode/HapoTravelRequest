using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace HapoTravelRequest.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // create roles on DB creation
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // set up relationships
            // One user => many travel requests
            builder.Entity<TravelRequest>()
                .HasOne(tr => tr.User)
                .WithMany(u => u.TravelRequests)
                .HasForeignKey(tr => tr.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // prevent cascade delete for comments
            builder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // cascade delete if TravelRequest is deleted
            builder.Entity<Comment>()
                .HasOne(c => c.TravelRequest)
                .WithMany(tr => tr.Comments)
                .HasForeignKey(c => c.TravelRequestId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "39e088b2-cd8e-40d2-8d14-7abd2662987b",
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                    
                },
                new IdentityRole
                {
                    Id = "3ec66596-f421-42a1-832c-365951b19e7d",
                    Name = "VP",
                    NormalizedName = "VP"
                },
                new IdentityRole
                {
                    Id = "e6429c0b-cc83-474e-8851-243fbcd898eb",
                    Name = "CEO",
                    NormalizedName = "CEO"
                },
                new IdentityRole
                {
                    Id = "b7641d7a-e9ba-47f3-bef7-f9bf36e935be",
                    Name = "Processor",
                    NormalizedName = "PROCESSOR"
                },
                new IdentityRole
                {
                    Id = "fc391dc9-7793-4ac2-b51e-474635c7d0d7",
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE"
                }
                );

            // create default admin on DB creation
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "10684443-90ea-4553-86a3-49d08b55dffe",
                    Email = "admin@localhost.com",
                    NormalizedEmail = "ADMIN@LOCALHOST.COM",
                    UserName = "admin@localhost.com",
                    NormalizedUserName = "ADMIN@LOCALHOST.COM",
                    PasswordHash = hasher.HashPassword(null, "AdminPass123!"),
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    FirstName = "Default",
                    LastName = "Admin",
                    DateOfBirth = new DateOnly(2000, 01, 01),
                    PositionTitle = "Administrator",
                    Department = "N/A",
                    DepartmentDirector = "N/A"
                });

            // assign admin role to admin user
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "39e088b2-cd8e-40d2-8d14-7abd2662987b",
                    UserId = "10684443-90ea-4553-86a3-49d08b55dffe"
                });
        }

        public DbSet<TravelRequest> TravelRequests { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
