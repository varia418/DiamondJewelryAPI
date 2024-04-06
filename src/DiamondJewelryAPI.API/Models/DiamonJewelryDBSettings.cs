namespace DiamondJewelryAPI.API.Models;


public class DiamondJewelryDBSettings
{
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
    public string ProductsCollectionName { get; set; } = null!;
}