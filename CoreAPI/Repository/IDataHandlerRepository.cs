namespace CoreAPI.Repository
{
    public interface IDataHandlerRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAll();
        TEntity GetById(int id);
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity targetEntity,TEntity entity);
    }
}
