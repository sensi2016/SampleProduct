using AutoMapper.QueryableExtensions;

namespace SampleProduct.Application.Orders.Queries.GetOrderById;

public record GetOrderByIdQuery(int Id) : IRequest<BaseResponseDto>;


public class GetProductByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, BaseResponseDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetProductByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<BaseResponseDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var map = await _context.Order
                                .Where(d => d.Id == request.Id)
                                .ProjectTo<OrderDto>(_mapper.ConfigurationProvider)
                                .AsNoTracking()
                                .FirstOrDefaultAsync();


        return new BaseResponseDto
        {
            Status = ResponseStatus.Success,
            Data = map
        };

    }
}
