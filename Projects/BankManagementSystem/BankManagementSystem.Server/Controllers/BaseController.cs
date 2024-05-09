using BankManagementSystem.Models;
using BankManagementSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace BankManagementSystem.Controllers;

[Authorize]
public abstract class BaseController<TEntity> : ControllerBase where TEntity : BaseEntity
{
    protected readonly IBaseService<TEntity> _service;
    protected readonly ILogger<BaseController<TEntity>> _logger;
    public BaseController(ILogger<BaseController<TEntity>> logger, IBaseService<TEntity> service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet("AllItems")]
    public virtual ActionResult<IEnumerable<TEntity>> Get()
    {
        return Ok(_service.GetAll());
    }

    [HttpGet("GetItemById")]
    public virtual async Task<ActionResult<TEntity>> Get(Guid id)
    {
        var item = await _service.GetById(id);
        if (item is null)
            return NotFound();

        return Ok(item);
    }

    [HttpPost("Create")]
    public virtual ActionResult<TEntity> Post([FromBody] TEntity item)
    {
        var createdItem = _service.TryCreate(item, out string message);
        if (createdItem is null)
            return BadRequest(message);

        return Ok(createdItem);
    }

    [HttpPut("Update")]
    public virtual ActionResult<string> Put([FromQuery] Guid id, [FromBody] TEntity item)
    {
        var updated = _service.TryUpdate(id, item, out string message);
        if (!updated)
            return BadRequest(message);

        return Ok("Successfully updated");
    }

    [HttpDelete("Delete")]
    public virtual ActionResult<string> Delete([FromQuery] Guid id)
    {
        var deleted = _service.TryDelete(id, out string message);
        if (!deleted)
            return BadRequest(message);

        return Ok("Successfully deleted");
    }
}
