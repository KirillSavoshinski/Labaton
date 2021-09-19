using Microsoft.AspNetCore.Http;

namespace Labaton.Interfaces
{
    public interface IApplyJsonService
    {
        void ApplyJson(string selectedFolder, IFormFile file);
    }
}