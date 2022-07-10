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


        public RequestResponse<List<ChangeData>> GetChanges(DateTime? getFrom)
        {
            var changes = getFrom != null ? _changes
                                                .Where(ch => ch.EventTime > getFrom)
                                                .ToList() : _changes;

            return new RequestResponse<List<ChangeData>>
            {
                Data = changes
            };
        }


        public RequestResponse<string> SetPath(string path)
        {
            var response = new RequestResponse<string>();

            try
            {
                _fileWatcher.Path = path.Replace("/", "\\");
                _fileWatcher.EnableRaisingEvents = true;

                response.Data = $"Path successfully set ({path}).";

                Console.WriteLine($"Path: {path}");
            }
            catch (Exception e)
            {
                response.Success = false;
                response.ErrorMessage = e.Message;
            }


            return response;
        }
    }
}
