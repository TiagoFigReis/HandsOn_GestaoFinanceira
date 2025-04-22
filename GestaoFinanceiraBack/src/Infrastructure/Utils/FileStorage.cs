using Microsoft.AspNetCore.Http;

namespace Infrastructure.Utils
{
    public class FileService
    {
        public static async Task<string> SaveFileAsync(IFormFile file, Guid receitaId, HttpContext context)
        {
            var projectRoot = Directory.GetParent(Directory.GetCurrentDirectory())!.FullName;
        
            var infrastructureFolder = Path.Combine(projectRoot, "Infrastructure", "Comprovantes");

            if (!Directory.Exists(infrastructureFolder))
            {
                Directory.CreateDirectory(infrastructureFolder);
            }

            var fileExtension = Path.GetExtension(file.FileName);
            var uniqueFileName = $"{receitaId}{fileExtension}";
            var filePath = Path.Combine(infrastructureFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            var baseUrl = $"{context.Request.Scheme}://{context.Request.Host}";

            return $"{baseUrl}/files/{uniqueFileName}";
        }

        public static Task DeleteFileAsync(Guid receitaId)
        {
            var projectRoot = Directory.GetParent(Directory.GetCurrentDirectory())!.FullName;
            var infrastructureFolder = Path.Combine(projectRoot, "Infrastructure", "Comprovantes");
            
            var file = Directory.GetFiles(infrastructureFolder, $"{receitaId}.*");

            if (file.Length == 0)
            {
                return Task.CompletedTask;
            }

            foreach (var filePath in file)
            {
                File.Delete(filePath);
            }

            return Task.CompletedTask;
        }
    }
}