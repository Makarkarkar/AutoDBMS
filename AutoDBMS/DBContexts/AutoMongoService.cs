using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AutoDBMS;

public class AutoMongoService
{
    private readonly IMongoCollection<Brand> _brandsCollection;
    private readonly IMongoCollection<Model> _modelsCollection;
    private readonly IMongoCollection<Vehicle> _vehiclesCollection;

    public AutoMongoService(
        IOptions<AutoMongoSettings> autoDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            autoDatabaseSettings.Value.ConnectionString);
        
        var mongoDatabase = mongoClient.GetDatabase(
            autoDatabaseSettings.Value.DatabaseName);
        
        _brandsCollection = mongoDatabase.GetCollection<Brand>(
            autoDatabaseSettings.Value.BrandsCollection);
        
        _modelsCollection = mongoDatabase.GetCollection<Model>(
            autoDatabaseSettings.Value.ModelsCollection);
        
        _vehiclesCollection = mongoDatabase.GetCollection<Vehicle>(
            autoDatabaseSettings.Value.VehiclesCollection);
        
    }
    public Brand GetBrandById(int id)
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();
        var brand = _brandsCollection.Find(c => c.Id == id).FirstOrDefault();
        brand.Models = _modelsCollection.Find(c => c.BrandId == id).ToList();
        watch.Stop();
        Console.WriteLine(watch.ElapsedMilliseconds);
        Console.WriteLine(brand);
        return brand;
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
        var watch = System.Diagnostics.Stopwatch.StartNew();
        var brands = _brandsCollection.Aggregate()
            .Lookup<Brand, Model, Brand>(
                _modelsCollection,
                b => b.Id,
                m => m.BrandId,
                b => b.Models).ToList();
        watch.Stop();
        Console.WriteLine(watch.ElapsedMilliseconds);
        return brands;
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
        _vehiclesCollection.InsertOne(vehicle);
        return vehicle;
    }

    public Brand DeleteBrand(int id)
    {
        throw new NotImplementedException();
    }

    public Vehicle DeleteVehicle(int id)
    {
        _vehiclesCollection.DeleteOneAsync(x => x.Id == id);
        return GetVehicleById(id);
    }
}