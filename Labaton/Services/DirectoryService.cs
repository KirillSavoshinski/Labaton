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

                // Here we skip the drive if it is not ready to be read. This
                // is not necessarily the appropriate action in all scenarios.
                if (!di.IsReady)
                {
                    Console.WriteLine("The drive {0} could not be read", di.Name);
                    continue;
                }
                WalkDirectoryTree(di.RootDirectory);
            }

            return folders;
        }

        private void WalkDirectoryTree(System.IO.DirectoryInfo root)
        {
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
                    WalkDirectoryTree(dirInfo);
                }
            }
        }
    }
}