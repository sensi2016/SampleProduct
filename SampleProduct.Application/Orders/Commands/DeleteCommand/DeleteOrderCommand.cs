namespace SampleProduct.Application.Orders.Commands.ProductCustomer;

public record DeleteOrderCommand : IRequest<BaseResponseDto>
{
    public int Id { get; set; }
}

public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, BaseResponseDto>
{
    private readonly IApplicationDbContext _context;

    public DeleteOrderCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<BaseResponseDto> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        var orderDetail = await _context.OrderDetail.Where(d => d.Id == request.Id).Include(d=>d.Order).FirstOrDefaultAsync();
        
        if (orderDetail == null)        
            throw new NotFoundException(nameof(Product), request.Id);
        

        _context.OrderDetail.Remove(orderDetail);

        await _context.SaveChangesAsync(cancellationToken);

        return new BaseResponseDto
        {
            Status=ResponseStatus.Success
        };
    }
}

