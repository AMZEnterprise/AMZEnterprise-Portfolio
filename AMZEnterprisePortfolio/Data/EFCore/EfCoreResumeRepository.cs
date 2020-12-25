using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMZEnterprisePortfolio.Models;

namespace AMZEnterprisePortfolio.Data.EFCore
{
    /// <summary>
    /// Resume repository ef core implementation
    /// </summary>
    public class EfCoreResumeRepository : EfCoreRepository<Resume, ApplicationDbContext>
    {
        public EfCoreResumeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
