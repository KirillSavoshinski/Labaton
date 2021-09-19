using System;
using System.IO;
using System.Linq;
using System.Text;
using Labaton.Interfaces;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Labaton.Services
{
    public class ApplyJsonService : IApplyJsonService
    {
        public void ApplyJson(string selectedFolder, IFormFile file)
        {
            var result = new StringBuilder();
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                    result.AppendLine(reader.ReadLine());
            }
            var structure = JsonConvert.DeserializeObject<JObject>(result.ToString());
           
            WalkJsonStructure(selectedFolder, structure);
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
                    Console.WriteLine(currentFolder);
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