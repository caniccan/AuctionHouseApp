using AutoMapper;
using EventBusRabbitMQ.Events;
using Ordering.Application.Commands.OrderCreate;

namespace AuctionHouse.Order.Mapping
{
    public class OrderMapping : Profile
    {
        public OrderMapping()
        {
            CreateMap<OrderCreateEvent, OrderCreateCommand>().ReverseMap();
        }
    }
}
