using entity.concretes.entities;
using entity.concretes.identity;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using System.ComponentModel.DataAnnotations;
using ui.Models.ListingBasicModels;

namespace ui.Models.DeveloperModel
{
    [PageModel]
    public class FirmListingModel :AModel
    {
        
        public bool SoleTrader { get; set; }
        public string EMail { get; set; }
        public string PhoneNumber { get; set; }




        public ICollection<ModuleListingBasicModel> Modules { get; set; }
        public ICollection<UserListingBasicModel> Users { get; set; }

    }
}
