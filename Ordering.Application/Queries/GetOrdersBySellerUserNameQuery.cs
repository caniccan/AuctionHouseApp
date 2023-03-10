using MediatR;
using Ordering.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Queries
{
    /// <summary>
    /// GetOrdersBySellerUserNameQuery
    /// </summary>
    public class GetOrdersBySellerUserNameQuery : IRequest<IEnumerable<OrderResponse>>
    {
        /// <summary>
        /// UserName
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// GetOrdersBySellerUserNameQuery Constructor
        /// </summary>
        /// <param name="userName"></param>
        public GetOrdersBySellerUserNameQuery(string userName)
        {
            UserName = userName;
        }
    }
}
