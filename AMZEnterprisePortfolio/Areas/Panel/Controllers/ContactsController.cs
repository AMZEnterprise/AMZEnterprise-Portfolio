using AMZEnterprisePortfolio.Areas.Panel.Extensions;
using AMZEnterprisePortfolio.Areas.Panel.Models;
using AMZEnterprisePortfolio.Data.EFCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace AMZEnterprisePortfolio.Areas.Panel.Controllers
{
    [Area("Panel")]
    [Authorize]
    public class ContactsController : Controller
    {
        private readonly EfCoreContactRepository _repository;

        public ContactsController(EfCoreContactRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoadContactsTable([FromBody] DTParameters dtParameters)
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
                    (r.FullName.ToUpper() != null && r.FullName.ToUpper().Contains(searchBy)) ||
                    (r.Email.ToUpper() != null && r.Email.ToUpper().Contains(searchBy)) ||
                    (r.Subject.ToUpper() != null && r.Subject.ToUpper().Contains(searchBy)) ||
                    (r.Message.ToUpper() != null && r.Message.ToUpper().Contains(searchBy))
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

        public async Task<IActionResult> Edit(int id)
        {
            var contact = await _repository.Get(id);

            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _repository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}