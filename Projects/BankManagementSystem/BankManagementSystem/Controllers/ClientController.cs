
using BankManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankManagementSystem.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientController : ControllerBase
{
    static Dictionary<Guid, Client> Items = new Dictionary<Guid, Client>();

    [HttpGet("AllItems")]
    public IEnumerable<Client> Get()
    {
        return Items.Values;
    }

    [HttpGet("GetItemById")]
    public Client Get(Guid id)
    {
        return Items.SingleOrDefault(w => w.Key == id).Value;
    }

    [HttpPost("Create")]
    public string Post([FromBody] Client item)
    {
        if (string.IsNullOrEmpty(item.FirstName))
        {
            return "The name cannot be empty";
        }
        else
        {
            Items.Add(item.Id, item);
            return $"Created new item with this ID: {item.Id}";
        }
    }

    [HttpPut("Update")]
    public string Put([FromQuery] Guid id, [FromBody] Client item)
    {
        var _item = Items.SingleOrDefault(w => w.Key == id).Value;
        if(_item is null)
        {
            return "Item not found";
        }
        _item.FirstName = item.FirstName;
        _item.LastName = item.LastName;
        _item.Birthday = item.Birthday;
        return "Item updated";
    }

    [HttpDelete("Delete")]
    public string Delete([FromQuery] Guid id)
    {
        var _item = Items.SingleOrDefault(w => w.Key == id).Value;
        if (_item is null)
        {
            return "Item not found";
        }
        Items.Remove(id);

        return "Item deleted";
    }
}
