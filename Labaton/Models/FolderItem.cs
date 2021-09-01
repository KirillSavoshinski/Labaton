using System.Collections.Generic;

namespace Labaton.Models
{
    public class FolderItem
    {
        public string Name { get; set; }
        public List<FolderItem> Children { get; set; }
        public string Parent { get; set; }
    }
}