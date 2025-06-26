namespace WoodArtCons.Interfaces
{
    public interface IFileUploadService
    {
        Task<string> UploadFile(MultipartFormDataContent content);
        Task<string> DeleteFile(string fileName);
        Task<string> UploadMultipleFiles(MultipartFormDataContent contents);
        Task<string> DeleteMultipleFile(string fileName);
    }
}
