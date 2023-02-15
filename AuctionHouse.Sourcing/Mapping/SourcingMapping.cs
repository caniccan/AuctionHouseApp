using AuctionHouse.Sourcing.Entities;
using AutoMapper;
using EventBusRabbitMQ.Events;

namespace AuctionHouse.Sourcing.Mapping
{
    public class SourcingMapping : Profile
    {
        public SourcingMapping()
        {
            CreateMap<OrderCreateEvent, Bid>().ReverseMap();
        }
    }
}
