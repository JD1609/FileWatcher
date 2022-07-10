using Newtonsoft.Json;

namespace FileWatcher.Server
{
    public static class FileWatcherHandler
    {
        private static List<ChangeData>? Changes;

        public static FileSystemWatcher CreateFileTracker(List<ChangeData>? changes)
        {
            VerifyChangeList(changes);


            var fileWatcher = new FileSystemWatcher
            {
                IncludeSubdirectories = true,
                NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName
            };


            fileWatcher.Changed += new FileSystemEventHandler(OnChanged);
            fileWatcher.Created += new FileSystemEventHandler(OnChanged);
            fileWatcher.Deleted += new FileSystemEventHandler(OnChanged);


            return fileWatcher;
        }


        private static void VerifyChangeList(List<ChangeData>? changeList)
        {
            if (changeList == null)
                Changes = new List<ChangeData>();
            else
                Changes = changeList;
        }


        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            if (Changes == null)
                Changes = new List<ChangeData>();


            var changeData = new ChangeData
            {
                EventTime = DateTime.Now,
                EventName = e.ChangeType.ToString(),
                FileOrFolderName = e.Name ?? string.Empty,
                FullPath = e.FullPath
            };

            Changes.Add(changeData);

            Console.WriteLine(JsonConvert.SerializeObject(changeData, Formatting.Indented).ToString());
        }
    }
}
