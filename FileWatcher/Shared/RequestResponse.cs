namespace FileWatcher.Shared
{
    public class RequestResponse<T>
    {
        public bool Success { get; set; } = true;
        public T? Data { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
    }
}
