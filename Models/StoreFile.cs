namespace IntrooApi.Models
{
    public class StoreFile
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string StoreDirectory { get; set; }
        public string AbsoluteDirectory { get; set; }
        public string Source => $"/resource/{Id}";

        public ICollection<Event>? Events { get; set; }

        public StoreFile(string fileName, string storeDirectory, string absoluteDirectory)
        {
            FileName = fileName;
            StoreDirectory = storeDirectory;
            AbsoluteDirectory = absoluteDirectory;
        }
    }

    public class StoreFileDetailsDto
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string Source => $"/resource/{FileName}";
    }
}