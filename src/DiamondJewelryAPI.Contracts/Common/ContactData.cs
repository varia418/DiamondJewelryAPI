namespace DiamondJewelryAPI.Contracts.Common;

public record ContactData(
    string Id,
    string SenderName,
    string SenderEmail,
    string Content
);