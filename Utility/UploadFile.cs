using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MyWebSite.Utility
{
    public static class UploadFile
    {

        public static async Task<string> Add(IFormFile formFile)
        {
            var imgPrefixo = Guid.NewGuid() + "_";

            if (formFile == null)
            {
                throw new ApplicationException("Must be informad the Main Image.");
            }

            string filename = imgPrefixo + formFile.FileName;
            var path = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot/images", filename);
            if (System.IO.File.Exists(path))
            {
                throw new ApplicationException("The file already exist with this name");
            }

            using (var stream = new System.IO.FileStream(path, System.IO.FileMode.Create))
            {
                await formFile.CopyToAsync(stream);
            }

            return filename;
        }

        public static void Delete(string file)
        {
            var path = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot/images", file);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
        }
    }
}
