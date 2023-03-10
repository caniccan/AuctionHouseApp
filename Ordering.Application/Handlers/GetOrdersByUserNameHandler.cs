using AutoMapper;
using MediatR;
using Ordering.Application.Queries;
using Ordering.Application.Responses;
using Ordering.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Handlers
{
    /// <summary>
    /// GetOrdersByUserNameHandler
    /// </summary>
    public class GetOrdersByUserNameHandler : IRequestHandler<GetOrdersBySellerUserNameQuery, IEnumerable<OrderResponse>>
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
        /// GetOrdersByUserNameHandler Constructor
        /// </summary>
        /// <param name="orderRepository"></param>
        /// <param name="mapper"></param>
        public GetOrdersByUserNameHandler(IOrderRepository orderRepository, IMapper mapper)
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
        public async Task<IEnumerable<OrderResponse>> Handle(GetOrdersBySellerUserNameQuery request, CancellationToken cancellationToken)
        {
            var orderList = await _orderRepository.GetOrdersBySellerUserName(request.UserName);

            return _mapper.Map<IEnumerable<OrderResponse>>(orderList);
        }
    }
}
