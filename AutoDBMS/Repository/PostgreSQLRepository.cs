using Microsoft.EntityFrameworkCore;

namespace AutoDBMS.Repository;

public class PostgreSQLRepository : IRepository
{
    private readonly AutoContext _context;

    public PostgreSQLRepository(AutoContext context)
    {
        _context = context;
    }

    public Brand GetBrandById(int id)
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();
        var brand = _context.Brands.First(a => a.Id == id);
        if (brand == null) return null;
        brand.Models = GetBrandModels(brand.Id);
        watch.Stop();
        Console.WriteLine(watch.ElapsedMilliseconds);
        return brand;
        
    }

    public  Model GetModelById(int id)=>
    _context.Models.First(a => a.Id == id);

    public Vehicle GetVehicleById(int id) =>
        _context.Vehicles.First(a => a.Id == id);
    
    public IEnumerable<Brand> GetAllBrands()
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();
        var brands = _context.Brands
            .Include(b=>b.Models)
            .ThenInclude(m=>m.Vehicles)
            .ToList();
        watch.Stop();
        Console.WriteLine(watch.ElapsedMilliseconds);
        return brands;
    }

    public async Task<IEnumerable<Model>> GetAllModels()
    {
        var models = await _context.Models.ToListAsync();
        foreach (var model in models)
        {
            model.Vehicles = await GetModelVehicles(model.Id);
        }

        return models;
    }
    
    public async Task<IEnumerable<Vehicle>> GetAllVehicles()=>
        await _context.Vehicles.ToListAsync();

    //public async Task<Vehicle> UpdateVehicle(Vehicle vehicle)
    //{
        //var vehicleFind = _context.Vehicles.First(c => c.Id == vehicle.Id);
        //vehicleFind = vehicle;
        //await _context.SaveChangesAsync();
       // return vehicleFind;

    //}

    public Vehicle AddVehicle(Vehicle vehicle)
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();
        _context.Vehicles.Add(vehicle);
        _context.SaveChanges();
        watch.Stop();
        Console.WriteLine(watch.ElapsedMilliseconds);
        return vehicle;
    }

    public Vehicle DeleteVehicle(int id)
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();
        var vehicle = _context.Vehicles.First(c => c.Id == id);
        _context.Vehicles.Remove(vehicle);
        _context.SaveChanges();
        watch.Stop();
        Console.WriteLine(watch.ElapsedMilliseconds);
        return vehicle;
    }
    public Brand DeleteBrand(int id)
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();
        var brand = _context.Brands.First(c => c.Id == id);
        _context.Brands.Remove(brand);
        _context.SaveChangesAsync();
        watch.Stop();
        Console.WriteLine(watch.ElapsedMilliseconds);
        return brand;
    }

    public ICollection<Model> GetBrandModels(int brandId)
    {
        return _context.Models.Where(c => c.BrandId == brandId).ToList();
    }
    
    public async Task<ICollection<Vehicle>> GetModelVehicles(int modelId)
    {
        return _context.Vehicles.Where(c => c.ModelId == modelId).ToList();
    }
}