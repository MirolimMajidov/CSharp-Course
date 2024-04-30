using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace BankManagementSystem.Models;

public class Branch : BaseEntity
{
    //private ILazyLoader _lazyLoader;
    public Branch(/*ILazyLoader lazyLoader*/)
    {
        //_lazyLoader = lazyLoader;
        Workers = new();
        Clients = new();
    }

    public string Address { get; set; }

    public virtual Bank Bank { get; set; }
    //TODO
    //private Bank _bank;
    //public virtual Bank Bank
    //{
    //    get
    //    {
    //        if (_bank == null)
    //        {
    //            _lazyLoader.Load(this, nameof(Bank));
    //        }
    //        return _bank;
    //    }
    //    set
    //    {
    //        _bank = value;
    //    }
    //}

    public Guid BankId { get; set; }

    public virtual List<Worker> Workers { get; set; }

    public virtual List<Client> Clients { get; set; }
}
