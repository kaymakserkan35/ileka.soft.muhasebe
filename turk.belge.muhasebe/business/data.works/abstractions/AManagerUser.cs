using business.data.works.concrete.abstractions.interfaces;
using business.Response;
using data.access.context;
using entity.abstraction;
using entity.concretes.entities;
using entity.concretes.identity;
using manager.data.works.abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace business.data.access.concrete.abstractions
{
    public abstract class AManagerUser : AManager<UserTable>, IManagerUser
    {
        protected AManagerUser(DatabaseContext db) : base(db)
        {
        }


        public override async Task<BusinessResult> Create(UserTable entity)
        {
            if (entity.Roles == null && entity.Firms == null) { return await base.Create(entity); };
            if (entity.Roles != null)
            {
                var selectedRoles = entity.Roles.Select(x => x.Id).ToList();
                entity.Roles = db.Roles.Where(x => selectedRoles.Contains(x.Id)).ToList();

                // veri sorgusu yapmadan doğrudan kayıt edeyim demistim ama olmadı.
                //  foreach (var role in selectedRoles)    {   db.UserRoles.Add(new UserHasRole { RoleId = role,  UserTable=entity });   }
            }
            if (entity.Firms != null)
            {
                var selecetedFİrms = entity.Firms.Select(x => x.Id).ToList();
                entity.Firms = db.Firms.Where(x => selecetedFİrms.Contains(x.Id)).ToList();
                // foreach (var firm in selecetedFİrms)  { db.FirmHasUsers.Add(new FirmUsers { FirmId = firm, UserTable=entity }); }
            }


            entity.SecurityStamp = Guid.NewGuid().ToString();
            entity.ConcurrencyStamp = Guid.NewGuid().ToString();
            db.Users.Add(entity);

            await db.SaveChangesAsync();
            return BusinessResult.Success();

        }

        async public override Task<BusinessResult> Update(UserTable entity)
        {


            if (entity.Roles == null && entity.Firms == null) { return await base.Update(entity); };

            var existingUser = await db.Users
               .Include(u => u.Roles).Include(x => x.Firms)
               .FirstOrDefaultAsync(u => u.Id == entity.Id);


            existingUser.Name = entity.Name;
            existingUser.SurName = entity.SurName;
            existingUser.Email = entity.Email;
            existingUser.EmailConfirmed = entity.EmailConfirmed;
           


            if (entity.Roles != null)
            {
                var selectedRoles = entity.Roles.Select(x => x.Id).ToList();
                existingUser.Roles.Clear();
                existingUser.Roles = db.Roles.Where(x => selectedRoles.Contains(x.Id)).ToList();

                // veri sorgusu yapmadan doğrudan kayıt edeyim demistim ama olmadı.
                //  foreach (var role in selectedRoles)    {   db.UserRoles.Add(new UserHasRole { RoleId = role,  UserTable=entity });   }
            }
            if (entity.Firms != null)
            {
                var selecetedFİrms = entity.Firms.Select(x => x.Id).ToList();
                existingUser.Firms.Clear();
                existingUser.Firms = db.Firms.Where(x => selecetedFİrms.Contains(x.Id)).ToList();
                // foreach (var firm in selecetedFİrms)  { db.FirmHasUsers.Add(new FirmUsers { FirmId = firm, UserTable=entity }); }
            }


            existingUser.SecurityStamp = Guid.NewGuid().ToString();
            existingUser.ConcurrencyStamp = Guid.NewGuid().ToString();
            db.Users.Update(existingUser);

            await db.SaveChangesAsync();
            return BusinessResult.Success();
        }




        virtual async public Task<BusinessResult<List<UserTable>>> readUsersWithFirmsAndRoles_forListing()
        {
            var users = await db.Users
                .Include(x => x.Firms).Include(x => x.Roles)
                .Select(x => new UserTable
                {
                    Id = x.Id,
                    Name = x.Name,
                    SurName = x.SurName,
                    CreatedDate = x.CreatedDate,
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                    Firms = x.Firms.Select(f => new Firm { Id = f.Id, Name = f.Name }).ToList(),
                    Roles = x.Roles.Select(r => new RoleTable { Id = r.Id, Name = r.Name }).ToList(),

                }).ToListAsync();
            return BusinessResult<List<UserTable>>.Success(users);
        }

        virtual async public Task<BusinessResult<List<UserTable>>> readUsersWithFirms_forListing()
        {
            throw new NotImplementedException();
        }

        virtual async public Task<BusinessResult<UserTable>> readUserWithFirmsAndRoles(int id)
        {
            var user = await db.Users
              .Include(x => x.Firms).Include(x => x.Roles)

              .Select(x => new UserTable
              {
                  Id = x.Id,
                  Name = x.Name,
                  SurName = x.SurName,
                  CreatedDate = x.CreatedDate,
                  Email = x.Email,
                  PhoneNumber = x.PhoneNumber,
                  Firms = x.Firms.Select(f => new Firm { Id = f.Id, Name = f.Name }).ToList(),
                  Roles = x.Roles.Select(r => new RoleTable { Id = r.Id, Name = r.Name }).ToList(),

              }).FirstOrDefaultAsync(x => x.Id.Equals(id));
            return BusinessResult<UserTable>.Success(user);
        }
    }


}

