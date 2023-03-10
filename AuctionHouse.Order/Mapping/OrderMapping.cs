using AutoMapper;
using EventBusRabbitMQ.Events;
using Ordering.Application.Commands.OrderCreate;

namespace AuctionHouse.Order.Mapping
{
    /// <summary>
    /// OrderMapping
    /// </summary>
    public class OrderMapping : Profile
    {
        /// <summary>
        /// OrderMapping Constructor that uses for mapping.
        /// </summary>
        public OrderMapping()
        {
            CreateMap<OrderCreateEvent, OrderCreateCommand>().ReverseMap();
        }
    }
}
