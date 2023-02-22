using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleProduct.Application.Common.Behaviours;
using SampleProduct.Application.Orders.Commands.ProductCustomer;
using SampleProduct.Application.Orders.Queries.GetOrderById;
using SampleProduct.Application.Orders.Queries.GetOrderDetailWithPagination;
using SampleProduct.Application.Orders.Queries.GetOrdersWithPagination;

namespace SampleProduct.WebUI.Controllers
{
    [Route("api/[controller]")]
 
    [ApiController]
    public class OrderController : ApiControllerBase
    {
        [Authorize(Roles ="Customer")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return new CustomActionResult(await Mediator.Send(new GetOrderByIdQuery(id)));
        }

        [HttpPost("all")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> All(GetOrderWithPaginationQuery query)
        {
            return new CustomActionResult(await Mediator.Send(query));
        }

        [HttpPost("orderDetails")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> GetOrderDetail(GetOrderDetailWithPaginationQuery query)
        {
            return new CustomActionResult(await Mediator.Send(query));
        }

        [Authorize(Roles = "Customer")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderCommand command)
        {
            return new CustomActionResult(await Mediator.Send(command));
        }

        [Authorize(Roles = "Customer")]
        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteOrderCommand command)
        {
            return new CustomActionResult(await Mediator.Send(command));
        }
    }
}
