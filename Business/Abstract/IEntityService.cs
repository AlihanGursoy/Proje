using Core.Entities.Abstract;
using Core.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IEntityService<T> where T : class, IEntity, new()
    {
        IDataResult<List<T>> GetAll();
        IResult Add(T entity);
        IDataResult<T> Delete(int id);
        IDataResult<T> Update(T entity);
        IDataResult<T> GetById(int id);
    }
}
