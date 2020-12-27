using AMZEnterprisePortfolio.Data.EFCore;
using AMZEnterprisePortfolio.Models;
using AMZEnterprisePortfolio.Models.ViewModels;
using AMZEnterprisePortfolio.Utility;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AMZEnterprisePortfolio.Controllers
{
    /// <summary>
    /// Home controller consists all models and data.
    /// Website front-end is more like a SPA.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly EfCoreContactRepository _contactRepository;
        private readonly EfCoreFavorRepository _favorRepository;
        private readonly EfCorePortfolioRepository _portfolioRepository;
        private readonly EfCoreResumeRepository _resumeRepository;
        private readonly EfCoreSettingRepository _settingRepository;
        private readonly EfCoreSkillRepository _skillRepository;
        private readonly EfCoreSocialMediaRepository _socialMediaRepository;
        private readonly IHttpContextAccessor _accessor;
        private readonly IFileUploader _fileUploader;
        private readonly IHostingEnvironment _env;

        public HomeController(
            EfCoreContactRepository contactRepository,
            EfCoreFavorRepository favorRepository,
            EfCorePortfolioRepository portfolioRepository,
            EfCoreResumeRepository resumeRepository,
            EfCoreSettingRepository settingRepository,
            EfCoreSkillRepository skillRepository,
            EfCoreSocialMediaRepository socialMediaRepository,
            IHttpContextAccessor accessor,
            IFileUploader fileUploader,
            IHostingEnvironment env
        )
        {
            _contactRepository = contactRepository;
            _favorRepository = favorRepository;
            _portfolioRepository = portfolioRepository;
            _resumeRepository = resumeRepository;
            _settingRepository = settingRepository;
            _skillRepository = skillRepository;
            _socialMediaRepository = socialMediaRepository;
            _accessor = accessor;
            _fileUploader = fileUploader;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            var homeVm = new HomeVm()
            {
                Contact = new Contact(),
                Favors = await _favorRepository.GetAll(),
                Portfolios = await _portfolioRepository.GetAll(),
                Resumes = await _resumeRepository.GetAll(),
                Setting = await _settingRepository.Get(1),
                Skills = await _skillRepository.GetAll(),
                SocialMedias = await _socialMediaRepository.GetAll()
            };

            //Get portfolios images
            foreach (var portfolio in homeVm.Portfolios)
            {
                portfolio.FilePath = _fileUploader.GetFileSource(_env.WebRootPath, portfolio.FilePathGuid.ToString());
            }

            //Get Cv file
            homeVm.Setting.CvFilePath = _fileUploader.GetFileSource(_env.WebRootPath, homeVm.Setting.CvFilePathGuid.ToString());

            return View(homeVm);
        }

        //Save contact form entry
        public async Task<IActionResult> SendContact(Contact contact)
        {
            if (ModelState.IsValid)
            {
                //User ip address
                contact.Ip = _accessor.HttpContext.Connection.RemoteIpAddress.ToString();
                contact.CreateDate = DateTime.Now;

                await _contactRepository.Add(contact);

                return new JsonResult(new { message = "Your comment was sent successfully." });
            }

            return new JsonResult(new { message = "There was a problem sending the comment. Try again later." });
        }
    }
}
