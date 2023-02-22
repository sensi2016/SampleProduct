using AutoMapper;
using SampleProduct.Application.Common.Mappings;
using SampleProduct.Domain.Entities;
using SampleProduct.Domain.Enums;

namespace SampleProduct.Application.Orders.Commands.ProductCustomer;

public record CreateOrderCommand : IRequest<BaseResponseDto>
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }

}

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, BaseResponseDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private ICurrentUserService _currentUserService;
    public CreateOrderCommandHandler(IApplicationDbContext context, IMapper mapper, ICurrentUserService currentUserService)
    {
        _context = context;
        _mapper = mapper;
        _currentUserService = currentUserService;
    }

    public async Task<BaseResponseDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order =await _context.Order.Where(d=>d.UserId==Convert.ToInt32(_currentUserService.UserId)).FirstOrDefaultAsync();

        if(order is null)
        {
            order = new Order { OrderStatus = OrderStatus.Pending, UserId = Convert.ToInt32(_currentUserService.UserId),Created=DateTime.Now };

            var product =await _context.Product.Where(d => d.Id == request.ProductId).FirstOrDefaultAsync();
            order.OrderDetails = new List<OrderDetail>();
            order.OrderDetails.Add(new OrderDetail { ProductId = request.ProductId,Price=new Domain.ValueObjects.Price(product.Price.Value) });
            await _context.Order.AddAsync(order);
        }
        else
        {
            await _context.OrderDetail.AddAsync(new OrderDetail { ProductId = request.ProductId });
        }

        await _context.SaveChangesAsync(cancellationToken);

        return new BaseResponseDto
        {
            Status=ResponseStatus.Success
        };
    }
}

