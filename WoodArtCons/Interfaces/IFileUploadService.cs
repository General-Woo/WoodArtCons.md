﻿namespace WoodArtCons.Interfaces
{
    public interface IFileUploadService
    {
        Task<string> UploadFile(MultipartFormDataContent content);
    }
}