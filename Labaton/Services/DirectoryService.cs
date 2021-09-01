using System;
using System.Collections.Generic;
using Labaton.Interfaces;
using Labaton.Models;

namespace Labaton.Services
{
    public class DirectoryService : IDirectory
    {
        public IEnumerable<FolderItem> GetDirectoriesStructure()
        {
            var folders = new List<FolderItem>();
            var drives = Environment.GetLogicalDrives();

            foreach (var dr in drives)
            {
                var di = new System.IO.DriveInfo(dr);
                folders.Add(new FolderItem() {Parent = null, Name = di.Name});
                if (!di.IsReady)
                {
                    Console.WriteLine("The drive {0} could not be read", di.Name);
                    continue;
                }

                WalkDirectoryTree(di.RootDirectory, 1);
            }

            return folders;
        }

        private void WalkDirectoryTree(System.IO.DirectoryInfo root, int depth)
        {
            /*if (depth > 4)
            {
                return;
            }*/
            System.IO.FileInfo[] files = null;
            Console.WriteLine(root);
            try
            {
                files = root.GetFiles("*.*");
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
            }

            catch (System.IO.DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            if (files != null)
            {
                foreach (var dirInfo in root.GetDirectories())
                {
                    WalkDirectoryTree(dirInfo, ++depth);
                }
            }
        }
    }
}