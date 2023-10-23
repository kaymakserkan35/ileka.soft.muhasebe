using business.data.works.concrete.abstractions.interfaces;
using business.Response;

using data.access.context;
using entity.abstraction;
using entity.concretes.entities;
using manager.data.works.abstractions;
using System.Linq.Expressions;

namespace business.data.access.concrete.abstractions
{
    public abstract class AManagerFirmUsers : AManager<FirmUsers>, IManagerFirmUsers
    {
        protected AManagerFirmUsers(DatabaseContext db) : base(db)
        {
        }
    }
}
