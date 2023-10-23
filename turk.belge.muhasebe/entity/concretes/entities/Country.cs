using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entity.abstraction;

namespace entity.concretes.entities
{
    [Table("Countries")]
    public class Country : AEntity
    {
        public Country()
        {
            Cities = new HashSet<City>();
        }


        public Country(string name)
        {
            Name = name;
            Cities = new HashSet<City>();
        }

        ICollection<City> Cities { get; set; }

    }
}
