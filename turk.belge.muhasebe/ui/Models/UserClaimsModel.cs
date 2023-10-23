using static entity.concretes.identity.RoleTable;

namespace ui.Models
{
    public class UserClaimsModel
    {


        public int UserId { get; set; }
        public string UserEmail { get; set; }
        public string ClaimA { get; set; }
        public string ClaimB { get; set; }
        public string ClaimC { get; set; }
    }
}
