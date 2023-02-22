
using Microsoft.EntityFrameworkCore;
using SampleProduct.Application.Common.Exceptions;

namespace SampleProduct.Application.Products.Commands.ProductCustomer;

public record DeleteProductCommand : IRequest<BaseResponseDto>
{
    public int Id { get; set; }
}

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, BaseResponseDto>
{
    private readonly IApplicationDbContext _context;

    public DeleteProductCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<BaseResponseDto> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _context.Product.Where(d => d.Id == request.Id).FirstOrDefaultAsync();
        if (product == null)
        {
            throw new NotFoundException(nameof(Product), request.Id);
        }

        _context.Product.Remove(product);

        await _context.SaveChangesAsync(cancellationToken);

        return new BaseResponseDto
        {
            Status=ResponseStatus.Success
        };
    }
}

