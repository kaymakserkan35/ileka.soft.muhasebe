using ui.Models.ListingBasicModels;
using ui.Models.UserModel;

namespace ui.Models.DeveloperModel
{
    public class FirmAddingModel  : AModel
    {

        public bool SoleTrader { get; set; } = true;
        public string FirmEMail { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        

        public string UserName { get; set; }
        public string UserSurName { get; set; }
        public string UserEmail { get; set; }
        public string UserEmailOptional { get; set; }
        public string UserPhone { get; set; }
        public string UserEmailPhone { get; set; }
        public string UserPassword { get; set; }



        public List<ModuleListingBasicModel> Modulles { get; set; }
        public List<int> SelectedModules { get; set; }
    }
}
