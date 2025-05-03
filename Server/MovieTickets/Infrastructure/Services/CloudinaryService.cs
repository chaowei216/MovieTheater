using Application.Interfaces.Clould;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace Application.Services
{
    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary _cloudinary;

        public CloudinaryService(Cloudinary cloudinary)
        {
            _cloudinary = cloudinary ?? throw new ArgumentNullException(nameof(cloudinary));
        }

        public async Task<string> UploadImageAsync(IFormFile file, string folder = "movies")
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("File is empty or null.");
            }

            using var stream = file.OpenReadStream();
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(file.FileName, stream),
                Folder = folder,
                Transformation = new Transformation()
                    .Width(500).Height(500).Crop("fit")
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

       
            if (uploadResult.Error != null)
            {
                throw new InvalidOperationException($"Failed to upload image to Cloudinary: {uploadResult.Error.Message}");
            }


            if (uploadResult.SecureUrl == null)
            {
                throw new InvalidOperationException("Failed to upload image to Cloudinary: SecureUrl is null.");
            }

            return uploadResult.SecureUrl.ToString();
        }
    }
}


