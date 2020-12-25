using System.ComponentModel.DataAnnotations;
using AMZEnterprisePortfolio.Data;

namespace AMZEnterprisePortfolio.Models
{
    /// <summary>
    /// Favor entity
    /// </summary>
    public class Favor : IEntity
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(256)]
        public string Title { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }
    }
}
