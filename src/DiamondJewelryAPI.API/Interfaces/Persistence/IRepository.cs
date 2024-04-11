using ErrorOr;

namespace DiamondJewelryAPI.API.Interfaces.Persistence;

public interface IRepository<TModel> : IDisposable where TModel : class
{
    Task<ErrorOr<IEnumerable<TModel>>> GetAll();
    Task<ErrorOr<TModel>> GetById(string id);
    Task<ErrorOr<TModel>> Create(TModel model);
    Task<ErrorOr<TModel>> Update(string id, TModel model);
    Task Delete(string id);
}