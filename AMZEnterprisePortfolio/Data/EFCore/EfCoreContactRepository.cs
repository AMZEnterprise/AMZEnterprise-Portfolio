using AMZEnterprisePortfolio.Models;

namespace AMZEnterprisePortfolio.Data.EFCore
{
    /// <summary>
    /// Contact repository ef core implementation
    /// </summary>
    public class EfCoreContactRepository : EfCoreRepository<Contact,ApplicationDbContext>
    {
        public EfCoreContactRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
