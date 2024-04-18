using DiamondJewelryAPI.API.Models.Common;
using DiamondJewelryAPI.Contracts.Common;

using Mapster;

namespace DiamondJewelryAPI.API.Common.Mapping;

public class CartMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CartItemData, CartItem>()
            .Map(dest => dest.ProductId, src => src.Id);

        config.NewConfig<CartItem, CartItemData>()
            .Map(dest => dest.Id, src => src.ProductId);

        config.NewConfig<CartItemDetails, CartItemDetailsData>()
            .Map(dest => dest, src => src.Product);
    }
}