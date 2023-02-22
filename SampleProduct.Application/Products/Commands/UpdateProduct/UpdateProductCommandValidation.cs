namespace SampleProduct.Application.Products.Commands.CreateProduct;


public class UpdateOrderCommandValidation : AbstractValidator<UpdateProductCommand>
{
    public UpdateOrderCommandValidation()
    {
        RuleFor(v => v.Id)
           .NotEmpty()
           .GreaterThan(1)
           .WithMessage("A valid Id is required.");

        RuleFor(v => v.Name)
                  .NotEmpty()
                  .WithMessage("A valid name is required.");

    }
}
