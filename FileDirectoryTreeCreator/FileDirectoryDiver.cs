using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Windows;

namespace FileDirectoryTreeCreator
{
    class FileDirectoryDiver
    {
        private List<Task> _tasks;
        private string _startDirectoryPath;

        public FileDirectoryDiver(string path)
        {
            _startDirectoryPath = path;
            _tasks = new List<Task>();
        }
        public void CreateDirectoryFile()
        {
            var dirInfo = new DirectoryInfo(_startDirectoryPath);
            DirectoryStucture ds = new DirectoryStucture(_startDirectoryPath);
            DiveInForDirectoryData(ds.Root, dirInfo, 0);
            Task.WaitAll(_tasks.ToArray());
            ds.Root.Show();
        }

        private void DiveInForDirectoryData(DirectoryNode currentNodeToFill, DirectoryInfo currentDirectory, int DeepLevel)
        {
            //Good old crutch, i simply don't know how to set required priviliges level
            FileInfo[] infoFiles;
            try
            {
                infoFiles = currentDirectory.GetFiles();
            }
            catch(UnauthorizedAccessException)
            {
                //var exeName = Process.GetCurrentProcess().MainModule.FileName;
                //ProcessStartInfo startInfo = new ProcessStartInfo(exeName);
                //startInfo.Verb = "runas";
                //Process.Start(startInfo);
                //Console.WriteLine("Need to restart with admin priviliges");
                //Environment.Exit(1);
                return;
            }
            currentNodeToFill.Name = currentDirectory.Name;
            var infoDirectories = currentDirectory.GetDirectories();
            currentNodeToFill.Files = new List<string>();
            for(int i = 0; i < infoFiles.Length; i++)
            {
                currentNodeToFill.Files.Add(infoFiles[i].Name);
            }
            currentNodeToFill.Folders = new List<DirectoryNode>();
            for (int i = 0;
                i < infoDirectories.Length; i++)
            {
                int k = i;
                currentNodeToFill.Folders.Add(new DirectoryNode(DeepLevel + 1));
                Task task = new Task(() => DiveInForDirectoryData(currentNodeToFill.Folders[k], infoDirectories[k], DeepLevel+1));
                _tasks.Add(task);
                task.Start();
            }
        }
    }
}
