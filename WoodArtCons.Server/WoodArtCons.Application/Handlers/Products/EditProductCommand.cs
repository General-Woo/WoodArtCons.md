using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WoodArtCons.Server.WoodArtCons.Application.Handlers.Categories;
using WoodArtCons.Server.WoodArtCons.Persistence;
using WoodArtCons.Server.WoodArtCons.Persistence.Entities;

namespace WoodArtCons.Server.WoodArtCons.Application.Handlers.Products
{
    public class EditProductCommand : IRequest<Unit>
    {
        public string Id { get; set; }
        public string CategoryId { get; set; }
        public string NameRo { get; set; }
        public string NameRu { get; set; }
        public string NameEn { get; set; }
        public string ImageSrc { get; set; }
        public IEnumerable<string> ListImagesSrc { get; set; }
        public string? Lenght { get; set; }
        public float? Height { get; set; }
        public float? Width { get; set; }
        public string? Link { get; set; }
        public string? DescriptionRo { get; set; }
        public string? DescriptionRu { get; set; }
        public string? DescriptionEn { get; set; }
        public string? MaterialRo { get; set; }
        public string? MaterialRu { get; set; }
        public string? MaterialEn { get; set; }
        public bool? PricePerSquareMeter { get; set; }
        public string Price { get; set; }
        public EditProductCommand(CategoryProductModel model)
        {
            Id = model.Id;
            CategoryId = model.CategoryId;
            NameRo = model.NameRo;
            NameRu = model.NameRu;
            NameEn = model.NameEn;
            ImageSrc = model.ImageSrc;
            ListImagesSrc = model.ListImagesSrc;
            Lenght = model.Lenght;
            Height = model.Height;
            Width = model.Width;
            Link = model.Link;
            DescriptionRo = model.DescriptionRo;
            DescriptionRu = model.DescriptionRu;
            DescriptionEn = model.DescriptionEn;
            MaterialRo = model.MaterialRo;
            MaterialRu = model.MaterialRu;
            MaterialEn = model.MaterialEn;
            PricePerSquareMeter = model.PricePerSquareMeter;
            Price = model.Price;
        }
    }

    public class EditProductCommandHandler : IRequestHandler<EditProductCommand, Unit>
    {
        private readonly AppDbContext _appDbContext;
        public EditProductCommandHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Unit> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            string catalogUrl = "/catalog/";
            string galeryUrl = "/galery/";

            var productToEdit = await _appDbContext.Products.Where(a => a.Id == request.Id).FirstOrDefaultAsync();

            if (!string.IsNullOrEmpty(request.Id)) productToEdit.Id = request.Id;
            if (!string.IsNullOrEmpty(request.NameRo)) productToEdit.NameRo = request.NameRo;
            if (!string.IsNullOrEmpty(request.NameRu)) productToEdit.NameRu = request.NameRu;
            if (!string.IsNullOrEmpty(request.NameEn)) productToEdit.NameEn = request.NameEn;
            if (!string.IsNullOrEmpty(request.ImageSrc)) productToEdit.ImageSrc = request.ImageSrc;
            //if (!string.IsNullOrWhiteSpace(request.ListImagesSrc)) productToEdit.ListImagesSrc = request.ListImagesSrc;
            if (!string.IsNullOrEmpty(request.Lenght)) productToEdit.Lenght = request.Lenght;
            if ( request.Height != 0) productToEdit.Height = request.Height;
            if ( request.Width != 0) productToEdit.Width = request.Width;
            if (!string.IsNullOrEmpty(request.DescriptionRo)) productToEdit.DescriptionRo = request.DescriptionRo;
            if (!string.IsNullOrEmpty(request.DescriptionRu)) productToEdit.DescriptionRu = request.DescriptionRu;
            if (!string.IsNullOrEmpty(request.DescriptionEn)) productToEdit.DescriptionEn = request.DescriptionEn;
            if (!string.IsNullOrEmpty(request.MaterialRo)) productToEdit.MaterialRo = request.MaterialRo;
            if (!string.IsNullOrEmpty(request.MaterialRu)) productToEdit.MaterialRu = request.MaterialRu;
            if (!string.IsNullOrEmpty(request.MaterialEn)) productToEdit.MaterialEn = request.MaterialEn;
            if (!string.IsNullOrEmpty(request.Price)) productToEdit.Price = request.Price;

            productToEdit.PricePerSquareMeter = request.PricePerSquareMeter;
            productToEdit.ListImagesSrc = request.ListImagesSrc;
            productToEdit.Link = request.Link;

            await _appDbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
