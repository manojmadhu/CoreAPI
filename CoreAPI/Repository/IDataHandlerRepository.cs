namespace CoreAPI.Repository
{
    public interface IDataHandlerRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAll();
        TEntity GetById(int id);
        int Add(TEntity entity);
        int Delete(TEntity entity);
        int Update(TEntity targetEntity,TEntity entity);
    }
}
