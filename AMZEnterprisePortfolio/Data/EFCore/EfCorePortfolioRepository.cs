using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMZEnterprisePortfolio.Models;

namespace AMZEnterprisePortfolio.Data.EFCore
{
    /// <summary>
    /// Portfolio repository ef core implementation
    /// </summary>
    public class EfCorePortfolioRepository : EfCoreRepository<Portfolio, ApplicationDbContext>
    {
        public EfCorePortfolioRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
