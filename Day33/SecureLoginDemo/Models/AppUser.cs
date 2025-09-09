namespace Jagan.EmployeeApp.Models
{
    public class AppUser
    {
        public int Id { get; set; }
        public string UserName { get; set; } = default!;
        public string PasswordHash { get; set; } = default!;
        public string Role { get; set; } = "User";
    }
}
