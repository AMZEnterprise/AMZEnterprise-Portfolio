using System.ComponentModel.DataAnnotations;
using AMZEnterprisePortfolio.Data;

namespace AMZEnterprisePortfolio.Models
{
    /// <summary>
    /// Social entity
    /// </summary>
    public class SocialMedia : IEntity
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(256)]
        public string Title { get; set; }
        [Required]
        [MaxLength(256)]
        public string Url { get; set; }
        [Display(Name = "Icon Css")]
        [Required]
        [MaxLength(256)]
        public string IconCss { get; set; }
    }
}
