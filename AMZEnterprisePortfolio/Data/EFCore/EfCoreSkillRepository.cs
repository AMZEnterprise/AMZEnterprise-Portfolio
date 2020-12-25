using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMZEnterprisePortfolio.Models;

namespace AMZEnterprisePortfolio.Data.EFCore
{
    /// <summary>
    /// Skill repository ef core implementation
    /// </summary>
    public class EfCoreSkillRepository : EfCoreRepository<Skill, ApplicationDbContext>
    {
        public EfCoreSkillRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
