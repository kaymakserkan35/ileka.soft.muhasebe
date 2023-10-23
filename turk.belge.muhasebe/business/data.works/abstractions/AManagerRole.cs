using business.data.works.concrete.abstractions.interfaces;
using business.Response;
using data.access.context;
using entity;
using entity.abstraction;
using entity.concretes.identity;
using manager.data.works.abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace business.data.works.concrete.abstractions
{
    public abstract class AManagerRole : AManager<RoleTable>, IManagerRole
    {
        protected AManagerRole(DatabaseContext db) : base(db)
        {
        }
    }
}
