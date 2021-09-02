using System.Collections.Generic;
using System.Threading.Tasks;
using AcademyCRM.BLL.Models;

namespace AcademyCRM.BLL.Services
{
    public interface IEntityService<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync();

        TEntity GetById(int id);

        void Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(int id);
    }
}