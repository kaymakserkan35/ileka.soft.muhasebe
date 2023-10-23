using business.Response;

using entity.concretes.identity;
using business.data.works.concrete.abstractions;
using business.data.works.concrete.abstractions.interfaces;
using manager.data.works.logics;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using business.data.access.concrete.abstractions;
using data.access.context;
using System.Linq.Expressions;

namespace business.data.access.concrete.services
{
    internal class ManagUser : AManagerUser, IManagerUser
    {

        public ManagUser(DatabaseContext db) : base(db)
        {
        }

        public override Task<BusinessResult<List<UserTable>>> ReadAllAsNoTracing(Expression<Func<UserTable, bool>> filter = null)
        {
            return base.ReadAllAsNoTracing(filter);
        }

        public override Task<BusinessResult> Create(UserTable entity)
        {
            var res = new UserLogic().analyse(entity);
            if (res != null) return Task.FromResult(BusinessResult.Fail(res.ToArray()));
            return base.Create(entity);
        }

        public override Task<BusinessResult> Update(UserTable entity)
        {
            
            return base.Update(entity); 
        }
    }
}
