using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entity.abstraction;
using entity.concretes.identity;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace entity.concretes.entities
{


    public enum InvoiceStatüsEnum { gönderildi, onaylandı }


    /// <summary>
    /// faturalar çeşitlerine göre farklı alanlar içerebiliyor.. bunu nasıl yaparız daha tam bilmiyorum
    /// </summary>
    public class Invoice : AEntity
    {

        public Invoice()
        {
            Stocks =  new HashSet<Stock>();
        }

        [Key]
        public override int Id { get => base.Id; set => base.Id = value; }
        [NotMapped]
        public override string? Name { get => base.Name; set => base.Name = value; }


        [Required]
        public string InvoiceNo { get; set; }

        public InvoiceType InvoiceType { get; set; }
        [ForeignKey(nameof(InvoiceType))]
        virtual public int InvoiceTypeId { get; set; }

        public InvoiceSubType InvoiceSubType { get; set; }
        [ForeignKey(nameof(InvoiceSubType))]
        virtual public int InvoiceSubTypeId { get; set; }

        virtual public string Description { get; set; }


        public ICollection<Stock> Stocks { get; set; }



        public Contact Contact { get; set; }
        [ForeignKey(nameof(Contact))]
        virtual public int ContactId { get; set; }




        public UserTable UserTable { get; set; }
        [ForeignKey(nameof(UserTable))]
        virtual public int CreatedByUserId { get; set; }



        public Currency Currency { get; set; }
        [ForeignKey(nameof(Currency))]
        virtual public int CurrencyId { get; set; }  // alım para birimi

        public double? CurrentExchangeRate { get; set; }    //public double GuncelKur { get; set; }



        [Required]
        virtual public string DeliveryNoteNo { get; set; }  //public string IrsaliyeNo { get; set; }
        [Required]
        virtual public DateTime PaymentDate { get; set; }  // ödeme tarihi
        [Required]
        virtual public DateTime DueDate { get; set; }  // son ödeme tarihi
        [Required]
        virtual public DateTime LastUpdatedDate { get; set; }  // son ödeme tarihi



        [Required] virtual public bool PaymentStatüs { get; set; }
        [Required] virtual public bool InvoiceStatüs { get; set; }


        virtual public double Subtotal { get; set; }    // public double AraToplam { get; set; }
        virtual public double VatTotal { get; set; }    //  public double KdvToplam { get; set; }
        virtual public double GrandTotal { get; set; }   //  public double GenelToplam { get; set; }
        virtual public double TotalIncludingTax { get; set; }   //public double VergiDahilToplam { get; set; }

        virtual public double DiscountTotal { get; set; }     //public double IndirimToplam { get; set; }
        virtual public double NetAmount { get; set; }          //public double NetTutar { get; set; }
        virtual public double WithholdingTaxTotal { get; set; }      //    public double TevkifatToplam { get; set; }




    }
}
