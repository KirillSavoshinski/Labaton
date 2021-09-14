using Newtonsoft.Json.Linq;

namespace Labaton.Interfaces
{
    public interface IApplyJsonService
    {
        void ApplyJson(string selectedFolderPath, JObject structure);
    }
}