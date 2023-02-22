using AutoMapper.QueryableExtensions;

namespace SampleProduct.Application.Products.Queries.GetProductsWithPagination;

public record GetProductWithPaginationQuery : IRequest<BaseResponseDto>, IPaging
{
   
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}

public class GetProductWithPaginationQueryHandler : IRequestHandler<GetProductWithPaginationQuery, BaseResponseDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetProductWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<BaseResponseDto> Handle(GetProductWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var map = await _context.Product
            .OrderBy(x => x.Id)
            .ToPagedQuery(request)
            .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
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
