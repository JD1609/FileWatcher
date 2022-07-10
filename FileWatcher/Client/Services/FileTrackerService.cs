namespace FileWatcher.Client.Services
{
    public class FileTrackerService : IFileTrackerService
    {
        private readonly HttpClient _http;

        public FileTrackerService(HttpClient http)
        {
            _http = http;
        }
    }
}
