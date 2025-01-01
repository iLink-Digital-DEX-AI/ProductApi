using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class HomeAppliancesController : ControllerBase
{
    private readonly IHomeApplianceRepository _repository;
    public HomeAppliancesController(IHomeApplianceRepository repository)
    {
        _repository = repository;
    }
    
    // GET: api/HomeAppliances
    [HttpGet]
    public async Task<ActionResult<IEnumerable<HomeAppliance>>> GetHomeAppliances()
    {
        return await _repository.GetHomeAppliancesAsync();
    }

    // GET: api/HomeAppliances/5
    [HttpGet("{id}")]
    public async Task<ActionResult<HomeAppliance>> GetHomeAppliance(int id)
    {
        var homeAppliance = await _repository.GetHomeApplianceByIdAsync(id);

        if (homeAppliance == null)
        {
            return NotFound();
        }

        return homeAppliance;
    }

    // PUT: api/HomeAppliances/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutHomeAppliance(int id, HomeAppliance homeAppliance)
    {
        var result = await _repository.UpdateHomeApplianceAsync(id, homeAppliance);
        if (!result)
        {
            return BadRequest();
        }

        return NoContent();
    }

    // POST: api/HomeAppliances
    [HttpPost]
    public async Task<ActionResult<HomeAppliance>> PostHomeAppliance(HomeAppliance homeAppliance)
    {
        var createdHomeAppliance = await _repository.AddHomeApplianceAsync(homeAppliance);
        return CreatedAtAction("GetHomeAppliance", new { id = createdHomeAppliance.Id }, createdHomeAppliance);
    }

    // DELETE: api/HomeAppliances/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteHomeAppliance(int id)
    {
        var result = await _repository.DeleteHomeApplianceAsync(id);
        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}
