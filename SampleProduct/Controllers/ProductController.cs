using MediatR;
using Microsoft.AspNetCore.Mvc;
using SampleProduct.Domain.Entities;
using SampleProduct.Domain.ValueObjects;
using SampleProduct.Application.Products.Commands.ProductCustomer;
using SampleProduct.Application.Common.Behaviours;
using SampleProduct.Application.Products.Queries.GetProductsWithPagination;
using System.Data;
using Microsoft.AspNetCore.Authorization;

namespace SampleProduct.WebUI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ApiControllerBase
{

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        return new CustomActionResult(await Mediator.Send(new GetProductByIdQuery(id)));
    }

    [HttpPost("all")]
    public async Task<IActionResult> All(GetProductWithPaginationQuery query)
    {
        return new CustomActionResult(await Mediator.Send(query));
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> Create(CreateProductCommand command)
    {
        return new CustomActionResult(await Mediator.Send(command));
    }

    [Authorize(Roles = "Admin")]

    [HttpPut]
    public async Task<IActionResult> Update(UpdateProductCommand command)
    {
        return new CustomActionResult(await Mediator.Send(command));
    }

    [Authorize(Roles = "Customer")]
    [HttpDelete]
    public async Task<IActionResult> Delete(DeleteProductCommand command)
    {
        return new CustomActionResult(await Mediator.Send(command));
    }
}
