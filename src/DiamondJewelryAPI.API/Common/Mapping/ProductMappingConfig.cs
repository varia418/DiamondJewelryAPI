using DiamondJewelryAPI.API.Models;
using DiamondJewelryAPI.Contracts.Common;

using Mapster;

namespace DiamondJewelryAPI.API.Common.Mapping;

public class ProductMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // config.NewConfig<ProductData, Product>()
        //     .Map(dest => dest.CreatedAt, src => DateTime.Now);

        // config.NewConfig<Product, ProductData>()
        //     .Map(dest => dest.CreatedAt, src => src.CreatedAt.ToString());
    }
}