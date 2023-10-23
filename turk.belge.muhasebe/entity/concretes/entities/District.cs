using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entity.abstraction;

namespace entity.concretes.entities
{
    public class District : AEntity// ilçe
    {
        public District()
        {

        }

        public District(string name)
        {
            Name = name;
        }
        public District(string name, City city)
        {
            City = city;
            Name = name;
        }


        public City City { get; set; }
        virtual public int CityId { get; set; }


        virtual public string? PostalCode { get; set; } // harf olabiliyor
    }
}
