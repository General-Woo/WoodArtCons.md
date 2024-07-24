using WoodArtCons.Shared.DataTransferObjects;
using MediatR;

namespace WoodArtCons.Interfaces
{
    public interface ICategoryManagerService
    {

        Task<List<CategoryModelDto>> GetAllCategories();
        Task<CategoryModelDto> GetCategoryById(string id);
        Task<Unit> EditCategory(CategoryModelDto categoryItem);
        Task<string> AddCategory(CategoryModelDto request);
        Task<Unit> DeleteCategory(string id);

    }
}
