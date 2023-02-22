using SampleProduct.Application.Common.Mappings;
using SampleProduct.Domain.Enums;
using SampleProduct.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProduct.Application.Common.Models
{
    public class OrderDto:IMapFrom<Order>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string User { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrderDto>()
                       .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                       .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                       .ForMember(dest => dest.User, opt => opt.MapFrom(src => $"{src.User.FirstName} {src.User.LastName}" ))
                       .ForMember(dest => dest.OrderStatus, opt => opt.MapFrom(src => src.OrderStatus));
        }
    }
}
