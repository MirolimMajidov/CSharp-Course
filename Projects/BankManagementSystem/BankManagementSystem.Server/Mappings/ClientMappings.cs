using AutoMapper;
using BankManagementSystem.CQRS.Commands;
using BankManagementSystem.Models;

namespace BankManagementSystem.Mappings
{
    public class ClientMappings : Profile
    {
        public ClientMappings()
        {
            CreateMap<CreateClientCommand, Client>();
            CreateMap<UpdateClientCommand, Client>();
        }
    }
}
