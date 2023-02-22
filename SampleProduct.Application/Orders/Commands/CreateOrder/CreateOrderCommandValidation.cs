using FluentValidation;
using SampleProduct.Application.Orders.Commands.ProductCustomer;
using SampleProduct.Application.Products.Commands.ProductCustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SampleProduct.Application.Orders.Commands.CreateProduct;

public class CreateOrderCommandValidation : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidation()
    {
        RuleFor(v => v.ProductId)
            .NotEmpty()
            .GreaterThan(0)
            .WithMessage("A valid prodcutId is required.");
        
        RuleFor(v => v.Quantity)
            .NotEmpty()
            .GreaterThan(0)
            .WithMessage("A valid quantity is required.");
    }
}
