using business.data.works.concrete.abstractions.interfaces;
using business.Response;
using data.access.context;
using entity.concretes.entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace manager.data.works.abstractions.ManagerRar
{
    public abstract class AManagerDistrict : AManager<District>, IManagerDistrict
    {
        protected AManagerDistrict(DatabaseContext db) : base(db)
        {
        }

        public override Task<BusinessResult<List<District>>> ReadAllAsNoTracing(Expression<Func<District, bool>> filter = null)
        {
            return base.ReadAllAsNoTracing(filter);
        }

        public async Task<BusinessResult<List<District>>> readDistrictsWİthCityAndCountry()
        {
            var res = await db.Districts.Include(x => x.City).ThenInclude(x => x.Country).ToListAsync();
            return BusinessResult<List<District>>.Success(res);
        }
    }
    public abstract class AManagerCity : AManager<City>, IManagerCity
    {
        protected AManagerCity(DatabaseContext db) : base(db)
        {
        }

    }
    public abstract class AManagerCountry : AManager<Country>, IManagerCountry
    {
        protected AManagerCountry(DatabaseContext db) : base(db)
        {
        }
    }
    public abstract class AManagerBankBranch : AManager<BankBranch>, IManagerBankBranch
    {
        protected AManagerBankBranch(DatabaseContext db) : base(db)
        {
        }
    }

}
