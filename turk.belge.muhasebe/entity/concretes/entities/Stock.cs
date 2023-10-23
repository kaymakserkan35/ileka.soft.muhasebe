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



    /// <summary>
    /// modülümüzü satın alan şahıs ve veya kurumsal firmanın, mesela kalem stoğu, silgi stoğu...
    /// </summary>
    public class Stock : AEntity
    {
        public Stock()
        {
            Invoices = new HashSet<Invoice>();
        }
        [Key]  //Her ürünün benzersiz bir kimliği olmalıdır.  ProductId...
        public override int Id { get => base.Id; set => base.Id = value; }

        [Required]
        virtual public string ProductBarcodeNo { get; set; }

        [Required]
        public override string? Name { get => base.Name; set => base.Name = value; }


    

        virtual public string? Description { get; set; }
        virtual public string? SpecialNotes { get; set; }

        virtual public string? ProductImageUrl { get; set; }

        //Ürünün ait olduğu kategori
        public StockCategory StockCategory { get; set; }
        virtual public int? StockCategoryId { get; set; }

        [Required] // Stokta bulunan ürün miktarı.
        virtual public int Quantity { get; set; }

        public UnitsOfMeasurement UnitsOfMeasurement { get; set; }
        virtual public int? UnitsOfMeasurementId { get; set; }

        public ICollection<Invoice> Invoices { get; set; }



        #region stok u kim olusturuyo
        // stoku olusturan user
        public UserTable UserTable { get; set; }
        virtual public int UserId { get; set; }
        // user ın çalıştığı firma
        public Firm Firm { get; set; }
        virtual public int FirmId { get; set; }
        #endregion



        public DateTime LastUpdatedDate { get; set; }

        [Required] // alım birim fiyatı
        virtual public double UnitCost { get; set; }

        [Required] //alım birim  kdv si
        virtual public double CostKDV { get; set; }

        [Required] // satım birim fiyatı
        virtual public double SellingUnitPrice { get; set; }

        [Required] // satım birim kdv si
        virtual public double SellingKDV { get; set; }

        // stok şu kadarın altına düştüğünde bilgilendir.
        virtual public int MinimumStockLevel { get; set; }




    }
}
