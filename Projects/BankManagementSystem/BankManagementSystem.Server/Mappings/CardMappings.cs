using AutoMapper;
using BankManagementSystem.Models;

namespace BankManagementSystem.Mappings
{
    public class CardMappings: Profile
    {
        public CardMappings()
        {
            CreateMap<Card, ResponseCard>()
                .ForMember(c => c.TotalBalance, opt => opt.MapFrom(src => src.Balance));

            CreateMap<RequestOrderCard, Card>();
        }
    }
}
