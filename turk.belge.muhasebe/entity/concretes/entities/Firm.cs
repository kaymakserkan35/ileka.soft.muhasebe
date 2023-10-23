using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entity.abstraction;
using entity.concretes.identity;

namespace entity.concretes.entities
{
    /// <summary>
    /// modüllerimizi satın alan lar için önemli . cari ler için firma bilgisi nin hiçbir önemi yok.
    /// </summary>
    public class Firm : AEntity
    {
        [Key]
        public override int Id { get => base.Id; set => base.Id = value; }
        public override string? Name { get => base.Name; set => base.Name = value; }

        [Required] // modüllerimizi satın alanlar --> şahıs tek başına firma olabilir. yani şahıs şirketi olabilir
        virtual public bool SoleTrader { get; set; }

        #region Firma İletişim
        [Required]
        [EmailAddress]
        virtual public string EMail { get; set; }
        [Phone]
        [Required]
        virtual public string PhoneNumber { get; set; }
        #endregion

        public ICollection<Module> Modules { get; set; }
        public ICollection<Stock>? Stocks { get; set; }
        public ICollection<UserTable> Users { get; set; }
        public Firm()
        {
            Modules = new HashSet<Module>();
            Stocks = new HashSet<Stock>();
            Users = new HashSet<UserTable>();
        }
    }
}
