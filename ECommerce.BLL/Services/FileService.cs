using Microsoft.AspNetCore.Http;

namespace ECommerce.BLL.Services
{
    public class FileService
    {
        public async Task<string> GenerateFile(IFormFile file, string filePath)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("File is null or empty", nameof(file));

            var fileName = $"{Path.GetFileNameWithoutExtension(file.FileName)}-{Guid.NewGuid()}-{Path.GetExtension(file.FileName)}";

            var fullPath = Path.Combine(filePath, fileName);

            Directory.CreateDirectory(filePath); // Ensure the directory exists

            //using (var stream = new FileStream(fullPath, FileMode.Create))
            //{
            //    await file.CopyToAsync(stream);
            //}

            var stream = new FileStream(fullPath, FileMode.Create);
            await file.CopyToAsync(stream);
            stream.Close();

            return fileName;
        }

       

        public bool IsImageFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return false;

            var contentType = file.ContentType.ToLowerInvariant();

            return contentType.StartsWith("image/");
            //var permittedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };
            //var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            //return !string.IsNullOrEmpty(extension) && permittedExtensions.Contains(extension);
        }
    }
}


