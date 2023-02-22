// ReSharper disable once CheckNamespace
namespace SampleProduct.Application.Common.Interfaces
{
    public interface IPaging
    {
        int PageSize { get; set; }
        int PageNumber { get; set; }
    }
}
