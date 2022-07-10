using FileWatcher.Shared.Data;

namespace FileWatcher.Client.Services
{
    public interface IFileTrackerService
    {
        Task<RequestResponse<string>> SetPath(string path);
        Task<RequestResponse<List<ChangeData>>> GetChanges(DateTime? getFrom);
    }
}
