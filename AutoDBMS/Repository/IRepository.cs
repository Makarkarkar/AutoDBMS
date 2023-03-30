namespace AutoDBMS.Repository;

public interface IRepository
{
    Brand GetBrandById(int id);
    Model GetModelById(int id);
    Vehicle GetVehicleById(int id);

    IEnumerable<Brand> GetAllBrands();
    Task<IEnumerable<Model>> GetAllModels();
    Task<IEnumerable<Vehicle>> GetAllVehicles();
    
    // Brand UpdateBrand(Brand brand);
    // Model UpdateModel(Model model);
    //Task<Vehicle> UpdateVehicle(Vehicle vehicle);
    
    // Brand AddBrand(Brand brand);
    // Model AddModel(Model model);
    Vehicle AddVehicle(Vehicle vehicle);
    
    Brand DeleteBrand(int id);
    // Model DeleteModel(int id);
    Vehicle DeleteVehicle(int id);

}