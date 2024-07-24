using MediatR;
//using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using WoodArtCons.Server.WoodArtCons.Persistence;
using WoodArtCons.Server.WoodArtCons.Persistence.Entities;

namespace WoodArtCons.Server.WoodArtCons.Application.Handlers.Categories
{
    public class GetCategoryByIdCommand : IRequest<CategoryModel>
    {
        public string Id { get; set; }
        public GetCategoryByIdCommand(string id)
        {
            Id = id;
        }
    }

    public class GetCategoryByIdCommandHandler : IRequestHandler<GetCategoryByIdCommand, CategoryModel>
    {
        private readonly AppDbContext _appDbContext;

        public GetCategoryByIdCommandHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<CategoryModel> Handle(GetCategoryByIdCommand request, CancellationToken cancellationToken)
        {
            var categories = await _appDbContext.Categories.FirstOrDefaultAsync(x => x.Id == request.Id);
            return categories;
        }
    }
}
