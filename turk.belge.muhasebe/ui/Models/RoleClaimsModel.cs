using static entity.concretes.identity.RoleTable;

namespace ui.Models
{
    public class RoleClaimsModel
    {
        public RolesEnum Role { get; set; }
        public int RoleId { get; set; }

        public string ClaimA { get; set; }
        public string ClaimB { get; set; }
        public string ClaimC { get; set;}
    
    }
}
