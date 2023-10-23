using business.Response;
using entity.abstraction;
using entity.concretes.identity;
using business.data.works.concrete.abstractions;
using business.data.works.concrete.abstractions.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using data.access.context;

namespace business.data.works.concrete.managers
{
    internal class ManagRole : AManagerRole, IManagerRole
    {
        public ManagRole(DatabaseContext db) : base(db)
        {
        }
    }
}
