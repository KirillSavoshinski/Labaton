using System.IO;
using System.Linq;
using Labaton.Interfaces;
using Newtonsoft.Json.Linq;

namespace Labaton.Services
{
    public class ApplyJsonService : IApplyJsonService
    {
        public void ApplyJson(string selectedFolderPath, JObject structure)
        {
            WalkJsonStructure(selectedFolderPath, structure);
        }

        private void WalkJsonStructure(string currentFolder, JToken children)
        {
            var folders = children.Children()
                .Select(_ => currentFolder).ToList();

            var i = 0;
            foreach (var child in children.Children())
            {
                if (child is JProperty property)
                {
                    currentFolder = folders[i] + property.Name + "/";
                    if (!Directory.Exists(currentFolder))
                    {
                        Directory.CreateDirectory(currentFolder);
                    }
                }

                WalkJsonStructure(currentFolder, child);
                i++;
            }
        }
    }
}