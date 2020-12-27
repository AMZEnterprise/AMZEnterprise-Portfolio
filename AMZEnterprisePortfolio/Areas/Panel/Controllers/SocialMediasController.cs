using AMZEnterprisePortfolio.Areas.Panel.Extensions;
using AMZEnterprisePortfolio.Areas.Panel.Models;
using AMZEnterprisePortfolio.Data.EFCore;
using AMZEnterprisePortfolio.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace AMZEnterprisePortfolio.Areas.Panel.Controllers
{
    [Area("Panel")]
    [Authorize]
    public class SocialMediasController : Controller
    {
        private readonly EfCoreSocialMediaRepository _repository;

        public SocialMediasController(EfCoreSocialMediaRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoadSocialMediasTable([FromBody] DTParameters dtParameters)
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
                    (r.Url.ToUpper() != null && r.Url.ToUpper().Contains(searchBy)) ||
                    (r.IconCss.ToUpper() != null && r.IconCss.ToUpper().Contains(searchBy))
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
        public async Task<IActionResult> Create(SocialMedia socialMedia)
        {
            if (ModelState.IsValid)
            {
                await _repository.Add(socialMedia);
                return RedirectToAction(nameof(Index));
            }

            return View(socialMedia);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var socialMedia = await _repository.Get(id);

            if (socialMedia == null)
            {
                return NotFound();
            }

            return View(socialMedia);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SocialMedia socialMedia)
        {
            if (id != socialMedia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _repository.Update(socialMedia);

                return RedirectToAction(nameof(Index));
            }

            return View(socialMedia);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _repository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
