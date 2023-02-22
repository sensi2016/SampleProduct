namespace SampleProduct.Application.Products.Commands.ProductCustomer;

public record CreateProductCommand : IRequest<BaseResponseDto>
{
    public string Name { get; set; }
    public string? Image { get; set; }
    public decimal Price { get; set; }
    public string? Note { get; set; }
 
}

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, BaseResponseDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public CreateProductCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<BaseResponseDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var productt = new Product();
        productt.Name = "ali";
      
       var product= _mapper.Map<ProductDto>(productt);
       var productn= _mapper.Map<Product>(request);
       

        await _context.SaveChangesAsync(cancellationToken);

        return new BaseResponseDto
        {
            Status=ResponseStatus.Success
        };
    }
}

