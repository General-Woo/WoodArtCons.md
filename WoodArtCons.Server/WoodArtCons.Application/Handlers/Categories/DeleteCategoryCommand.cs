using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WoodArtCons.Server.WoodArtCons.Persistence;

namespace WoodArtCons.Server.WoodArtCons.Application.Handlers.Categories
{
    public class DeleteCategoryCommand : IRequest<Unit>
    {
        public string Id { get; set; }
    }
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Unit>
    {
        private readonly AppDbContext _appDbContext;
        public DeleteCategoryCommandHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var eventCategoryToDelete = await _appDbContext.Categories.Where(a => a.Id == request.Id).FirstOrDefaultAsync();

            _appDbContext.Categories.Remove(eventCategoryToDelete);
            await _appDbContext.SaveChangesAsync();
            return Unit.Value;
        }
    }
    //public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
    //{
    //    public DeleteCategoryCommandValidator(IServiceProvider services)
    //    {

    //        //Custom validations with database
    //        RuleFor(d => d).Custom((obj, context) =>
    //        {
    //            using var scope = services.CreateScope();
    //            var db = scope.ServiceProvider.GetService<AppDbContext>();

    //            if (db == null)
    //            {
    //                context.AddFailure("Internal problem - needs admin attention.");
    //                return;
    //            }

    //            var eventCategoryExists = db.Categories.Any(d => d.Id == obj.Id);
    //            if (!eventCategoryExists)
    //            {
    //                context.AddFailure("Invalid event category.");
    //            }
    //        });
    //    }
    //}
}
