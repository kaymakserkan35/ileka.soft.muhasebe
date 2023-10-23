using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using ui.Models.ListingModels;

namespace ui.Models.UserModel
{
    [PageModel]
    public class UserListingModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }


        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public bool EmailConfirmed { get; set; } = false;
        public bool PhoneNumberConfirmed { get; set; } = false;


        public List<FirmListingBasicModel> Firms { get; set; }
        public List<string> Roles { get; set; }



    }
}
