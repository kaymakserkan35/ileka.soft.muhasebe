using business.Response;
using entity.abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace business.data.works.concrete.abstractions.interfaces
{
    public interface IManagerGeneric<TEntity> where TEntity : IEntity
    {
        abstract  Task<BusinessResult> Create(TEntity data);
        abstract Task<BusinessResult<TEntity>> ReadById(int id);
        abstract Task<BusinessResult<List<TEntity>>> ReadAllAsNoTracing(Expression<Func<TEntity, bool>> filter = null);
        abstract Task<BusinessResult<List<IEntity>>> ReadllForListing();
        abstract Task<BusinessResult> Update(TEntity entity, TEntity unchanged);
        abstract Task<BusinessResult> Update(TEntity entity);
        abstract Task<BusinessResult> Delete(int data);
    }
}
