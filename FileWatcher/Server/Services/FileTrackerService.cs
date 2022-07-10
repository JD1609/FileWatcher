namespace FileWatcher.Server.Services
{
    public class FileTrackerService : IFileTrackerService
    {
        private readonly FileSystemWatcher _fileWatcher;
        private readonly List<ChangeData> _changes;

        public FileTrackerService(FileSystemWatcher fileWatcher, List<ChangeData> changes)
        {
            _fileWatcher = fileWatcher;
            _changes = changes;
        }


        public RequestResponse<List<ChangeData>> GetChanges()
        {
            return new RequestResponse<List<ChangeData>>
            {
                Data = _changes
            };
        }


        public RequestResponse<string> SetPath(string path)
        {
            _fileWatcher.Path = path.Replace("/", "\\");
            _fileWatcher.EnableRaisingEvents = true;

            return new RequestResponse<string>
            {
                Data = $"Path [{path}] successfully set.",
            };
        }
    }
}
