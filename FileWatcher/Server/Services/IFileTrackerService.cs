namespace FileWatcher.Server.Services
{
    public interface IFileTrackerService
    {
        RequestResponse<string> SetPath(string path);
        RequestResponse<List<ChangeData>> GetChanges(DateTime? getFrom);
    }
}
