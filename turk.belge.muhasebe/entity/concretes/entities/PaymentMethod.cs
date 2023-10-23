using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entity.abstraction;

namespace entity.concretes.entities
{
    public enum PaymentMethodEnum
    {
        peşin, taksit, PaymentMethod3, PaymentMethod4, PaymentMethod5,
    }
    /// <summary>
    /// ödeme şekilleri, kart peşin taksit... bunu tam kestiremiyorum..
    /// </summary>
    public class PaymentMethod : AEntity
    {

        public PaymentMethod()
        {

        }
        public PaymentMethod(string name)
        {
            Name = name;
        }

    }
}
