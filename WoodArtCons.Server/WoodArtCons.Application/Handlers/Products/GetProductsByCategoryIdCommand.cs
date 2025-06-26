using MediatR;
using Microsoft.EntityFrameworkCore;
using WoodArtCons.Server.WoodArtCons.Persistence;
using WoodArtCons.Server.WoodArtCons.Persistence.Entities;

namespace WoodArtCons.Server.WoodArtCons.Application.Handlers.Products
{
    public class GetProductsByCategoryIdCommand : IRequest<List<CategoryProductModel>>
    {
        public string Id { get; set; }
        public GetProductsByCategoryIdCommand(string id)
        {
            Id = id;
        }
    }

    public class GetProductsByCategoryIdCommandHandler : IRequestHandler<GetProductsByCategoryIdCommand, List<CategoryProductModel>>
    {
        private readonly AppDbContext _appDbContext;

        public GetProductsByCategoryIdCommandHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<CategoryProductModel>> Handle(GetProductsByCategoryIdCommand request, CancellationToken cancellationToken)
        {
            var products = await _appDbContext.Products.Where(p => p.CategoryId == request.Id).ToListAsync();
            return products;
        }
    }    
}
