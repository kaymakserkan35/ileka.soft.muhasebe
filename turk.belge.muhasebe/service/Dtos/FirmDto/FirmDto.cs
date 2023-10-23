using entity.concretes.entities;
using entity.concretes.identity;
using service.Dtos.ListingDtos;
using service.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.Dtos.FirmDto
{

    public class FirmBasicDto : ADto
    {
        public bool SoleTrader { get; set; }
        public string EMail { get; set; }
        public string PhoneNumber { get; set; }

    }


    public class FirmDto : FirmBasicDto
    {
        public List<UserDto> Users { get; set; }
        public List<ModuleListing_basicDto> Modules { get; set; }
    }
}
