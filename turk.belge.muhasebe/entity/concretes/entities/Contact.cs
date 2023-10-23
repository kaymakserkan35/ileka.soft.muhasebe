using entity.abstraction;
using entity.concretes.identity;
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
    /// <summary>
    ///  modülümüzü satın alan şahıs ve/veya firmanın faturalarını kestiği şahıs ve/veya firma , cari kişisidir.
    /// </summary>
    public class Contact : AEntity
    {//"Cariler" veya "Contacts" adında bir tablo ekleyin.
        #region Temel Cari Bilgileri

        [Key]
        public override int Id { get => base.Id; set => base.Id = value; }
        public override string? Name { get => base.Name; set => base.Name = value; }
        virtual public string? SurName { get; set; }

        virtual public string CompanyName { get; set; }

        [Required]
        virtual public int TCN { get; set; }
        [Required]
        virtual public int TaxIdentificationNumber { get; set; }   // vergi numarası
        [Required]
        virtual public string PhoneNumber { get; set; }
      
        virtual public string? Email { get; set; }

        virtual public string? Notes { get; set; }


        public Contact()
        {
            BankAccounts = new HashSet<BankAccount>();
        }
        ICollection<BankAccount> BankAccounts { get; set; }


        /// <summary>
        /// modüllerimizi satın alan müşteriler , cari lerini bir grup altında görmek ,  işlem yapmak için istemiş....
        /// </summary>
        public CariGroup CariGroup { get; set; }
        [ForeignKey(nameof(CariGroup))]
        virtual public int CariGroupId { get; set; }


        //giris yapan  user.
        public UserTable UserTable { get; set; }
        [ForeignKey(nameof(UserTable))]
        virtual public int CreatedByUserId { get; set; }

        // giris yapan illaki bir firmaya sahip ya sahis firması  ya da birden cok çalışanı bulunan diğerleri...
        public Firm Firm { get; set; }
        [ForeignKey(nameof(Firm))]
        virtual public int? CreatorFirmId { get; set; }



        public TaxOffice TaxOffice { get; set; } // vergi dairesi
        [ForeignKey(nameof(TaxOffice))]
        virtual public int TaxOfficeId { get; set; }



     


      
        #endregion

        #region temel iletişim

        public Country Country { get; set; }
        [ForeignKey(nameof(Country))]
        virtual public int CountryId { get; set; }

        public City City { get; set; }
        [ForeignKey(nameof(City))]
        virtual public int CityId { get; set; } // il id si

        public District District { get; set; }
        [ForeignKey(nameof(District))]
        virtual public int DistrictId { get; set; }  // ilçe idsi

        virtual public string? PostalCode { get; set; }  // posta kodu

        virtual public string CompleteAdress { get; set; } // açık adress

        [Required]
        virtual public string? WebSite { get; set; } // web site

     
        #endregion


        #region Olusturan için..

       

        // utc zamanına (ingiltere) göre tutulacak
        [Required]
        virtual public DateTime CreatedDate { get; set; }

        // carinin durumu nedir. hala bizim ile iş yapmakta mı yoksa yapmamak tamı
        [Required]
        virtual public bool Status { get; set; }
        #endregion




    }
}
