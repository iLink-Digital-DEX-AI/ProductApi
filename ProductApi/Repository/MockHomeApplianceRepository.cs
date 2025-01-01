using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class MockHomeApplianceRepository : IHomeApplianceRepository
{
    private readonly List<HomeAppliance> _homeAppliances;

    public MockHomeApplianceRepository()
    {
        _homeAppliances = new List<HomeAppliance>
        {
            new HomeAppliance { Id = 1, Name = "Refrigerator", Category = "Kitchen", Brand = "BrandA", Price = 499.99M },
            new HomeAppliance { Id = 2, Name = "Washing Machine", Category = "Laundry", Brand = "BrandB", Price = 299.99M },
            new HomeAppliance { Id = 3, Name = "Microwave Oven", Category = "Kitchen", Brand = "BrandC", Price = 199.99M }
        };
    }

    public Task<List<HomeAppliance>> GetHomeAppliancesAsync()
    {
        return Task.FromResult(_homeAppliances);
    }

    public Task<HomeAppliance?> GetHomeApplianceByIdAsync(int id)
    {
        var homeAppliance = _homeAppliances.FirstOrDefault(h => h.Id == id);
        return Task.FromResult(homeAppliance);
    }

    public Task<HomeAppliance> AddHomeApplianceAsync(HomeAppliance homeAppliance)
    {
        homeAppliance.Id = _homeAppliances.Max(h => h.Id) + 1;
        _homeAppliances.Add(homeAppliance);
        return Task.FromResult(homeAppliance);
    }

    public Task<bool> UpdateHomeApplianceAsync(int id, HomeAppliance homeAppliance)
    {
        var existingHomeAppliance = _homeAppliances.FirstOrDefault(h => h.Id == id);
        if (existingHomeAppliance == null)
        {
            return Task.FromResult(false);
        }

        existingHomeAppliance.Name = homeAppliance.Name;
        existingHomeAppliance.Category = homeAppliance.Category;
        existingHomeAppliance.Brand = homeAppliance.Brand;
        existingHomeAppliance.Price = homeAppliance.Price;

        return Task.FromResult(true);
    }

    public Task<bool> DeleteHomeApplianceAsync(int id)
    {
        var homeAppliance = _homeAppliances.FirstOrDefault(h => h.Id == id);
        if (homeAppliance == null)
        {
            return Task.FromResult(false);
        }

        _homeAppliances.Remove(homeAppliance);
        return Task.FromResult(true);
    }

    public bool HomeApplianceExists(int id)
    {
        return _homeAppliances.Any(h => h.Id == id);
    }
}
