namespace AutoDBMS;

public class AutoMongoSettings
{
    public string ConnectionString { get; set; } = null!;
    
    public string DatabaseName { get; set; } = null!;
    
    public string BrandsCollection { get; set; } = null!;
    public string ModelsCollection { get; set; } = null!;
    public string VehiclesCollection { get; set; } = null!;
}