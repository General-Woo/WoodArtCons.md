using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WoodArtCons.Server.WoodArtCons.Application.Handlers.Categories;
using WoodArtCons.Server.WoodArtCons.Persistence.Entities;

namespace WoodArtCons.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all")]
        public async Task<List<CategoryModel>> GetAllCategoriesList()
        {
            return await _mediator.Send(new GetAllCategoriesCommand());
        }

        [HttpGet("{id}")]
        public async Task<CategoryModel> GetCategoryById([FromRoute] string id)
        {
            return await _mediator.Send(new GetCategoryByIdCommand(id));
        }

        [Authorize]
        [HttpPost]
        public async Task<string> AddCategory(CategoryModel request)
        {
            return await _mediator.Send(new AddCategoryCommand(request));
        }

        [Authorize]
        [HttpPut]
        public async Task<Unit> EditCategory([FromBody] CategoryModel request)
        {
            return await _mediator.Send(new EditCategoryCommand(request));
        }

        [Authorize]
        [HttpDelete("delete/{id}")]
        public async Task<Unit> DeleteCategory([FromRoute] string id)
        {
            return await _mediator.Send(new DeleteCategoryCommand { Id = id });
        }
    }
}
