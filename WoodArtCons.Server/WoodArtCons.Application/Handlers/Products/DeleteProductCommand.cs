using MediatR;
using Microsoft.EntityFrameworkCore;
using WoodArtCons.Server.WoodArtCons.Persistence;

namespace WoodArtCons.Server.WoodArtCons.Application.Handlers.Products
{
    public class DeleteProductCommand : IRequest<Unit>
    {
        public string Id { get; set; }
    }

    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly AppDbContext _appDbContext;
        public DeleteProductCommandHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var productToDelete = await _appDbContext.Products.Where(a => a.Id == request.Id).FirstOrDefaultAsync();

            _appDbContext.Products.Remove(productToDelete);
            await _appDbContext.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
