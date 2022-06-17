using DataAccessLayer.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Generic_Repository
{
    public class Generic_Repository<TEntity> : IGeneric_Repository<TEntity> where TEntity : class
    {

        private readonly MyContext _context;

        public Generic_Repository(MyContext context)
        {
            _context = context;
        }
        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void Delete(Guid id)
        {
            var entityToDelete = GetById(id);
            if (entityToDelete is not null)
            {
                _context.Set<TEntity>().Remove(entityToDelete);
            }
        }

        public List<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public TEntity GetById(Guid id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public void Update(TEntity entity)
        {

        }


    }
}
