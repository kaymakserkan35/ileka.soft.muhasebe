using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.Dtos.UserDtos
{
    public class UserEditingDto : UserDto
    {

        public List<int>? SelectedFirms { get; set; }
        public List<int>? SelectedRoles { get; set; }

    }
}
