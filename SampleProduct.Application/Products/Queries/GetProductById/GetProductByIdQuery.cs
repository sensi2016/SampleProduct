using AutoMapper.QueryableExtensions;

namespace SampleProduct.Application.Products.Queries.GetProductsWithPagination;

public record GetProductByIdQuery(int Id) : IRequest<BaseResponseDto>;


public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, BaseResponseDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetProductByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<BaseResponseDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var map = await _context.Product
            .Where(d => d.Id == request.Id)
            .ProjectTo<ProductDto>(_mapper.ConfigurationProvider).AsNoTracking().FirstOrDefaultAsync();


        return new BaseResponseDto
        {
            Status = ResponseStatus.Success,
            Data = map
        };

    }
}
