using DiamondJewelryAPI.API.Models;
using DiamondJewelryAPI.Contracts.Common;

using Mapster;

namespace DiamondJewelryAPI.API.Common.Mapping;

public class ContactMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Contact, ContactData>()
            .Map(dest => dest.SenderName, src => src.Name)
            .Map(dest => dest.SenderEmail, src => src.Email);

        config.NewConfig<ContactData, Contact>()
            .Map(dest => dest.Name, src => src.SenderName)
            .Map(dest => dest.Email, src => src.SenderEmail);
    }
}