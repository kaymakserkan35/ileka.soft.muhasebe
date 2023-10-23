using entity.concretes.entities;
using entity.concretes.identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.Dtos.ListingDtos
{
    public class FirmListing_BasicDto : ADto
    {
        public bool IsSelected { get; set; } = false;

    }

}
