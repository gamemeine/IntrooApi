using IntrooApi.Models;

namespace IntrooApi.Data
{
    public interface IStoreFileRepository
    {
        Task<IEnumerable<StoreFile>> GetAllStoreFiles();
        Task<StoreFile> GetStoreFileById(int id);
        Task<StoreFile> GetStoreFileByName(string name);
        Task AddStoreFile(StoreFile file);
        Task DeleteStoreFileById(int id);
        Task UpdateStoreFile(StoreFile file);
        Task Save();
    }
}