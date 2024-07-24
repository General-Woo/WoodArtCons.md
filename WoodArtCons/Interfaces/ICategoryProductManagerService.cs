using Microsoft.AspNetCore.Mvc;
using WoodArtCons.Shared.DataTransferObjects;

namespace WoodArtCons.Interfaces
{
    public interface ICategoryProductManagerService
    {
        Task<CategoryProductModelDto> GetProductById(string id);

        Task<List<CategoryProductModelDto>> GetProductsByCategoryId(string id);
    }
}
