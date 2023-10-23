using business.data.works.concrete.abstractions.interfaces;
using business.Response;
using data.access.context;
using entity.concretes.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace manager.data.works.abstractions
{
    public class AManagerModule : AManager<Module>, IManagerModule
    {
        public AManagerModule(DatabaseContext db) : base(db)
        {
        }

        public override async Task<BusinessResult> Update(Module entity)
        {
            
            return await base.Update(entity); 
        }
    }
}
