using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entity.abstraction;

namespace entity.concretes.entities
{

    public enum InvoiceTypeEnum { alım, satım, iade, taslak }

    public class InvoiceType : AEntity
    {
    }
}
