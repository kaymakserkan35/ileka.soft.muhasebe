using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.Dtos.ListingDtos
{
    public class StockListing_basicDto : ADto
    {
        public bool IsSelected { get; set; } = false;
    }
}
