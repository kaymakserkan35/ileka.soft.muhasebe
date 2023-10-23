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
    public class Vault : AEntity
    {
        [ForeignKey(nameof(UserTable))]
        // şu firma çalışanı trafından oluşturuldu
        virtual public int CreatedByUserId { get; set; }

        [ForeignKey(nameof(Firm))]
        virtual public int FirmId { get; set; }

        [Required]
        virtual public string Code { get; set; }

        [Required]
        virtual public string Description { get; set; }

        [Required]
        virtual public double StartingMoney { get; set; }
        [Required]
        [ForeignKey(nameof(Currency))]
        virtual public int CurrencyId { get; set; }

        virtual public DateTime CreatedDate { get; set; }

    }
}
