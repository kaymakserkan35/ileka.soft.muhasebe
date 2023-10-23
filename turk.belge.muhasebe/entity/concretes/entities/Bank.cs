using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entity.abstraction;

namespace entity.concretes.entities
{
    /// <summary>
    /// örneği halkbankası,ziraat vs... Ve bankanın dünya genelinde şubeleri bulunur.
    /// </summary>
    public class Bank : AEntity
    {



        public Bank()
        {
            BankBranches = new HashSet<BankBranch>();
        }

        public Bank(string name)
        {
            Name = name;
            BankBranches = new HashSet<BankBranch>();
        }



        /// <summary>
        /// bankanın şubeleri
        /// </summary>
        public ICollection<BankBranch> BankBranches { get; set; }

    }
}
