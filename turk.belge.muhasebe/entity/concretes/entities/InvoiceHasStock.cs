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
    /// fatura stok u nasıl etkiledi. bu junk sınıfına ihtiyaç var mı bilemedim. ama  önceki veritabanında bu var dı.
    /// </summary>
    public class InvoiceHasStock : AEntity
    {
        [NotMapped]
        public override string? Name { get => base.Name; set => base.Name = value; }
        [NotMapped]
        public override int Id { get => base.Id; set => base.Id = value; }


        virtual public Stock Stock { get; set; }
        virtual public int StockId { get; set; }


        virtual public Invoice Invoice { get; set; }
        virtual public int InvoiceId { get; set; }







    }
}
