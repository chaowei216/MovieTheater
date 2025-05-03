using Microsoft.AspNetCore.Http;

namespace Application.Interfaces.Clould
{
    public interface ICloudinaryService
    {
        Task<string> UploadImageAsync(IFormFile file, string folder = "movies");
    }
}
