using System;
using System.IO;
using Labaton.Interfaces;
using Newtonsoft.Json.Linq;

namespace Labaton.Services
{
    public class ApplyJsonService : IApplyJsonService
    {
        public void ApplyJson(string selectedFolderPath, JObject structure)
        {
            var root = new DirectoryInfo(selectedFolderPath); 
            
            foreach (var el in structure)
            {
                Console.WriteLine($"key: {el.Key}");
                Console.WriteLine($"value: {el.Value}");
            }
        }
    }
}