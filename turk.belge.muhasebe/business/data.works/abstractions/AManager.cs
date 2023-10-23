using business.data.works.concrete.abstractions.interfaces;
using business.Response;
using data.access.context;
using entity.abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace manager.data.works.abstractions
{
    public abstract class AManager<TEntity> : IManagerGeneric<TEntity> where TEntity : class, IEntity
    {

        protected DatabaseContext db;
        public AManager(DatabaseContext db)
        {
            this.db = db;
        }

        virtual async public Task<BusinessResult> Create(TEntity entity)
        {
            try
            {
                await db.Set<TEntity>().AddAsync(entity);
                db.SaveChangesAsync();
                return BusinessResult.Success();
            }
            catch (Exception e)
            { return BusinessResult.Fail(new DataAccessError(e.Message)); }

        }

        virtual public async Task<BusinessResult> Delete(int id)
        {
            try
            {
                var entity = db.Set<TEntity>();
                var data = await entity.FindAsync(id);
                if (data == null) throw new Exception("bu id de bir veri bulunamadı");
                entity.Remove(data);
                var t = await db.SaveChangesAsync();
                return BusinessResult.Success();
            }
            catch (Exception e)
            { return BusinessResult.Fail(new DataAccessError(e.Message)); }
        }

        virtual async public Task<BusinessResult<List<TEntity>>> ReadAllAsNoTracing(Expression<Func<TEntity, bool>> filter = null)
        {
            try
            {
                IQueryable<TEntity> query = db.Set<TEntity>().AsNoTracking();

                if (filter != null)
                {
                    query = query.Where(filter);
                }
                var res = await query.ToListAsync();
                return BusinessResult<List<TEntity>>.Success(res);
            }
            catch (Exception e)
            {
                { return BusinessResult<List<TEntity>>.Fail(new DataAccessError(e.Message)); }
            }
        }

        virtual async public Task<BusinessResult<TEntity>> ReadById(int id)
        {
            try
            {
                var entity = await db.Set<TEntity>().FindAsync(id);
                if (entity == null) throw new Exception("bu id de bir entity bulunamadı");
                return BusinessResult<TEntity>.Success(entity);
            }
            catch (Exception e) { return BusinessResult<TEntity>.Fail(new DataAccessError(e.Message)); }
        }

        public async Task<BusinessResult<List<IEntity>>> ReadllForListing()
        {
            try
            {
                var res = await db.Set<TEntity>().Select(x => (IEntity)x).ToListAsync();
                return BusinessResult<List<IEntity>>.Success(res);
            }
            catch (Exception e) { return BusinessResult<List<IEntity>>.Fail(new DataAccessError(e.Message)); }



        }


        virtual public async Task<BusinessResult> Update(TEntity entity, TEntity unchanged)
        {
            try
            {
                db.Entry(unchanged).CurrentValues.SetValues(entity);
                db.SaveChangesAsync();
                return BusinessResult.Success();
            }
            catch (Exception e) { return BusinessResult.Fail(new DataAccessError(e.Message)); }


        }

        virtual async public Task<BusinessResult> Update(TEntity entity)
        {
            try
            {
                db.Entry(entity).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return BusinessResult.Success();
            }
            catch (Exception e)
            { return BusinessResult.Fail(new DataAccessError(e.Message)); }

        }
    }
}
