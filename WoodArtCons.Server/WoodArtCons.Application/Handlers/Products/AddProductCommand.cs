using MediatR;
using WoodArtCons.Server.WoodArtCons.Persistence;
using WoodArtCons.Server.WoodArtCons.Persistence.Entities;

namespace WoodArtCons.Server.WoodArtCons.Application.Handlers.Products
{
    public class AddProductCommand : IRequest<string>
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
        public AddProductCommand(CategoryProductModel model)
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

        public class AddProductCommandHandler : IRequestHandler<AddProductCommand, string>
        {
            private readonly AppDbContext _appDbContext;

            public AddProductCommandHandler(AppDbContext appDbContext)
            {
                _appDbContext = appDbContext;
            }
            public async Task<string> Handle(AddProductCommand request, CancellationToken cancellationToken)
            {
                var productToAdd = new CategoryProductModel
                {
                    Id = request.Id,
                    CategoryId = request.CategoryId,
                    NameRo = request.NameRo,
                    NameRu = request.NameRu,
                    NameEn = request.NameEn,
                    ImageSrc = request.ImageSrc,
                    ListImagesSrc = request.ListImagesSrc,
                    Lenght = request.Lenght,
                    Height = request.Height,
                    Width = request.Width,
                    Link = request.Link,
                    DescriptionRo = request.DescriptionRo,
                    DescriptionRu = request.DescriptionRu,
                    DescriptionEn = request.DescriptionEn,
                    MaterialRo = request.MaterialRo,
                    MaterialRu = request.MaterialRu,
                    MaterialEn = request.MaterialEn,
                    PricePerSquareMeter = request.PricePerSquareMeter,
                    Price = request.Price,
                };

                _appDbContext.Products.Add(productToAdd);

                await _appDbContext.SaveChangesAsync();

                return productToAdd.Id;
            }
        }
    }
}
