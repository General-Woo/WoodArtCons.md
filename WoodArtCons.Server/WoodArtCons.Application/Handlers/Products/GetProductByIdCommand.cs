using MediatR;
using Microsoft.EntityFrameworkCore;
using WoodArtCons.Server.WoodArtCons.Application.Handlers.Categories;
using WoodArtCons.Server.WoodArtCons.Persistence;
using WoodArtCons.Server.WoodArtCons.Persistence.Entities;

namespace WoodArtCons.Server.WoodArtCons.Application.Handlers.Products
{
    public class GetProductByIdCommand : IRequest<CategoryProductModel>
    {
        public string Id { get; set; }
        public GetProductByIdCommand(string id)
        {
            Id = id;
        }
    }

    public class GetProductByIdCommandHandler : IRequestHandler<GetProductByIdCommand, CategoryProductModel>
    {
        private readonly AppDbContext _appDbContext;

        public GetProductByIdCommandHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<CategoryProductModel> Handle(GetProductByIdCommand request, CancellationToken cancellationToken)
        {
            var product = await _appDbContext.Products.FirstOrDefaultAsync(x => x.Id == request.Id);
            return product;
        }
    }
}
