using AutoDBMS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AutoDBMS.Controllers;

[ApiController]
[Route("api/auto")]
public class AutoController:ControllerBase
{
    private readonly IRepository _repository;

    public AutoController(IRepository repository)
    {
        _repository = repository;
    }
    
    [ProducesResponseType(404)]
    [HttpGet("brands/{id}")]
    public async Task<Brand> GetBrandById(int id)
    {
        return _repository.GetBrandById(id);
    }
    
    [ProducesResponseType(404)]
    [HttpGet("models/{id}")]
    public Model GetModelById(int id)
    {
        return _repository.GetModelById(id);
    }
    
    [HttpGet("vehicles/{id}")]
    [ProducesResponseType(404)]
    public Vehicle GetVehicleById(int id)
    {
        return _repository.GetVehicleById(id);
    }
    
    [HttpGet("brands")]
    [ProducesResponseType(404)]
    public async Task<IEnumerable<Brand>> GetBrands()
    {
        return _repository.GetAllBrands();
    }
    
    [HttpGet("models")]
    [ProducesResponseType(404)]
    public async Task<IEnumerable<Model>> GetModels()
    {
        return await _repository.GetAllModels();
    }
    
    [HttpGet("vehicles")]
    [ProducesResponseType(404)]
    public async Task<IEnumerable<Vehicle>> GetVehicles()
    {
        return await _repository.GetAllVehicles();
    }
    
    [HttpPost("vehicles")]
    [ProducesResponseType(404)]
    public async Task<Vehicle> AddVehicle(Vehicle vehicle)
    {
        return _repository.AddVehicle(vehicle);
    }
    
    [HttpDelete("vehicles/{id}")]
    [ProducesResponseType(404)]
    public async Task<Vehicle> DeleteVehicle(int id)
    {
        return _repository.DeleteVehicle(id);
    }
    
    [HttpDelete("brands/{id}")]
    [ProducesResponseType(404)]
    public async Task<Brand> DeleteBrand(int id)
    {
        return _repository.DeleteBrand(id);
    }
}