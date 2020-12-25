using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMZEnterprisePortfolio.Models;

namespace AMZEnterprisePortfolio.Data.EFCore
{
    /// <summary>
    /// Favor repository ef core implementation
    /// </summary>
    public class EfCoreFavorRepository : EfCoreRepository<Favor, ApplicationDbContext>
    {
        public EfCoreFavorRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
