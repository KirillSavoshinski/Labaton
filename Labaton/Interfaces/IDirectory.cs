using System.Collections.Generic;
using Labaton.DTOs;
using Labaton.Models;

namespace Labaton.Interfaces
{
    public interface IDirectory
    {
        IEnumerable<FolderItem> GetDirectoriesStructure(GetStructureDto getStructureDto);
    }
}