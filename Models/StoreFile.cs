namespace IntrooApi.Models
{
    public class StoreFile
    {
        public int Id { get; set; }
        public Guid AccessCode { get; set; } = Guid.NewGuid();
        public string FileName { get; set; }
        public string StoreDirectory { get; set; }
        public string AbsoluteDirectory { get; set; }
        public string Source => $"/files/{AccessCode}";

        public ICollection<Event>? Events { get; set; }

        public StoreFile(string fileName, string storeDirectory, string absoluteDirectory)
        {
            FileName = fileName;
            StoreDirectory = storeDirectory;
            AbsoluteDirectory = absoluteDirectory;
        }
    }

    public class StoreFileDto
    {
        public int Id { get; set; }
        public Guid AccessCode { get; set; }
        public string FileName { get; set; }
        public string StoreDirectory { get; set; }
        public string AbsoluteDirectory { get; set; }
        public string Source { get; }
    }

    public class StoreFileSourceDto
    {
        public int Id { get; set; }
        public Guid AccessCode { get; set; }
        public string Source => $"/files/{AccessCode}";
    }
}