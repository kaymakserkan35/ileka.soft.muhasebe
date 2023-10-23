using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;

namespace ui.Models.DeveloperModel
{
    [PageModel]
    public class DistrictModel :AModel
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
    }
}
