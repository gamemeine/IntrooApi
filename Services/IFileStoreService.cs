using IntrooApi.Models;

namespace IntrooApi.Services
{
    public interface IFileStoreService
    {
        Task<ICollection<StoreFile>> GetAllFiles();
        Task<StoreFile> GetFile(int id);
        Task<StoreFile> GetFileByName(string name);
        Task<StoreFile> AddFile(IFormFile file);
        Task DeleteFile(int id);
    }
}