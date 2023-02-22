using SampleProduct.Application.Common.Mappings;
using SampleProduct.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProduct.Application.Common.Models;

public class OrderDetailDto:IMapFrom<OrderDetail>
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public int Discount { get; set; }
    public int OrderId { get; set; }
    public decimal Price { get; set; }

    public string Product { get; set; }
    public int ProductId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<OrderDetail, OrderDetailDto>()
                   .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                   .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price.Value))
                   .ForMember(dest => dest.Discount, opt => opt.MapFrom(src => src.Discount))
                   .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                   .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product.Name))
                   .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId));
    }
}
