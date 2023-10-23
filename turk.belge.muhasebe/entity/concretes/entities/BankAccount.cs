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
    public class BankAccount : AEntity
    {
        [Key]
        public override int Id { get => base.Id; set => base.Id = value; }

        [NotMapped]
        public override string? Name { get => base.Name ; set => base.Name = value; }

        virtual public string AccountNo { get; set; }
        virtual public string Iban { get; set; }


        public Currency Currency { get; set; }
        [ForeignKey(nameof(Currency))]
        virtual public int CurrencyId { get; set; }


        public BankAccountType BankAccountType { get; set; }
        [ForeignKey(nameof(BankAccountType))]
        virtual public int BankAccountTypeId { get; set; }


        public BankBranch BankBranch { get; set; }
        [ForeignKey(nameof(BankBranch))]
        virtual public int BankBranchId { get; }

        #region hesap kimin 

        public Firm Firm { get; set; }
        [ForeignKey(nameof(Firm))]
        virtual public int FirmId { get; set; }
        #endregion




    }
}
