using AMZEnterprisePortfolio.Areas.Panel.Extensions;
using AMZEnterprisePortfolio.Areas.Panel.Models;
using AMZEnterprisePortfolio.Data.EFCore;
using AMZEnterprisePortfolio.Models;
using AMZEnterprisePortfolio.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AMZEnterprisePortfolio.Areas.Panel.Controllers
{
    [Area("Panel")]
    [Authorize]
    public class PortfoliosController : Controller
    {
        private readonly EfCorePortfolioRepository _repository;
        private readonly IFileUploader _fileUploader;
        private readonly IHostingEnvironment _env;
        public PortfoliosController(
            EfCorePortfolioRepository repository,
            IFileUploader fileUploader,
            IHostingEnvironment env)
        {
            _repository = repository;
            _fileUploader = fileUploader;
            _env = env;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoadPortfoliosTable([FromBody] DTParameters dtParameters)
        {
            var searchBy = dtParameters.Search?.Value;

            var orderCriteria = string.Empty;
            var orderAscendingDirection = true;

            if (dtParameters.Order != null)
            {
                // in this example we just default sort on the 1st column
                orderCriteria = dtParameters.Columns[dtParameters.Order[0].Column].Data;
                orderAscendingDirection = dtParameters.Order[0].Dir.ToString().ToLower() == "asc";
            }
            else
            {
                // if we have an empty search then just order the results by Id ascending
                orderCriteria = "Id";
                orderAscendingDirection = true;
            }

            var result = _repository.GetAllAsQueryable();

            if (!string.IsNullOrWhiteSpace(searchBy))
            {
                result = result.Where(r =>
                    (r.Title.ToUpper() != null && r.Title.ToUpper().Contains(searchBy)) ||
                    (r.ShortDescription.ToUpper() != null && r.ShortDescription.ToUpper().Contains(searchBy)) ||
                    (r.EmployerFullName.ToUpper() != null && r.EmployerFullName.ToUpper().Contains(searchBy)) ||
                    (r.Technologies.ToUpper() != null && r.Technologies.ToUpper().Contains(searchBy)) ||
                    (r.PortfolioType.ToString().ToUpper() != null && r.PortfolioType.ToString().ToUpper().Contains(searchBy))
                );
            }

            result = orderAscendingDirection ?
                result.OrderByDynamic(orderCriteria, LinqExtensions.Order.Asc)
                : result.OrderByDynamic(orderCriteria, LinqExtensions.Order.Desc);

            // now just get the count of items (without the skip and take) - eg how many could be returned with filtering
            var filteredResultsCount = result.Count();
            var totalResultsCount = await _repository.Count();

            var resultList = result
               .Skip(dtParameters.Start)
               .Take(dtParameters.Length)
               .ToList();

            return new JsonResult(new
            {
                draw = dtParameters.Draw,
                recordsTotal = totalResultsCount,
                recordsFiltered = filteredResultsCount,
                data = resultList
            });
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Portfolio portfolio)
        {
            if (ModelState.IsValid)
            {
                portfolio.FilePathGuid = Guid.NewGuid();

                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    await _fileUploader.UploadMedia(files, _env.WebRootPath, portfolio.FilePathGuid.ToString());
                }
                else
                {
                    ModelState.AddModelError(nameof(Portfolio.FilePath), "Please upload one file.");
                    return View(portfolio);
                }

                await _repository.Add(portfolio);
                return RedirectToAction(nameof(Index));
            }

            return View(portfolio);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var portfolio = await _repository.Get(id);

            if (portfolio == null)
            {
                return NotFound();
            }

            return View(portfolio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Portfolio portfolio)
        {
            if (id != portfolio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    _fileUploader.DeleteMedia(_env.WebRootPath, portfolio.FilePathGuid.ToString());
                    await _fileUploader.UploadMedia(files, _env.WebRootPath, portfolio.FilePathGuid.ToString());
                }

                await _repository.Update(portfolio);

                return RedirectToAction(nameof(Index));
            }

            return View(portfolio);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var portfolio = await _repository.Get(id);
            await _repository.Delete(id);
            _fileUploader.DeleteMedia(_env.WebRootPath, portfolio.FilePathGuid.ToString());
            return RedirectToAction(nameof(Index));
        }

        public async Task<JsonResult> GetPortfolioFile(int id)
        {
            var portfolio = await _repository.Get(id);
            if (portfolio == null)
            {
                return new JsonResult(null);
            }

            return new JsonResult(_fileUploader.GetFileSource(_env.WebRootPath, portfolio.FilePathGuid.ToString()));
        }
    }
}