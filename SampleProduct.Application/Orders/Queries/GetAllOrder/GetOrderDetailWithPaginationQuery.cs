using AutoMapper.QueryableExtensions;

namespace SampleProduct.Application.Orders.Queries.GetOrderDetailWithPagination;

public record GetOrderDetailWithPaginationQuery : IRequest<BaseResponseDto>, IPaging
{
    public int OrderId { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}

public class GetOrderDetailWithPaginationQueryHandler : IRequestHandler<GetOrderDetailWithPaginationQuery, BaseResponseDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetOrderDetailWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<BaseResponseDto> Handle(GetOrderDetailWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var map = await _context.OrderDetail
            .Where(d=>d.OrderId==request.OrderId)
            .OrderBy(x => x.Id)
            .ToPagedQuery(request)
            .ProjectTo<OrderDetailDto>(_mapper.ConfigurationProvider)
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
