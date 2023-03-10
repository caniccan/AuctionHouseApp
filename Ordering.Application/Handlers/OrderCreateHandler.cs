using AutoMapper;
using MediatR;
using Ordering.Application.Commands.OrderCreate;
using Ordering.Application.Responses;
using Ordering.Domain.Entities;
using Ordering.Domain.Repositories;

namespace Ordering.Application.Handlers
{
    /// <summary>
    /// OrderCreateHandler
    /// </summary>
    public class OrderCreateHandler : IRequestHandler<OrderCreateCommand, OrderResponse>
    {
        /// <summary>
        /// OrderRepository
        /// </summary>
        private readonly IOrderRepository _orderRepository;

        /// <summary>
        /// Mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// OrderCreateHandler Constructor
        /// </summary>
        /// <param name="orderRepository"></param>
        /// <param name="mapper"></param>
        public OrderCreateHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handle
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public async Task<OrderResponse> Handle(OrderCreateCommand request, CancellationToken cancellationToken)
        {
            var orderEntity = _mapper.Map<Order>(request);
            if (Equals(orderEntity,null))
            {
                throw new ApplicationException("Entity could not be mapped!");
            }

            var order = await _orderRepository.AddAsync(orderEntity);

            return _mapper.Map<OrderResponse>(order);
        }
    }
}
