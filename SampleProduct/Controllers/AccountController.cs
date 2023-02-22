using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleProduct.Application.Common.Behaviours;
using SampleProduct.Application.Products.Commands.ProductCustomer;

namespace SampleProduct.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ApiControllerBase
    {
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUserCommand command)
        {
            return new CustomActionResult(await Mediator.Send(command));
        }
    }
}
