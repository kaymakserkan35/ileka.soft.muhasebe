using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;

namespace ui.Models
{
    [PageModel]
    public class LoginModel
    {
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        public string? Redirect { get; set; } = "";
    }
}
