using SampleProduct.Application.Common.Mappings;
using SampleProduct.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProduct.Application.Common.Models
{
    public class ProductDto:IMapFrom<Product>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductDto>()
                       .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                       .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price.Value))
                       .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
