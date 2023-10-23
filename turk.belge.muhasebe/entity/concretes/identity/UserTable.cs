using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entity.abstraction;
using entity.concretes.entities;
using Microsoft.AspNetCore.Identity;

namespace entity.concretes.identity
{

    public class UserTable : IdentityUser<int>, IEntity
    {

        [Required]
        [StringLength(20)]
        public override string? Email { get => base.Email; set => base.Email = value; }
        public override bool EmailConfirmed { get => base.EmailConfirmed; set => base.EmailConfirmed = value; }

        public virtual string? EmailOptional { get; set; }

        [Required]
        public string Name { get; set; }
        public string? SurName { get; set; }


        [Required]
        public override string? PhoneNumber { get => base.PhoneNumber; set => base.PhoneNumber = value; }
        public override bool PhoneNumberConfirmed { get => base.PhoneNumberConfirmed; set => base.PhoneNumberConfirmed = value; }

        public virtual string? PhoneNumberOptional { get; set; }

        [NotMapped]
        public override string? UserName { get => base.UserName; set => base.UserName = value; }



        public DateTime? CreatedDate { get; set; }




        public ICollection<RoleTable> Roles { get; set; }
        public ICollection<Firm> Firms { get; set; }
        public UserTable()
        {

            Roles = new HashSet<RoleTable>();
            Firms = new HashSet<Firm>();
        }

    }
}
