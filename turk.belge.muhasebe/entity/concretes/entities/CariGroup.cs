using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entity.abstraction;

namespace entity.concretes.entities
{

    public enum CariGroupEnum
    {
        Taşra_Müşterisi, Kurumsal_Müşteri , Tedarikçi
    }
    /// <summary>
    /// müşteri istemiş ...
    /// </summary>
    public class CariGroup : AEntity
    {

        public CariGroup()
        {

        }
        public CariGroup(string name)
        {
            Name = name;
        }

    }
}
