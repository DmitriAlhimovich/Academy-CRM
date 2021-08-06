using System.Collections.Generic;
using AcademyCRM.BLL.Models;

namespace AcademyCRM.BLL.Services
{
    public interface IEntityService<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
    }
}