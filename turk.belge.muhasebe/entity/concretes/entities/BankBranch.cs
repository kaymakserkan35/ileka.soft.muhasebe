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
    /// <summary>
    /// banka şubeleri
    /// </summary>
    public class BankBranch : AEntity
    {
        public BankBranch()
        {

        }
        public BankBranch(District district, City city, Country country, string completeAdress, string phone)
        {
            District = district;
            City = city;
            Country = country;
            PhoneNumber = phone;
            CompleteAdress = completeAdress;
        }



        public Bank Bank { get; set; }
        [ForeignKey(nameof(Bank))]
        virtual public int BankId { get; set; }

        public Country Country { get; set; }
        [ForeignKey(nameof(Country))]
        virtual public int CountryId { get; set; }


        public City City { get; set; }
        [ForeignKey(nameof(City))]
        virtual public int CityId { get; set; }


        public District District { get; set; }
        [ForeignKey(nameof(District))]
        virtual public int DistrictId { get; set; }



        virtual public string? CompleteAdress { get; set; }

        [Required]
        virtual public string PhoneNumber { get; set; }
    }
}
