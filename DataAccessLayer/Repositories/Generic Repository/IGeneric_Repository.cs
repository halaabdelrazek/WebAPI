namespace DataAccessLayer.Repositories.Generic_Repository
{
    public interface IGeneric_Repository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Delete(Guid id);
        List<TEntity> GetAll();
        TEntity GetById(Guid id);
        bool SaveChanges();
        void Update(TEntity entity);
    }
}