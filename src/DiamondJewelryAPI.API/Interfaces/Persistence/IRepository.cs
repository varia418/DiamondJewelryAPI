namespace DiamondJewelryAPI.API.Interfaces.Persistence;

public interface IRepository<TModel> : IDisposable where TModel : class
{
    Task<IEnumerable<TModel>> GetAll();
    Task<TModel> GetById(string id);
    Task<TModel> Create(TModel model);
    Task<TModel> Update(string id, TModel model);
    Task Delete(string id);
}