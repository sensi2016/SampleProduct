using AutoMapper.QueryableExtensions;

namespace SampleProduct.Application.Orders.Queries.GetOrdersWithPagination;

public record GetOrderWithPaginationQuery : IRequest<BaseResponseDto>, IPaging
{
   
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}

public class GetOrderWithPaginationQueryHandler : IRequestHandler<GetOrderWithPaginationQuery, BaseResponseDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetOrderWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<BaseResponseDto> Handle(GetOrderWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var map = await _context.Order
            .OrderBy(x => x.Id)
            .ToPagedQuery(request)
            .ProjectTo<OrderDto>(_mapper.ConfigurationProvider)
             .AsNoTracking()
            .ToListAsync();


            return new BaseResponseDto
            {
                Status=ResponseStatus.Success,
                Data = new ResultListDto
                {
                    List = map,
                    Count = await _context.Product.CountAsync()
                }
            };

    }
}
