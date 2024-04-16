using Microsoft.AspNetCore.Mvc;

namespace BankManagementSystem.Models
{
    public record RequestCardsByHolderId
    {
        [FromQuery]
        public Guid HolderId { get; set; }
    }
}
