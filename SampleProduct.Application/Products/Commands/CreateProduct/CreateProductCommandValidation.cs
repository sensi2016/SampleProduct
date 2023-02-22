using FluentValidation;
using SampleProduct.Application.Products.Commands.ProductCustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SampleProduct.Application.Products.Commands.CreateProduct;

public class CreateProductCommandValidation : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidation()
    {
        RuleFor(v => v.Name)
            .NotEmpty()
            .WithMessage("A valid name is required.");
    }
}
