using Labaton.Models;

namespace Labaton.Interfaces
{
    public interface IDirectoryService
    {
        FolderItem GetDirectoriesStructure(string path);
    }
}