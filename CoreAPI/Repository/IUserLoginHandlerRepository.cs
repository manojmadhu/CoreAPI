using CoreAPI.Model;

namespace CoreAPI.Repository
{
    public interface IUserLoginHandlerRepository<TEntity>
    {
        int Add(TEntity entity);
        TEntity GetUserDetail(TEntity entity);
        Token GetToken(TEntity entity, IConfiguration configuration);
    }
}
