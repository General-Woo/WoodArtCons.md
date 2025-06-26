using MediatR;
//using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using WoodArtCons.Server.WoodArtCons.Persistence;
using WoodArtCons.Server.WoodArtCons.Persistence.Entities;

namespace WoodArtCons.Server.WoodArtCons.Application.Handlers.Categories
{
    public class GetAllCategoriesCommand : IRequest<List<CategoryModel>>
    {
        public GetAllCategoriesCommand() { }
    }

    public class GetAllCategoriesCommandHandler : IRequestHandler<GetAllCategoriesCommand, List<CategoryModel>>
    {
        private readonly AppDbContext _appDbContext;

        public GetAllCategoriesCommandHandler(IConfiguration configuration, AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<CategoryModel>> Handle(GetAllCategoriesCommand request, CancellationToken cancellationToken)
        {
            var categories = await _appDbContext.Categories.ToListAsync();
            return categories;
        }
    }
}
