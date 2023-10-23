using business.Response;

using entity.concretes.entities;
using business.data.works.concrete.abstractions;
using business.data.works.concrete.abstractions.interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using business.data.access.concrete.abstractions;
using data.access.context;

namespace business.data.access.concrete.services
{
    internal class ManagFirm : AManagerFirm, IManagerFirm
    {
        public ManagFirm(DatabaseContext db) : base(db)
        {
        }
    }
}
