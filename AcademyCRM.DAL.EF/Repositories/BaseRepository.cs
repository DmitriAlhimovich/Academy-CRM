﻿using AcademyCRM.DAL.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AcademyCRM.DAL.EF.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly AcademyContext _context;
        private readonly DbSet<TEntity> _entities;


        public BaseRepository(AcademyContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }

        public void Create(TEntity item)
        {
            _context.Entry(item).State = EntityState.Added;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _entities.Find(id);
            if (entity != null)
                _entities.Remove(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public IEnumerable<TEntity> Find(Func<TEntity, bool> predicate)
        {
            return _entities.AsEnumerable().Where(predicate).ToList();
        }

        public TEntity Get(int id) => _entities.Find(id);

        public virtual IEnumerable<TEntity> GetAll()
        {
            return GetAllAsync().Result;
        }

        public void Update(TEntity item)
        {
            //_context.Entry(item).State = EntityState.Modified;
            var existingItem = _context.Find(typeof(TEntity), typeof(TEntity).GetProperty("Id")?.GetValue(item));
            _context.Entry(existingItem).CurrentValues.SetValues(item);
            _context.SaveChanges();
        }
    }
}
