using AMZEnterprisePortfolio.Data.EFCore;
using AMZEnterprisePortfolio.Models;
using AMZEnterprisePortfolio.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace AMZEnterprisePortfolio.Areas.Panel.Controllers
{
    [Area("Panel")]
    [Authorize]
    public class SettingsController : Controller
    {
        private readonly EfCoreSettingRepository _repository;
        private readonly IFileUploader _fileUploader;
        private readonly IHostingEnvironment _env;
        public SettingsController(
            EfCoreSettingRepository repository,
            IFileUploader fileUploader,
            IHostingEnvironment env)
        {
            _repository = repository;
            _fileUploader = fileUploader;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            var setting = await _repository.Get(1);
            return View(setting);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Setting setting)
        {
            if (ModelState.IsValid)
            {
                await _repository.Update(setting);

                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    _fileUploader.DeleteMedia(_env.WebRootPath, setting.CvFilePathGuid.ToString());
                    await _fileUploader.UploadMedia(files, _env.WebRootPath, setting.CvFilePathGuid.ToString());
                }

                return RedirectToAction(nameof(Index));
            }

            return View(setting);
        }
    }
}