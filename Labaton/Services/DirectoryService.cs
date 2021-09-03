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
        public FolderItem GetDirectoriesStructure(string path)
        {
            var folder = new FolderItem();

            if (string.IsNullOrEmpty(path))
            {
                folder.Parent = "root";
                folder.Children = new List<FolderItem>();

                foreach (var drive in Environment.GetLogicalDrives())
                {
                    folder.Children.Add(new FolderItem() {Parent = folder.Parent, Path = drive});
                }

                foreach (var child in folder.Children)
                {
                    WalkDirectoryTree(child);
                }
                
            }
            else
            {
                folder.Parent = path;
                WalkDirectoryTree(folder);
            }

            return folder;
        }

        private void WalkDirectoryTree(FolderItem folderItem, int depth = 0)
        {
            if (depth > 0)
            {
                return;
            }

            var root = new DirectoryInfo(folderItem.Path);
            FileInfo[] files = null;

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
                ++depth;
                foreach (var dirInfo in root.GetDirectories())
                {
                    var subDir = new FolderItem() {Path = dirInfo.FullName, Parent = folderItem.Path};
                    WalkDirectoryTree(subDir, depth);
                    folderItem.Children.Add(subDir);
                }
            }
        }
    }
}