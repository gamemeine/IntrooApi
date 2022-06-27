using IntrooApi.Data;
using IntrooApi.Models;

namespace IntrooApi.Services
{
    public interface IFileStoreService
    {
        Task<ICollection<StoreFile>> GetAllFiles(FileParameters? parameters);
        Task<StoreFile> GetFile(int id);
        Task<StoreFile> GetFileByName(string name);
        Task<StoreFile> AddFile(IFormFile file);
        Task DeleteFile(int id);
    }
}