using DiamondJewelryAPI.API.Models;
using DiamondJewelryAPI.Contracts.Common;

using Mapster;

namespace DiamondJewelryAPI.API.Common.Mapping;

public class UserMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<User, UserData>()
            .Map(dest => dest.DOB, src => src.DateOfBirth)
            .Map(dest => dest.Tel, src => src.PhoneNumber);
    }
}