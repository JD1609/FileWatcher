namespace FileWatcher.Shared.Data
{
    public class ChangeData
    {
        /// <summary>
        /// Event time
        /// </summary>
        public DateTime EventTime { get; set; }

        /// <summary>
        /// Event name
        /// </summary>
        public string EventName { get; set; } = string.Empty;

        /// <summary>
        /// Name of file or folder
        /// </summary>
        public string FileOrFolderName { get; set; } = string.Empty;

        /// <summary>
        /// Path to file or folder
        /// </summary>
        public string FullPath { get; set; } = string.Empty;
    }
}
