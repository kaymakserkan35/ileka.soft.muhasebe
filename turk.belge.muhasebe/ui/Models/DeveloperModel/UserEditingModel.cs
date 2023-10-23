using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using ui.Models.ListingModels;
using ui.ModelStates;

namespace ui.Models.UserModel
{
    [PageModel]
    public class UserEditingModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string SurName { get; set; } = "";

        [Email]
        public string Email { get; set; } = "";
        public string PhoneNumber { get; set; }




        public bool EmailConfirmed { get; set; } = false;
        public bool PhoneNumberConfirmed { get; set; } = false;

        public virtual string? PhoneNumberOptional { get; set; }
        public virtual string? EmailOptional { get; set; }


        public List<FirmListingBasicModel> Firms { get; set; }
        public List<RoleListingBasicModel> Roles { get; set; }

        public List<int> SelectedFirms { get; set; }
        public List<int> SelectedRoles { get; set; }


    }
}
