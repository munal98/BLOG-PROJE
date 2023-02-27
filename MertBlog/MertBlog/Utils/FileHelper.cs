using Microsoft.AspNetCore.Http;
using System.IO;

namespace MertBlog.Utils
{
    public class FileHelper
    {
        public string? IFormFile {get;set;}
        public static string FileLoader(IFormFile formFile, string filePath ="/img/")
        {
            var fileName = "";

            if (formFile !=null && formFile.Length> 0) 
            {
              fileName= formFile.FileName;
                string directory = Directory.GetCurrentDirectory() + "/wwwroot" + filePath + fileName;
                using (var stream= new FileStream(directory,FileMode.Create))
                {
                    formFile.CopyTo(stream);
                }
            }

            return fileName;
        }
        public static bool FileTerminator(string fileName, string filePath = "/img/")
        {
         string deletedFile = Directory.GetCurrentDirectory() + "/wwwroot" + filePath + fileName;
            if (File.Exists(deletedFile))
            {
                File.Delete(deletedFile);
                return true;
            }
            return false;
        }
    }
}
