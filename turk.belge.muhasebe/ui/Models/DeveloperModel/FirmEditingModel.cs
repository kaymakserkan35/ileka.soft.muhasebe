using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using service.Dtos.UserDtos;
using ui.Models.ListingBasicModels;
using ui.Models.UserModel;

namespace ui.Models.DeveloperModel
{
    [PageModel]
    public class FirmEditingModel : AModel
    {

        public bool SoleTrader { get; set; } = true;
        public string EMail { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public UserEditingModel User { get; set; } = null;

        public List<ModuleListingBasicModel> Modulles { get; set; }
        public List<int> SelectedModules { get; set; }
    }
}
