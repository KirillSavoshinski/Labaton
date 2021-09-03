using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Labaton.Interfaces;
using Labaton.Models;

namespace Labaton.Services
{
    public class DirectoryService : IDirectory
    {
        public IEnumerable<FolderItem> GetDirectoriesStructure(string path)
        {
            var folders = new List<FolderItem>();

            if (string.IsNullOrEmpty(path))
            {
                var drives = Environment.GetLogicalDrives();
                folders.AddRange(drives.Select(dr => new DriveInfo(dr))
                    .Select(di => new FolderItem() {Parent = null, Path = di.Name}));
            }
            else
            {
                var folder = new FolderItem() {Parent = "D:\\RIDER\\", Path = path};
                WalkDirectoryTree(folder);
                folders.Add(folder);
            }
            
            return folders;
        }

        private void WalkDirectoryTree(FolderItem folderItem, int depth = 0)
        {
            if (depth > 0)
            {
                return;
            }

            var root = new DirectoryInfo(folderItem.Path);
            FileInfo[] files = null;
            Console.WriteLine(folderItem.Path);
            
            try
            {
                files = root.GetFiles("*.*");
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
            }

            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            if (files != null)
            {
                folderItem.Children = new List<FolderItem>();
                foreach (var dirInfo in root.GetDirectories())
                {
                    var subDir = new FolderItem() {Path = dirInfo.FullName, Parent = folderItem.Path};
                    WalkDirectoryTree(subDir, ++depth);
                    folderItem.Children.Add(subDir);
                }
            }
        }
    }
}