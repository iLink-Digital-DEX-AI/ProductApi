using System.Collections.Generic;
using System.Threading.Tasks;

public interface IHomeApplianceRepository
{
    Task<List<HomeAppliance>> GetHomeAppliancesAsync();
    Task<HomeAppliance?> GetHomeApplianceByIdAsync(int id);
    Task<HomeAppliance> AddHomeApplianceAsync(HomeAppliance homeAppliance);
    Task<bool> UpdateHomeApplianceAsync(int id, HomeAppliance homeAppliance);
    Task<bool> DeleteHomeApplianceAsync(int id);
    bool HomeApplianceExists(int id);
}
