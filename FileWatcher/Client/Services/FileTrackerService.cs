using System.Net.Http.Json;

namespace FileWatcher.Client.Services
{
    public class FileTrackerService : IFileTrackerService
    {
        private readonly HttpClient _http;

        #region Ctor
        public FileTrackerService(HttpClient http)
        {
            _http = http;
        }
        #endregion

        public async Task<RequestResponse<List<ChangeData>>> GetChanges(DateTime? getFrom)
        {
            var result = await _http.PostAsJsonAsync("api/FileTracker/get-changes", getFrom);

            return await result.Content.ReadFromJsonAsync<RequestResponse<List<ChangeData>>>();
        }

        public async Task<RequestResponse<string>> SetPath(string path)
        {
            var result = await _http.PostAsJsonAsync("api/FileTracker/set-path", path);

            return await result.Content.ReadFromJsonAsync<RequestResponse<string>>();
        }
    }
}
