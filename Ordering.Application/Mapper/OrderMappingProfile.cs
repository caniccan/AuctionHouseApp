using AutoMapper;
using Ordering.Application.Commands.OrderCreate;
using Ordering.Application.Responses;
using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Mapper
{
    /// <summary>
    /// OrderMappingProfile
    /// </summary>
    public class OrderMappingProfile : Profile
    {
        /// <summary>
        /// OrderMappingProfile Constructor that uses for mapping.
        /// </summary>
        public OrderMappingProfile()
        {
            CreateMap<Order,OrderCreateCommand>().ReverseMap();
            CreateMap<Order,OrderResponse>().ReverseMap();
        }
    }
}
