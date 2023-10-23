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
    public class UserToken : IdentityUserToken<int>,IEntity
    {

        [NotMapped]
        public int Id { get; set; }


        public string? jwt { get; set; }
        public DateTime? jwtExpiredAt { get; set; }
        public string? refreshToken { get; set; }
        public DateTime? refreshTokenExpiredAt { get; set; }
    }
}
