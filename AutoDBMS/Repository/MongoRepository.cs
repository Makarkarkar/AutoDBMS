namespace AutoDBMS.Repository;

public class MongoRepository : IRepository
{
    private readonly AutoMongoService _service;
    
    public MongoRepository(AutoMongoService service)
    {
        _service = service;
    }
    public Brand GetBrandById(int id)
    {
        return _service.GetBrandById(id);
    }

    public Model GetModelById(int id)
    {
        throw new NotImplementedException();
    }

    public Vehicle GetVehicleById(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Brand> GetAllBrands()
    {
        return _service.GetAllBrands();
    }

    public Task<IEnumerable<Model>> GetAllModels()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Vehicle>> GetAllVehicles()
    {
        throw new NotImplementedException();
    }

    public Vehicle AddVehicle(Vehicle vehicle)
    {
        return _service.AddVehicle(vehicle);
    }

    public Brand DeleteBrand(int id)
    {
        throw new NotImplementedException();
    }

    public Vehicle DeleteVehicle(int id)
    {
        return _service.DeleteVehicle(id);
    }
}