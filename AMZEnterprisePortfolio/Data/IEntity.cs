using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMZEnterprisePortfolio.Data
{
    /// <summary>
    /// Base entity
    /// </summary>
    public interface IEntity
    {
        int Id { get; set; }
    }
}
