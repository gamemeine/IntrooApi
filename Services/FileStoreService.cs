using AutoMapper;
using IntrooApi.Data;
using IntrooApi.Models;
using Microsoft.AspNetCore.StaticFiles;

namespace IntrooApi.Services
{
    public class FileStoreService : IFileStoreService
    {
        private readonly IStoreFileRepository storeFiles;
        private readonly IConfiguration config;
        private readonly IMapper mapper;

        public FileStoreService(IStoreFileRepository storeFiles, IConfiguration config, IMapper mapper)
        {
            this.storeFiles = storeFiles;
            this.config = config;
            this.mapper = mapper;
        }

        public async Task<StoreFile> AddFile(IFormFile file)
        {
            if (file.Length == 0) throw new Exception("File is empty!");

            var fileExtension = Path.GetExtension(file.FileName);
            var fileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName());

            var fileStorePath = Path.ChangeExtension(fileName, fileExtension);
            var fileFullPath = GetFileAbsolutePath(fileStorePath);

            using (var stream = System.IO.File.Create(fileFullPath))
            {
                await file.CopyToAsync(stream);
            }
            var provider = new FileExtensionContentTypeProvider();
            var fileType = "";
            provider.TryGetContentType(fileFullPath, out fileType);

            var storeFile = new StoreFile
            {
                Name = fileName,
                Extension = fileExtension,
                Type = fileType,
                StoreDirectory = fileStorePath,
                AbsoluteDirectory = fileFullPath,
            };

            await storeFiles.AddStoreFile(storeFile);

            return storeFile;
        }

        public async Task DeleteFile(int id)
        {
            var storeFile = await storeFiles.GetStoreFileById(id);
            var fileDirectory = GetFileAbsolutePath(storeFile.StoreDirectory);

            await storeFiles.DeleteStoreFileById(id);
            System.IO.File.Delete(fileDirectory);
        }

        public async Task<StoreFile> GetFile(int id)
        {
            return await storeFiles.GetStoreFileById(id);
        }

        public async Task<StoreFile> GetFileByName(string name)
        {
            return await storeFiles.GetStoreFileByName(name);
        }

        public async Task<ICollection<StoreFile>> GetAllFiles(FileParameters? parameters)
        {
            var all = await storeFiles.GetAllStoreFiles(parameters);
            return all.ToList();
        }

        private string GetFileAbsolutePath(string storeDirectory)
        {
            return Path.Combine(config["FileStore:Directory"], storeDirectory);
        }

    }
}