using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;

namespace Labaton.Interfaces
{
    public interface IApplyJsonService
    {
        void ApplyJson(string selectedFolder, IFormFile file);
    }
}