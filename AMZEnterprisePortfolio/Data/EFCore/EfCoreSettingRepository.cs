using AMZEnterprisePortfolio.Models;

namespace AMZEnterprisePortfolio.Data.EFCore
{
    /// <summary>
    /// Setting repository ef core implementation
    /// </summary>
    public class EfCoreSettingRepository : EfCoreRepository<Setting, ApplicationDbContext>
    {
        public EfCoreSettingRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
