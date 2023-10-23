using business.Response;
using entity.concretes.identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace manager.data.works.logics
{
    public interface ILogic<TEntity>
    {
        List<ABusinessError>? analyse(TEntity entity);
    }
    public interface IUserLogic : ILogic<UserTable>
    {
    }
}
