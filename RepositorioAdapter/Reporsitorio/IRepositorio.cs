using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RepositorioAdapter.Reporsitorio
{
    public interface IRepositorio<TEntity,TModel,TAdapter>
    {
        TModel Add(TModel model);
        int Delete(params object[] keys);
        int Delete(TModel model);
        int Delete(Expression<Func<TEntity, bool>> consulta);
        int Update(TModel model);
        TModel Get(params object[] keys);

        ICollection<TModel> Get(Expression<Func<TEntity, bool>> consulta);
        ICollection<TModel> Get();
    }
}