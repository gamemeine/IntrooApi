using IntrooApi.Models;

namespace IntrooApi.Data
{
    public class StoreFileRepository : IStoreFileRepository
    {
        private readonly Models.AppDbContext context;

        public StoreFileRepository(Models.AppDbContext context)
        {
            this.context = context;
        }

        public async Task AddStoreFile(StoreFile file)
        {
            await context.StoreFiles.AddAsync(file);
            await Save();
        }

        public async Task DeleteStoreFileById(int id)
        {
            var file = await context.StoreFiles.FindAsync(id);

            if (file is null) return;

            context.StoreFiles.Remove(file);
            await Save();
        }

        public async Task<IEnumerable<StoreFile>> GetAllStoreFiles()
        {
            return context.StoreFiles.ToList();
        }

        public async Task<StoreFile> GetStoreFileById(int id)
        {
            return await context.StoreFiles.FindAsync(id);
        }

        public async Task<StoreFile> GetStoreFileByName(string name)
        {
            return context.StoreFiles.FirstOrDefault(f => f.Name == name);
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }

        public Task UpdateStoreFile(StoreFile file)
        {
            throw new NotImplementedException();
        }

    }
}