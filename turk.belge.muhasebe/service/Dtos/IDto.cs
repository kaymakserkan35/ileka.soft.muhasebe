using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.Dtos
{
    public interface IDto
    {
    }

    public abstract class ADto : IDto
    {
        public virtual string Name { get; set; }
        public virtual int Id { get; set; }
    }
}
