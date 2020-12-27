using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace AMZEnterprisePortfolio.Utility
{
    ///<inheritdoc/>
    public class FileUploader : IFileUploader
    {
        private async Task Upload(IFormFile file, string uploadPath)
        {
            Directory.CreateDirectory(uploadPath);

            var fullPath = Path.Combine(uploadPath, file.FileName);

            try
            {
                using (var fs = new FileStream(fullPath, FileMode.Create))
                {
                    await file.CopyToAsync(fs);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task UploadMedia(IFormFileCollection files, string webRootPath, string filePath)
        {
            string uploadPath = webRootPath + "\\" + "uploads" + "\\" + filePath;
            foreach (var file in files)
            {
                await Upload(file, uploadPath);
            }
        }

        public void DeleteMedia(string webRootPath, string filePath)
        {

            string uploadPath = webRootPath + "\\" + "uploads" + "\\" + filePath;
            try
            {
                if (Directory.Exists(uploadPath))
                {
                    Directory.Delete(uploadPath, true);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string GetFileSource(string webRootPath, string filePath)
        {
            string uploadPath = webRootPath + "\\" + "uploads" + "\\" + filePath;

            try
            {
                var files = Directory.GetFiles(
                    uploadPath,
                    "*.*",
                    SearchOption.TopDirectoryOnly);

                if (files.Length > 0 && files[0] != null)
                {
                    var path = "\\" + "uploads" + "\\" + filePath + "\\" + Path.GetFileName(files[0]);

                    return path.Replace(@"\", "/");
                }
            }
            catch { }

            return null;
        }
    }

}
