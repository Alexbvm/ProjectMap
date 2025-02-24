using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using ProjectMap.WebApi.Models;
using ProjectMap.WebApi.Repositories;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProjectMap.WebApi.Controllers;

[ApiController]
[Route("2DEnvironments")]
public class Environment2DController : ControllerBase
{
    private readonly IEnvironment2DRepository _environment2DRepository;
    private readonly ILogger<Environment2DController> _logger;

    public Environment2DController(IEnvironment2DRepository environment2DRepository, ILogger<Environment2DController> logger)
    {
        _environment2DRepository = environment2DRepository;
        _logger = logger;
    }

    [HttpGet(Name = "Read2DEnvironments")]
    public async Task<ActionResult<IEnumerable<Environment2D>>> Get()
    {
        var environment2Ds = await _environment2DRepository.ReadAsync();
        return Ok(environment2Ds);
    }

    [HttpGet("{environment2DId}", Name = "Read2DEnvironment")]
    public async Task<ActionResult<Environment2D>> Get(Guid environment2DId)
    {
        var environment2D = await _environment2DRepository.ReadAsync(environment2DId);
        if (environment2D == null)
            return NotFound();

        return Ok(environment2D);
    }

    [HttpPost(Name = "Create2Denvironment")]
    public async Task<ActionResult> Add(Environment2D environment2D)
    {
        environment2D.Id = Guid.NewGuid();

        var createdEnvironment2D = await _environment2DRepository.InsertAsync(environment2D);
        return Created();
    }
    [HttpPut("{environment2DId}", Name = "Update2DEnvironment")]
    public async Task<ActionResult> Update(Guid environment2DId, Environment2D newEnvironment2D)
    {
        var existingEnvironment2D = await _environment2DRepository.ReadAsync(environment2DId);

        if (existingEnvironment2D == null)
            return NotFound();

        await _environment2DRepository.UpdateAsync(newEnvironment2D);

        return Ok(newEnvironment2D);
    }

    [HttpDelete("{environment2DId}", Name = "Delete2DEnvironmentByGuid")]
    public async Task<IActionResult> Update(Guid environment2DId)
    {
        var existingEnvironment2D = await _environment2DRepository.ReadAsync(environment2DId);

        if (existingEnvironment2D == null)
            return NotFound();

        await _environment2DRepository.DeleteAsync(environment2DId);

        return Ok();
    }

}
