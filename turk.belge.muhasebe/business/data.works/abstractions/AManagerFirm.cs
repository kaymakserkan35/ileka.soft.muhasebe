using business.data.works.concrete.abstractions.interfaces;
using business.Response;

using data.access.context;
using entity.abstraction;
using entity.concretes.entities;
using manager.data.works.abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static entity.concretes.identity.RoleTable;

namespace business.data.access.concrete.abstractions
{
    public abstract class AManagerFirm : AManager<Firm>, IManagerFirm
    {
        protected AManagerFirm(DatabaseContext db) : base(db)
        {
        }

        public async Task<BusinessResult<List<Firm>>> readFirmsWithModules()
        {
            var res = await db.Firms.Include(firm => firm.Modules).ToListAsync();
            return BusinessResult<List<Firm>>.Success(res);
        }

        public async Task<BusinessResult<Firm>> readFirmWithModules(int id)
        {
            var res = await db.Firms.Include(x => x.Modules).FirstOrDefaultAsync(x => x.Id.Equals(id));
            return BusinessResult<Firm>.Success(res);
        }

        public override async Task<BusinessResult> Update(Firm entity)
        {
            if (entity.Modules == null) { return await base.Update(entity); }
            var firm = db.Firms.Include(x => x.Modules).First(x => x.Id.Equals(entity.Id));

            firm.Name = entity.Name;
            firm.SoleTrader = entity.SoleTrader;
            firm.EMail = entity.EMail;
            firm.PhoneNumber = entity.PhoneNumber;

            firm.Modules.Clear();
            var selectedModules = entity.Modules.Select(x => x.Id);
            firm.Modules = db.Modules.Where(x => selectedModules.Contains(x.Id)).ToArray();
            await db.SaveChangesAsync();

            return BusinessResult.Success();

        }

        public override async Task<BusinessResult> Delete(int id)
        {
            return await base.Delete(id);
        }

        public Task<BusinessResult<List<Firm>>> readFirmsWithModulesAndOwner()
        {
            var res = db.Firms
               .Include(x => x.Modules)
              .Include(x => x.Users.Where(x => x.Roles.Any(x => x.Name.Equals(RolesEnum.CUSTOMER.ToString())))).ToList();

            return Task.FromResult(BusinessResult<List<Firm>>.Success(res));

        }
    }
}
