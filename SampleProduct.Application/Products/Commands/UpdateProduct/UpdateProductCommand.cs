using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SampleProduct.Application.Common.Exceptions;

namespace SampleProduct.Application.Products.Commands.ProductCustomer;

public record UpdateProductCommand : IRequest<BaseResponseDto>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Image { get; set; }
    public decimal Price { get; set; }
    public string Note { get; set; }
    
}

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, BaseResponseDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public UpdateProductCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<BaseResponseDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var order =await _context.Order.Where(d => d.Id == request.Id).FirstOrDefaultAsync();
        if (order == null)
        {
            throw new NotFoundException(nameof(Product), request.Id);
        }



       // _context.Order.Update(product);

        await _context.SaveChangesAsync(cancellationToken);

        return new BaseResponseDto
        {
            Status=ResponseStatus.Success
        };
    }
}

