using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity.abstraction
{
    public interface IEntity
    {
        [Key]
        abstract public int Id { get; set; }
        abstract public string Name { get; set; }
    }
}
