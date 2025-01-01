// copilot:ignore

using Microsoft.EntityFrameworkCore;

public class HomeApplianceProvider
{
    private readonly HomeApplianceContext _context;

    public HomeApplianceProvider(HomeApplianceContext context)
    {
        _context = context;
    }

    public async Task<List<HomeAppliance>> GetHomeAppliancesAsync()
    {
        return await _context.HomeAppliances.ToListAsync();
    }


    public async Task<HomeAppliance> GetHomeApplianceByIdAsync(int id)
    {
        return await _context.HomeAppliances.FindAsync(id);
    }

    public async Task<bool> UpdateHomeApplianceAsync(int id, HomeAppliance homeAppliance)
    {
        if (id != homeAppliance.Id)
        {
            return false;
        }

        _context.Entry(homeAppliance).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!HomeApplianceExists(id))
            {
                return false;
            }
            else
            {
                throw;
            }
        }

        return true;
    }

    public async Task<HomeAppliance> AddHomeApplianceAsync(HomeAppliance homeAppliance)
    {
        _context.HomeAppliances.Add(homeAppliance);
        await _context.SaveChangesAsync();
        return homeAppliance;
    }

    public async Task<bool> DeleteHomeApplianceAsync(int id)
    {
           
        var homeAppliance = await _context.HomeAppliances.FindAsync(id);
        if (homeAppliance == null)
        {
            return false;
        }

        _context.HomeAppliances.Remove(homeAppliance);
        await _context.SaveChangesAsync();

        return true;
    }

    public bool HomeApplianceExists(int id)
    {
        return _context.HomeAppliances.Any(e => e.Id == id);
    }
}
