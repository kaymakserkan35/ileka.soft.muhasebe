using entity.concretes.entities;
using entity.concretes.identity;
using service.Dtos.ListingDtos;
using service.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.Dtos.FirmDto
{
    public class FirmEditingDto : ADto
    {



        public List<ModuleListing_basicDto> Modulles { get; set; }
        public List<int> SelectedModules { get; set; }


        public bool SoleTrader { get; set; }
        public string EMail { get; set; }
        public string PhoneNumber { get; set; }


        public ICollection<UserDto> Users { get; set; }


    }
}
