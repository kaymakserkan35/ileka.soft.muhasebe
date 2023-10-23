using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entity.abstraction;

namespace entity.concretes.entities
{
    /// <summary>
    /// sahıs firması ve ya kurumsal firma vs.. bizim hangi modüllerimizi satın almış??
    /// buradan( yani firmadan) -->  bu firmada çalışan user lara, claims ler (modül hakları) vericeğiz. 
    /// firma da user larına roller (modülün hangi alt modüllerinne erişim sağlıyabileceği gibi, kvkk kuralları dahilinde) dağıtacak.
    /// bu şekilde rol ve claim lere göre apilerimizi açıcağız ve ya kapayacağız bu userlara..
    /// </summary>
    public class FirmHasModule : AEntity
    {

        [NotMapped]
        public override int Id { get => base.Id; set => base.Id = value; }
        [NotMapped]
        public override string? Name { get => base.Name; set => base.Name = value; }

        public Firm Firm { get; set; }
        virtual public int FirmId { get; set; }

        public Module Module { get; set; }
        virtual public int ModuleId { get; set; }

    }
}
