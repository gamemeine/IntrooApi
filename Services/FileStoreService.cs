using AutoMapper;
using IntrooApi.Data;
using IntrooApi.Models;

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

            var fileName = Path.ChangeExtension(Path.GetRandomFileName(), Path.GetExtension(file.FileName));
            var fileStorePath = fileName;
            var fileFullPath = GetFileAbsolutePath(fileStorePath);

            using (var stream = System.IO.File.Create(fileFullPath))
            {
                await file.CopyToAsync(stream);
            }

            var storeFile = new StoreFile(fileName, fileStorePath, fileFullPath);
            await storeFiles.AddStoreFile(storeFile);

            return storeFile;
        }

        public async Task DeleteFile(Guid accessCode)
        {
            var storeFile = await storeFiles.GetStoreFileByAccessCode(accessCode);
            var fileDirectory = GetFileAbsolutePath(storeFile.StoreDirectory);

            await storeFiles.DeleteStoreFileByAccessCode(accessCode);
            System.IO.File.Delete(fileDirectory);
        }

        public async Task<StoreFileDto> GetFile(Guid accessCode)
        {
            var storeFile = await storeFiles.GetStoreFileByAccessCode(accessCode);
            var storeFileDto = mapper.Map<StoreFileDto>(storeFile);
            storeFileDto.AbsoluteDirectory = GetFileAbsolutePath(storeFile.StoreDirectory);

            return storeFileDto;
        }

        private string GetFileAbsolutePath(string storeDirectory)
        {
            return Path.Combine(config["FileStore:Directory"], storeDirectory);
        }

    }
}