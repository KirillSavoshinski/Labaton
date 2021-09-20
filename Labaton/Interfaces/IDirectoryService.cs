using Labaton.Models;

namespace Labaton.Interfaces
{
    public interface IDirectory
    {
        FolderItem GetDirectoriesStructure(string path);
    }
}