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
    public class TaxOffice : AEntity
    {
        public TaxOffice()
        { }

        public TaxOffice(string Name, Country Country, City City, District District)
        {

        }

        [Required]
        virtual public string Code { get; set; }


        public Country Country { get; set; }
        [ForeignKey(nameof(Country))]
        virtual public int CountryId { get; set; }


        public City City { get; set; }
        [ForeignKey(nameof(City))]
        virtual public int CityId { get; set; }


        public District District { get; set; }
        [ForeignKey(nameof(District))]
        virtual public int DistrictId { get; set; }

        virtual public string CompleteAdress { get; set; }

    }
}
