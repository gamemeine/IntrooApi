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

        public async Task DeleteStoreFile(int id)
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

        public async Task<StoreFile> GetStoreFileByAccessCode(Guid accessCode)
        {
            return context.StoreFiles.FirstOrDefault(x => x.AccessCode == accessCode);
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }

        public Task UpdateStoreFile(StoreFile file)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteStoreFileByAccessCode(Guid accessCode)
        {
            var file = context.StoreFiles.FirstOrDefault(x => x.AccessCode == accessCode);

            if (file is null) throw new Exception("Not found!");

            context.StoreFiles.Remove(file);
            await Save();
        }
    }
}