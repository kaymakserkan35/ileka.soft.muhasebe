using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entity.abstraction;
using entity.concretes.identity;

namespace entity.concretes.entities
{
    public class FirmUsers : AEntity
    {

        [NotMapped]
        public override int Id { get; set; }
        [NotMapped]
        public override string? Name { get; set; }


        public Firm Firm { get; set; }
        public int FirmId { get; set; }
        public UserTable UserTable { get; set; }
        public int UserTableId { get; set; }


       
    }
}
