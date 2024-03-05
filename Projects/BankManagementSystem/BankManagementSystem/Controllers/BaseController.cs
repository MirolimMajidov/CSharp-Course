﻿using BankManagementSystem.Models;
using BankManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankManagementSystem.Controllers;

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
    public virtual IEnumerable<TEntity> Get()
    {
        return _service.GetAll();
    }

    [HttpGet("GetItemById")]
    public virtual async Task<TEntity> Get(Guid id)
    {
        return await _service.GetById(id);
    }

    [HttpPost("Create")]
    public virtual string Post([FromBody] TEntity item)
    {
        return _service.Create(item);
    }

    [HttpPut("Update")]
    public virtual string Put([FromQuery] Guid id, [FromBody] TEntity item)
    {
        return _service.Update(id, item);
    }

    [HttpDelete("Delete")]
    public virtual string Delete([FromQuery] Guid id)
    {
        return _service.Delete(id);
    }
}
