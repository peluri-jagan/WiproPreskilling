using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserRegistrationApp.Models;

namespace UserRegistrationApp.Pages.Account
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public UserRegistration User { get; set; }

        public void OnGet()
        {
            // No initialization needed here
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // Show validation errors
            }

            // Registration logic here
            // For example: Save User to Database (not implemented)

            // Redirect or show success message
            TempData["Success"] = "Registration successful!";
            return RedirectToPage("/Index");
        }
    }
}
