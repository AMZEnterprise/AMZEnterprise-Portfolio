using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace AMZEnterprisePortfolio.Utility
{
    /// <summary>
    /// File uploader
    /// </summary>
    public interface IFileUploader
    {
        /// <summary>
        /// Upload media file
        /// </summary>
        /// <param name="files">files collection</param>
        /// <param name="webRootPath">website default root path</param>
        /// <param name="filePath">file uniq (GUID) path</param>
        /// <returns></returns>
        Task UploadMedia(IFormFileCollection files, string webRootPath, string filePath);
        /// <summary>
        /// Delete media file
        /// </summary>
        /// <param name="webRootPath">website default root path</param>
        /// <param name="filePath">file uniq (GUID) path</param>
        void DeleteMedia(string webRootPath, string filePath);
        /// <summary>
        /// Returns media file path for view
        /// </summary>
        /// <param name="webRootPath">website default root path</param>
        /// <param name="filePath">file uniq (GUID) path</param>
        /// <returns></returns>
        string GetFileSource(string webRootPath, string filePath);
    }
}
