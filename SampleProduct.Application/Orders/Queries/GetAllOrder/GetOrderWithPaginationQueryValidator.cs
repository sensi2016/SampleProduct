
using FluentValidation;

namespace SampleProduct.Application.Orders.Queries.GetOrdersWithPagination;

public class GetOrderWithPaginationQueryValidator : AbstractValidator<GetOrderWithPaginationQuery>
{
    public GetOrderWithPaginationQueryValidator()
    {
     

        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
    }
}
