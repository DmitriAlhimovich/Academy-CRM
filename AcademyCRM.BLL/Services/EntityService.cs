using System.Collections.Generic;
using AcademyCRM.DAL;

namespace AcademyCRM.BLL.Services
{
    public class EntityService<TEntity> : IEntityService<TEntity> where TEntity : class
    {
        private readonly IRepository<TEntity> _repository;

        public EntityService(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public TEntity GetById(int id)
        {
            return _repository.Get(id);
        }

        public void Create(TEntity course)
        {
            _repository.Create(course);
        }

        public void Update(TEntity course)
        {
            _repository.Update(course);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}