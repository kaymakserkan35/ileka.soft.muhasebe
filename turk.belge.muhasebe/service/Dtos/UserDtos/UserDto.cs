using entity;
using entity.concretes.identity;
using service.Dtos.ListingDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.Dtos.UserDtos
{
    public class UserBasicDto : ADto
    {
        public virtual string SurName { get; set; } = "";
        public virtual string Email { get; set; } = "";
        public virtual string PhoneNumber { get; set; } = "";


        public virtual bool EmailConfirmed { get; set; } = false;
        public virtual bool PhoneNumberConfirmed { get; set; } = false;
        public virtual DateTime? CreatedDate { get; set; }

    }

    public class UserDto : UserBasicDto
    {
        public virtual string? PhoneNumberOptional { get; set; }
        public virtual string? EmailOptional { get; set; }

        public virtual List<FirmListing_BasicDto> Firms { get; set; }
        public virtual List<RoleListing_basicDto> Roles { get; set; }

    }
}
