using AuctionHouse.Sourcing.Entities;
using AutoMapper;
using EventBusRabbitMQ.Events;

namespace AuctionHouse.Sourcing.Mapping
{
    /// <summary>
    /// SourcingMapping
    /// </summary>
    public class SourcingMapping : Profile
    {
        /// <summary>
        /// SourcingMapping Constructor uses for mapping.
        /// </summary>
        public SourcingMapping()
        {
            CreateMap<OrderCreateEvent, Bid>().ReverseMap();
        }
    }
}
