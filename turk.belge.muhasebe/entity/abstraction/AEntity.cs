using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity.abstraction
{
    public abstract class AEntity : IEntity
    {
       
        virtual public int Id { get; set; }
        virtual public string? Name { get; set; }
    }
}
