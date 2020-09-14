using System;
using System.IO;
namespace FSW {
    class Program {
        static void Main (string[] args) {
            string path = @"D:\IDG";
            System.Console.WriteLine ("Watch Directory {0}", path);
            MonitorDirectory (path);
            Console.ReadKey ();

            Console.WriteLine ("Hello World!");
        }
        private static void MonitorDirectory (string path) {
            FileSystemWatcher fileSystemWatcher = new FileSystemWatcher ();
            fileSystemWatcher.Path = path;
            fileSystemWatcher.Created += FileSystemWatcher_Created;
            fileSystemWatcher.Renamed += FileSystemWatcher_Renamed;
            fileSystemWatcher.Deleted += FileSystemWatcher_Deleted;
            fileSystemWatcher.Changed += FileSystemWatcher_Changed;
            fileSystemWatcher.EnableRaisingEvents = true;
        }
        private static void FileSystemWatcher_Created (object sender, FileSystemEventArgs e) {
            Console.WriteLine ("File created: {0}", e.Name);
        }
        private static void FileSystemWatcher_Renamed (object sender, FileSystemEventArgs e) {
            Console.WriteLine ("File renamed: {0}", e.Name);
        }
        private static void FileSystemWatcher_Deleted (object sender, FileSystemEventArgs e) {
            Console.WriteLine ("File deleted: {0}", e.Name);
        }
        private static void FileSystemWatcher_Changed (object sender, FileSystemEventArgs e) {
            Console.WriteLine ("File changed: {0}", e.Name);
        }
    }
}