namespace DiamondJewelryAPI.API.Interfaces.Persistence;

public interface IRepository<TModel> : IDisposable where TModel : class
{
    Task<List<TModel>> Get();
    Task<TModel> GetById(string id);
    Task<IEnumerable<TModel>> GetAll();
    Task<TModel> Create(TModel model);
    Task<TModel> Update(string id, TModel model);
    Task Delete(string id);
}