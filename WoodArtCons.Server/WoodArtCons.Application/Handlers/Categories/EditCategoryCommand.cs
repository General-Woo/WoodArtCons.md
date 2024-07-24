using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WoodArtCons.Server.WoodArtCons.Persistence;
using WoodArtCons.Server.WoodArtCons.Persistence.Entities;

namespace WoodArtCons.Server.WoodArtCons.Application.Handlers.Categories
{
    public class EditCategoryCommand : IRequest<Unit>
    {
        public string Id { get; set; }
        public string NameRo { get; set; }
        public string NameRu { get; set; }
        public string NameEn { get; set; }
        public string ImageSrc { get; set; }
        public string Link {  get; set; }
        public bool IsForGalery { get; set; }
        public EditCategoryCommand(CategoryModel model)
        {
            Id = model.Id;
            NameRo = model.NameRo;
            NameRu = model.NameRu;
            NameEn = model.NameEn;
            ImageSrc = model.ImageSrc;
            Link = model.Link;
            IsForGalery = model.IsForGalery;
        }
        
    }

    public class EditCategoryCommandHandler : IRequestHandler<EditCategoryCommand, Unit>
    {
        private readonly AppDbContext _appDbContext;
        public EditCategoryCommandHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Unit> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
        {
            string catalogUrl = "/catalog/";
            string galeryUrl = "/galery/";

            var categoryToEdit = await _appDbContext.Categories.Where(a => a.Id == request.Id).FirstOrDefaultAsync();

            if (!string.IsNullOrEmpty(request.Id)) categoryToEdit.Id = request.Id;

            if (!string.IsNullOrEmpty(request.NameRo)) categoryToEdit.NameRo = request.NameRo;

            if (!string.IsNullOrEmpty(request.NameRu)) categoryToEdit.NameRu = request.NameRu;

            if (!string.IsNullOrEmpty(request.NameEn)) categoryToEdit.NameEn = request.NameEn;

            if (!string.IsNullOrEmpty(request.ImageSrc)) categoryToEdit.ImageSrc = request.ImageSrc;

            categoryToEdit.IsForGalery = request.IsForGalery;

            categoryToEdit.Link = request.Link;

            await _appDbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }

    //public class EditCategoryCommandValidator : AbstractValidator<EditCategoryCommand>
    //{
    //    public EditCategoryCommandValidator(IServiceProvider service)
    //    {
    //        RuleFor(c => c.Id)
    //            .NotNull()
    //            .NotEmpty();
    //        RuleFor(c => c.NameRo)
    //            .NotNull()
    //            .NotEmpty();
    //        RuleFor(c => c.NameRu)
    //            .NotNull()
    //            .NotEmpty();
    //        RuleFor(c => c.NameEn)
    //            .NotNull()
    //            .NotEmpty();
    //        RuleFor(c => c.ImageSrc)
    //            .NotNull()
    //            .NotEmpty();
    //        RuleFor(c => c.IsForGalery)
    //            .NotNull()
    //            .NotEmpty();
    //        RuleFor(c => c).Custom((obj, context) =>
    //        {
    //            using var scope = service.CreateScope();
    //            var db = scope.ServiceProvider.GetService<AppDbContext>();

    //            if (db == null)
    //            {
    //                context.AddFailure("Internal problem - needs admin attention.");
    //                return;
    //            }
    //        });
    //    }
    //}
}
