using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WoodArtCons.Server.WoodArtCons.Application.Handlers.Categories;
using WoodArtCons.Server.WoodArtCons.Application.Handlers.Products;
using WoodArtCons.Server.WoodArtCons.Persistence.Entities;

namespace WoodArtCons.Server.Controllers
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

        [HttpGet("byCategoryId/{id}")]
        public async Task<List<CategoryProductModel>> GetProductsByCategoryId([FromRoute] string id)
        {
            return await _mediator.Send(new GetProductsByCategoryIdCommand(id));
        }

        [HttpGet("byId/{id}")]
        public async Task<CategoryProductModel> GetProductById([FromRoute] string id)
        {
            return await _mediator.Send(new GetProductByIdCommand(id));
        }

        [Authorize]
        [HttpPost]
        public async Task<string> AddProduct(CategoryProductModel request)
        {
            return await _mediator.Send(new AddProductCommand(request));
        }

        [Authorize]
        [HttpPut]
        public async Task<Unit> EditProduct([FromBody] CategoryProductModel request)
        {
            return await _mediator.Send(new EditProductCommand(request));
        }

        [Authorize]
        [HttpDelete("delete/{id}")]
        public async Task<Unit> DeleteProduct([FromRoute] string id)
        {
            return await _mediator.Send(new DeleteProductCommand { Id = id });
        }
    }
}
