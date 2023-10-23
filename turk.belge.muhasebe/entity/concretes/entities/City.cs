using entity.abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity.concretes.entities
{

    public class City : AEntity // il
    {

        public City()
        {
            Districts = new HashSet<District>();
        }

        public City(string name, Country country)
        {
            Name = name;
            Country = country;
        }
        public City(string cityName, int CountryId)
        {
            Name = cityName;
            this.CountryId = CountryId;
        }





        public Country Country { get; set; }
        [ForeignKey(nameof(Country))]
        virtual public int CountryId { get; set; }

        ICollection<District> Districts { get; set; }
    }
}
