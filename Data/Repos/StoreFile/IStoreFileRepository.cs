using IntrooApi.Models;

namespace IntrooApi.Data
{
    public interface IStoreFileRepository
    {
        Task<IEnumerable<StoreFile>> GetAllStoreFiles();
        Task<StoreFile> GetStoreFileById(int id);
        Task<StoreFile> GetStoreFileByAccessCode(Guid accessCode);
        Task AddStoreFile(StoreFile file);
        Task DeleteStoreFile(int id);
        Task DeleteStoreFileByAccessCode(Guid accessCode);
        Task UpdateStoreFile(StoreFile file);
        Task Save();

    }
}