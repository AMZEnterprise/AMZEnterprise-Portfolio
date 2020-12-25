using System.ComponentModel.DataAnnotations;
using AMZEnterprisePortfolio.Data;

namespace AMZEnterprisePortfolio.Models
{
    /// <summary>
    /// Skill entity
    /// </summary>
    public class Skill : IEntity
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(256)]
        public string Title { get; set; }
        [Range(0,100)]
        public int Percent { get; set; }
        [Display(Name = "Skill Type")]
        public SkillType SkillType { get; set; }
    }
}
