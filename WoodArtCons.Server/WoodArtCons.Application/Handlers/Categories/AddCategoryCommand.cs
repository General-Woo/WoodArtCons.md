using MediatR;
using WoodArtCons.Server.WoodArtCons.Persistence;
using WoodArtCons.Server.WoodArtCons.Persistence.Entities;

namespace WoodArtCons.Server.WoodArtCons.Application.Handlers.Categories
{
    public class AddCategoryCommand : IRequest<string>
    {
        public string Id { get; set; }
        public string NameRo { get; set; }
        public string NameRu { get; set; }
        public string NameEn { get; set; }
        public string ImageSrc { get; set; }
        public string Link { get; set; }
        public bool IsForGalery { get; set; }
        public AddCategoryCommand(CategoryModel model) { 
            Id = model.Id;
            NameRo = model.NameRo;
            NameRu = model.NameRu;
            NameEn = model.NameEn;
            ImageSrc = model.ImageSrc;
            Link = model.Link;
            IsForGalery = model.IsForGalery;
        }
        public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, string>
        {
            private readonly AppDbContext _appDbContext;

            public AddCategoryCommandHandler(AppDbContext appDbContext)
            {
                _appDbContext = appDbContext;
            }
            public async Task<string> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
            {
                var categoryToAdd = new CategoryModel
                {
                    Id = request.Id,
                    NameRo = request.NameRo,
                    NameRu = request.NameRu,
                    NameEn = request.NameEn,
                    ImageSrc = request.ImageSrc,
                    IsForGalery = request.IsForGalery,
                    Link = request.Link,
                };

                _appDbContext.Categories.Add(categoryToAdd);

                await _appDbContext.SaveChangesAsync();

                return categoryToAdd.Id;
            }
        }
    }
}
