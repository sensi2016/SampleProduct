using SampleProduct.Application.Products.Queries.GetProductsWithPagination;
using FluentValidation;

namespace SampleProduct.Application.Orders.Queries.GetOrderDetailWithPagination;

public class GetOrderDetailWithPaginationQueryValidator : AbstractValidator<GetOrderDetailWithPaginationQuery>
{
    public GetOrderDetailWithPaginationQueryValidator()
    {
     

        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
    }
}
