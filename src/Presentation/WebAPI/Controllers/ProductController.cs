using Application.Features.Products.Commands.Request;
using Application.Features.Products.Commands.Request;
using Application.Features.Products.Handlers;
using Application.Features.Products.Queries.Request;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommandRequest command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommandRequest command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(DeleteProductByIdCommandRequest command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpPost("GetById")]
        public async Task<IActionResult> GetById(GetProductByIdQueryRequest command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpGet]
        public async Task<IActionResult> GetProductList()
        {
            return Ok(await _mediator.Send(new GetProductListQueryRequest()));
        }
    }
}
