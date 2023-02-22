

using SampleProduct.Application.Common.Interfaces;
namespace SampleProduct.Infrastructure.Service;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
