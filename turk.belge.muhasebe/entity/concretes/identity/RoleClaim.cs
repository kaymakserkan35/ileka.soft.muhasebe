using entity.abstraction;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity.concretes.identity
{
    public class RoleClaim : IdentityRoleClaim<int>, IEntity
    {
        [NotMapped]
        public string? Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
