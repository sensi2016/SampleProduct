using FluentValidation;
using SampleProduct.Application.Products.Commands.ProductCustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SampleProduct.Application.Products.Commands.CreateProduct;

public class LoginUserCommandValidation : AbstractValidator<LoginUserCommand>
{
    public LoginUserCommandValidation()
    {
        RuleFor(v => v.UserName)
            .NotEmpty()
            .WithMessage("A valid username is required.");
        
        RuleFor(v => v.Password)
            .NotEmpty()
            .WithMessage("A valid password is required.");
    }
}
