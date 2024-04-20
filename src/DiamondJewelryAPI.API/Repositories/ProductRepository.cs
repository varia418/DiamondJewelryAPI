using System.Linq.Expressions;
using System.Reflection;

using DiamondJewelryAPI.API.Interfaces.Persistence;
using DiamondJewelryAPI.API.Interfaces.Persistence.Repositories;
using DiamondJewelryAPI.API.Models;
using DiamondJewelryAPI.Contracts.Products.Requests;

using ErrorOr;

using MongoDB.Driver;

using PowerUtils.Text;

namespace DiamondJewelryAPI.API.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(IMongoContext context) : base(context)
    {
    }

    public ErrorOr<IEnumerable<string>> GetAllTitles()
    {
        var query = QueryableCollection
            .Select(p => p.Title);

        var result = query.ToList();
        return result;
    }

    public async Task<ErrorOr<IEnumerable<string>>> GetProductFilterOptions(string filter)
    {
        var propertyName = nameof(Product.Details).ToLower() + "." + filter;

        var temp = await DbSet.DistinctAsync<string>(propertyName, FilterDefinition<Product>.Empty);

        return temp.ToList();
    }

    public async Task<ErrorOr<IEnumerable<Product>>> GetProductsByFilter(GetProductsRequest filters)
    {
        var parameter = Expression.Parameter(typeof(ProductDetails), "productDetails");
        PropertyInfo[] productDetailsProperties = typeof(ProductDetails).GetProperties();
        var filterBuilder = Builders<Product>.Filter;
        FilterDefinition<Product>? filter = null;

        foreach (var productDetailsProperty in productDetailsProperties)
        {
            FieldDefinition<Product, string> field = "details." + productDetailsProperty.Name.ToSnakeCase();
            string? value = (string?)filters.GetType().GetProperty(productDetailsProperty.Name).GetValue(filters);

            if (value is null || value == "Tất cả") continue;

            if (filter is null)
            {
                filter = filterBuilder.Eq(field, value);
            }
            else
            {
                filter = filter & filterBuilder.Eq(field, value);
            }

        }

        if (filters.Group is not null)
        {
            if (filter is null)
            {
                filter = filterBuilder.Eq(p => p.Group, filters.Group);
            }
            else
            {
                filter = filter & filterBuilder.Eq(p => p.Group, filters.Group);
            }
        }

        var sortBuilder = Builders<Product>.Sort;
        SortDefinition<Product>? sort = null;
        switch (filters.SortMode)
        {
            case "latest":
                sort = sortBuilder.Descending(p => p.CreatedAt);
                break;
            case "oldest":
                sort = sortBuilder.Ascending(p => p.CreatedAt);
                break;
            case "mostPopular":
                sort = sortBuilder.Descending(p => p.Sold);
                break;
            default:
                sort = null;
                break;
        }

        var result = await DbSet.FindAsync(filter ?? FilterDefinition<Product>.Empty, new FindOptions<Product, Product>() { Sort = sort });
        return result.ToList();
    }

    public ErrorOr<IEnumerable<Product>> GetProductsByTitle(string keyword)
    {
        var query = QueryableCollection
            .Where(p => p.Title.Contains(keyword));

        var result = query.ToList();
        return result;
    }
}