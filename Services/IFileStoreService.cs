using IntrooApi.Models;

namespace IntrooApi.Services
{
    public interface IFileStoreService
    {
        Task<StoreFile> AddFile(IFormFile file);
        Task<StoreFileDto> GetFile(Guid accessCode);
        Task DeleteFile(Guid accessCode);
    }
}