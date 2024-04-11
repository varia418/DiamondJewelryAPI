using DiamondJewelryAPI.Contracts.Common;

namespace DiamondJewelryAPI.Contracts.Contacts.Requests;

public record UpsertContactsRequest(
    Contact Contact
);