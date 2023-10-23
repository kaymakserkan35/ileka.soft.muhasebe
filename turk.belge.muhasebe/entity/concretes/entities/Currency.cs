using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entity.abstraction;

namespace entity.concretes.entities
{
    public enum CurrencyEnum
    {
        Türk_Lirasi, ABD_Doları,Euro,İngiliz_Sterlini
    }
    public class Currency : AEntity
    {
        public Currency()
        {

        }
        public Currency(string name)
        {
            Name = name;
        }

    }
}
