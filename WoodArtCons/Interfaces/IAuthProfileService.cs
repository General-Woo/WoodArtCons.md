using WoodArtCons.Shared.DataTransferObjects;

namespace WoodArtCons.Interfaces
{
    public interface IAuthProfileService
    {
        Task<ClaimsDto> Me(string jwt);
    }
}
