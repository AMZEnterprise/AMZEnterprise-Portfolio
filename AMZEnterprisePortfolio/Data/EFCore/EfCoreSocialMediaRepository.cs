using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMZEnterprisePortfolio.Models;

namespace AMZEnterprisePortfolio.Data.EFCore
{
    /// <summary>
    /// Social media repository ef core implementation
    /// </summary>
    public class EfCoreSocialMediaRepository : EfCoreRepository<SocialMedia, ApplicationDbContext>
    {
        public EfCoreSocialMediaRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
