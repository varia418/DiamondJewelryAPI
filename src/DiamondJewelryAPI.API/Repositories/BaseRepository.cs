using DiamondJewelryAPI.API.Interfaces.Persistence;

using ErrorOr;

using MongoDB.Driver;

namespace DiamondJewelryAPI.API.Repositories;

public abstract class BaseRepository<TModel> : IRepository<TModel> where TModel : class
{
    protected readonly IMongoDatabase Database;
    protected readonly IMongoCollection<TModel> DbSet;
    protected readonly IQueryable<TModel> QueryableCollection;

    protected BaseRepository(IMongoContext context)
    {
        Database = context.Database;
        DbSet = Database.GetCollection<TModel>(typeof(TModel).Name.ToLower() + "s");
        QueryableCollection = DbSet.AsQueryable();
    }

    public virtual async Task<ErrorOr<IEnumerable<TModel>>> GetAll()
    {
        var all = await DbSet.FindAsync(Builders<TModel>.Filter.Empty);
        return all.ToList();
    }

    public virtual async Task<ErrorOr<TModel>> GetById(string id)
    {
        var data = await DbSet.Find(FilterId(id)).SingleOrDefaultAsync();
        return data;
    }

    public virtual async Task<ErrorOr<TModel>> Create(TModel model)
    {
        await DbSet.InsertOneAsync(model);
        return model;
    }

    public async virtual Task<ErrorOr<TModel>> Update(string id, TModel obj)
    {
        await DbSet.ReplaceOneAsync(FilterId(id), obj);
        return obj;
    }

    public async virtual Task Delete(string id)
    {
        await DbSet.DeleteOneAsync(FilterId(id));
    }

    private static FilterDefinition<TModel> FilterId(string key)
    {
        return Builders<TModel>.Filter.Eq("Id", key);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
